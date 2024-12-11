<?php
$host = '127.0.0.1';
$port = 12345;

// Настройки для подключения к базе данных
$db_host = 'localhost';
$db_name = 'psp';
$db_user = 'root';
$db_pass = 'zxzx';
$dsn = "mysql:host=$db_host;dbname=$db_name;charset=utf8";
$options = [
    PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION,
    PDO::ATTR_DEFAULT_FETCH_MODE => PDO::FETCH_ASSOC,
    PDO::ATTR_EMULATE_PREPARES => false,
];

// Создаем сокет
$socket = socket_create(AF_INET, SOCK_STREAM, SOL_TCP);
if ($socket === false) {
    echo "Не удалось создать сокет: " . socket_strerror(socket_last_error()) . "\n";
    exit;
}

// Привязываем сокет к адресу и порту
if (socket_bind($socket, $host, $port) === false) {
    echo "Не удалось привязать сокет: " . socket_strerror(socket_last_error($socket)) . "\n";
    exit;
}

// Начинаем прослушивание
if (socket_listen($socket, 5) === false) {
    echo "Не удалось начать прослушивание: " . socket_strerror(socket_last_error($socket)) . "\n";
    exit;
}

echo "Сервер запущен на {$host}:{$port}\n";

// Подключение к базе данных
try {
    $pdo = new PDO($dsn, $db_user, $db_pass, $options);
} catch (PDOException $e) {
    echo "Не удалось подключиться к базе данных: " . $e->getMessage() . "\n";
    exit;
}

do {
    // Принимаем подключение клиента
    $client = socket_accept($socket);
    if ($client === false) {
        echo "Не удалось принять подключение: " . socket_strerror(socket_last_error($socket)) . "\n";
        continue;
    }

    // Читаем данные от клиента
    $input = socket_read($client, 1024);
    if ($input === false) {
        echo "Не удалось прочитать данные: " . socket_strerror(socket_last_error($client)) . "\n";
        socket_close($client);
        continue;
    }

    echo "Получено сообщение: $input\n";

    $params = explode('|', $input);
    $command = $params[0];

    if ($command === 'register') {
        $username = $params[1];
        $password = $params[2];
        $role = $params[3];
        $roleCode = $params[4];

        try {
            // Проверка наличия пользователя
            $stmt = $pdo->prepare("SELECT * FROM users WHERE username = :username");
            $stmt->execute(['username' => $username]);
            $user = $stmt->fetch();

            if ($user) {
                $output = "Пользователь с таким именем уже существует.";
            } else {
                if ($role === "Admin") {
                    if ($roleCode === 'Kursach') {
                        $userRole = 'admin';
                        // Создание нового пользователя
                        $stmt = $pdo->prepare("INSERT INTO users (username, password, created_at, role) VALUES (:username, :password, NOW(), :role)");
                        $stmt->execute([
                            'username' => $username,
                            'password' => $password,
                            'role' => $userRole
                        ]);
                        $output = "Пользователь успешно зарегистрирован.";
                    } else {
                        $output = "Вы ввели неверное кодовое слово";
                    }
                } else {
                    $userRole = 'user';

                    // Создание нового пользователя
                    $stmt = $pdo->prepare("INSERT INTO users (username, password, created_at, role) VALUES (:username, :password, NOW(), :role)");
                    $stmt->execute([
                        'username' => $username,
                        'password' => $password,
                        'role' => $userRole
                    ]);
                    $output = "Пользователь успешно зарегистрирован.";
                }
            }
        } catch (PDOException $e) {
            $output = "Ошибка выполнения запроса к базе данных: " . $e->getMessage();
        }
    } elseif ($command === 'login') {
        $username = $params[1];
        $password = $params[2];

        try {
            // Проверка пользователя и пароля
            $stmt = $pdo->prepare("SELECT * FROM users WHERE username = :username");
            $stmt->execute(['username' => $username]);
            $user = $stmt->fetch();

            if ($user && $user['password'] === $password) {
                $output = "success|{$user['role']}|{$user['id']}";
            } else {
                $output = "Неверное имя пользователя или пароль.";
            }
        } catch (PDOException $e) {
            $output = "Ошибка выполнения запроса к базе данных: " . $e->getMessage();
        }
    } elseif ($command === 'delete_test') {
        $userId = $params[1];
        $testId = $params[2];

        try {
            // Получение user_id теста
            $stmt = $pdo->prepare("SELECT user_id FROM tests WHERE id = :test_id");
            $stmt->execute(['test_id' => $testId]);
            $test = $stmt->fetch();

            // Получение роли пользователя
            $stmt = $pdo->prepare("SELECT role FROM users WHERE id = :user_id");
            $stmt->execute(['user_id' => $userId]);
            $user = $stmt->fetch();
            $role = $user['role'];

            echo "User ID: " . $userId . "\n";
            echo "Test User ID: " . $test['user_id'] . "\n";
            echo "Role: " . $role . "\n";

            //Проверка прав пользователя
            if ($test['user_id'] != $userId && $role !== "admin") {
                throw new Exception("У вас нет прав удалить этот тест.");
            }

            // Удаление всех связанных вопросов и ответов перед удалением теста
            $stmt = $pdo->prepare("DELETE FROM answers WHERE question_id IN (SELECT id FROM questions WHERE test_id = :test_id)");
            $stmt->execute(['test_id' => $testId]);

            $stmt = $pdo->prepare("DELETE FROM questions WHERE test_id = :test_id");
            $stmt->execute(['test_id' => $testId]);

            $stmt = $pdo->prepare("DELETE FROM tests WHERE id = :id");
            $stmt->execute(['id' => $testId]);

            $output = "Тест успешно удален.";
        } catch (Exception $e) {
            $output = "Ошибка: " . $e->getMessage();
        }
    } elseif ($command === 'load_all_tests') {
        try {
            $stmt = $pdo->prepare("
                SELECT tests.id, tests.title, tests.created_at, users.username 
                FROM tests 
                JOIN users ON tests.user_id = users.id
            ");
            $stmt->execute();
            $tests = $stmt->fetchAll();

            $output = '';
            foreach ($tests as $test) {
                $output .= "{$test['id']}|{$test['title']}|{$test['created_at']}|{$test['username']}\n";
            }
        } catch (PDOException $e) {
            $output = 'Ошибка выполнения запроса к базе данных: ' . $e->getMessage();
        }
    } elseif ($command === 'add_test') {
        $userId = $params[1];
        $title = $params[2];
        $questions = explode(';', $params[3]);

        try {
            // Добавление теста
            $stmt = $pdo->prepare("INSERT INTO tests (title, created_at, user_id) VALUES (:title, NOW(), :user_id)");
            $stmt->execute(['title' => $title, 'user_id' => $userId]);
            $testId = $pdo->lastInsertId();
            echo "Test ID: $testId\n";

            // Добавление вопросов и ответов
            foreach ($questions as $question) {
                if (empty($question))
                    continue; // Пропуск пустых строк

                list($questionText, $answers) = explode('~', $question, 2);
                $stmt = $pdo->prepare("INSERT INTO questions (test_id, question_text) VALUES (:test_id, :question_text)");
                $stmt->execute(['test_id' => $testId, 'question_text' => $questionText]);
                $questionId = $pdo->lastInsertId();
                echo "Question ID: $questionId\n";

                foreach (explode('~', $answers) as $answer) {
                    if (empty($answer))
                        continue; // Пропуск пустых строк

                    list($answerText, $isCorrect) = explode('^', $answer);
                    $stmt = $pdo->prepare("INSERT INTO answers (question_id, answer_text, is_correct) VALUES (:question_id, :answer_text, :is_correct)");
                    $stmt->execute(['question_id' => $questionId, 'answer_text' => $answerText, 'is_correct' => $isCorrect]);
                    echo "Answer: $answerText, Correct: $isCorrect\n";
                }
            }

            $output = "Тест успешно добавлен.";
        } catch (PDOException $e) {
            $output = "Ошибка выполнения запроса к базе данных: " . $e->getMessage();
        }
    }// Обработчик команды update_test
    elseif ($command === 'update_test') {
        $userId = $params[1];
        $testId = $params[2];
        $title = $params[3];
        $questions = explode(';', $params[4]);

        try {
            // Проверка, что тест принадлежит пользователю
            $stmt = $pdo->prepare("SELECT user_id FROM tests WHERE id = :test_id");
            $stmt->execute(['test_id' => $testId]);
            $test = $stmt->fetch();

            if ($test['user_id'] != $userId) {
                throw new Exception("Вы не можете изменять этот тест.");
            }

            // Обновление названия теста
            $stmt = $pdo->prepare("UPDATE tests SET title = :title WHERE id = :test_id");
            $stmt->execute(['title' => $title, 'test_id' => $testId]);

            // Получение текущих вопросов и ответов для удаления
            $stmt = $pdo->prepare("SELECT id FROM questions WHERE test_id = :test_id");
            $stmt->execute(['test_id' => $testId]);
            $existingQuestions = $stmt->fetchAll(PDO::FETCH_COLUMN, 0);

            foreach ($existingQuestions as $questionId) {
                $stmt = $pdo->prepare("SELECT id FROM answers WHERE question_id = :question_id");
                $stmt->execute(['question_id' => $questionId]);
                $existingAnswers[$questionId] = $stmt->fetchAll(PDO::FETCH_COLUMN, 0);
            }

            // Обновление вопросов и ответов
            foreach ($questions as $question) {
                if (empty($question))
                    continue; // Пропуск пустых строк

                list($questionText, $answers) = explode('~', $question, 2);
                if (empty($questionText))
                    continue; // Пропуск пустых вопросов

                $stmt = $pdo->prepare("SELECT id FROM questions WHERE test_id = :test_id AND question_text = :question_text");
                $stmt->execute(['test_id' => $testId, 'question_text' => $questionText]);
                $existingQuestion = $stmt->fetch();

                if ($existingQuestion) {
                    $questionId = $existingQuestion['id'];
                    $stmt = $pdo->prepare("UPDATE questions SET question_text = :question_text WHERE id = :question_id");
                    $stmt->execute(['question_text' => $questionText, 'question_id' => $questionId]);
                    unset($existingQuestions[array_search($questionId, $existingQuestions)]);
                } else {
                    $stmt = $pdo->prepare("INSERT INTO questions (test_id, question_text) VALUES (:test_id, :question_text)");
                    $stmt->execute(['test_id' => $testId, 'question_text' => $questionText]);
                    $questionId = $pdo->lastInsertId();
                }

                $currentAnswers = explode('~', $answers);
                foreach ($currentAnswers as $answer) {
                    if (empty($answer))
                        continue; // Пропуск пустых строк

                    list($answerText, $isCorrect) = explode('^', $answer);
                    if (empty($answerText))
                        continue; // Пропуск пустых ответов

                    $stmt = $pdo->prepare("SELECT id FROM answers WHERE question_id = :question_id AND answer_text = :answer_text");
                    $stmt->execute(['question_id' => $questionId, 'answer_text' => $answerText]);
                    $existingAnswer = $stmt->fetch();

                    if ($existingAnswer) {
                        $answerId = $existingAnswer['id'];
                        $stmt = $pdo->prepare("UPDATE answers SET answer_text = :answer_text, is_correct = :is_correct WHERE id = :answer_id");
                        $stmt->execute(['answer_text' => $answerText, 'is_correct' => (int) $isCorrect, 'answer_id' => $answerId]);
                        unset($existingAnswers[$questionId][array_search($answerId, $existingAnswers[$questionId])]);
                    } else {
                        $stmt = $pdo->prepare("INSERT INTO answers (question_id, answer_text, is_correct) VALUES (:question_id, :answer_text, :is_correct)");
                        $stmt->execute(['question_id' => $questionId, 'answer_text' => $answerText, 'is_correct' => (int) $isCorrect]);
                    }
                }

                // Удаление оставшихся ответов
                foreach ($existingAnswers[$questionId] as $answerId) {
                    $stmt = $pdo->prepare("DELETE FROM answers WHERE id = :answer_id");
                    $stmt->execute(['answer_id' => $answerId]);
                }
            }

            // Удаление оставшихся вопросов
            foreach ($existingQuestions as $questionId) {
                $stmt = $pdo->prepare("DELETE FROM questions WHERE id = :question_id");
                $stmt->execute(['question_id' => $questionId]);
            }

            $output = "Тест успешно обновлен.";
        } catch (Exception $e) {
            $output = "Ошибка: " . $e->getMessage();
        }
    } elseif ($command === 'load_test') {
        $testId = $params[1];

        try {
            $stmt = $pdo->prepare("SELECT * FROM questions WHERE test_id = :test_id");
            $stmt->execute(['test_id' => $testId]);
            $questions = $stmt->fetchAll();

            $output = '';
            foreach ($questions as $question) {
                $questionId = $question['id'];
                $questionText = $question['question_text'];

                $stmt = $pdo->prepare("SELECT * FROM answers WHERE question_id = :question_id");
                $stmt->execute(['question_id' => $questionId]);
                $answers = $stmt->fetchAll();

                $answerStrings = [];
                foreach ($answers as $answer) {
                    $answerId = $answer['id'];
                    $answerText = $answer['answer_text'];
                    $isCorrect = $answer['is_correct'];
                    $answerStrings[] = "{$answerId}^{$answerText}^{$isCorrect}";
                }
                $output .= "{$questionId}~{$questionText}~" . implode('~', $answerStrings) . "\n";
            }
            echo $output;
        } catch (PDOException $e) {
            $output = "Ошибка выполнения запроса к базе данных: " . $e->getMessage();
        }
    }
    
    
    
    
    
    
    
    
    
    
    elseif ($command === 'submit_test') {
        $userId = $params[1];
        $testId = $params[2];
        $answersString = $params[3];
        // Разделяем ответы пользователя
        $userAnswers = explode('^', $answersString);
        $totalQuestions = count($userAnswers);
        $totalScore = 0;
    
        foreach ($userAnswers as $userAnswer) {
            list($questionId, $userAnswerString) = explode(':', $userAnswer);
            $userAnswerArray = str_split($userAnswerString);
    
            // Получаем правильные ответы по идентификатору вопроса
            $stmt = $pdo->prepare("SELECT id FROM answers WHERE question_id = :question_id AND is_correct = 1");
            $stmt->execute(['question_id' => $questionId]);
            $correctAnswers = $stmt->fetchAll(PDO::FETCH_COLUMN);
    
            // Подсчитываем количество правильных ответов
            $correctCount = count($correctAnswers);
    
            // Подсчитываем количество правильных ответов пользователя
            $userCorrectCount = 0;
            foreach ($correctAnswers as $correctAnswer) {
                if (in_array($correctAnswer, $userAnswerArray)) {
                    $userCorrectCount++;
                }
            }
    
            // Рассчитываем баллы за вопрос
            if ($userCorrectCount == $correctCount) {
                $totalScore += 1;
            }
        }
    
        // Рассчитываем процент
        $percentageScore = ($totalScore / $totalQuestions) * 100;
    
        // Сохраняем результат в базу данных
        $stmt = $pdo->prepare("INSERT INTO test_results (user_id, test_id, score, completed_at) VALUES (:user_id, :test_id, :score, NOW())");
        $stmt->execute(['user_id' => $userId, 'test_id' => $testId, 'score' => $percentageScore]);
    
        // Возвращаем результат клиенту
        $output = "Тест успешно пройден. Ваш результат: $totalScore.";
        echo $output;
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    elseif ($command === 'load_user_tests') {
        $userId = $params[1];

        try {
            $stmt = $pdo->prepare("SELECT * FROM tests WHERE user_id = :user_id");
            $stmt->execute(['user_id' => $userId]);
            $tests = $stmt->fetchAll();

            $output = '';
            foreach ($tests as $test) {
                $output .= "{$test['id']}|{$test['title']}|{$test['created_at']}|{$test['user_id']}\n";
            }
        } catch (PDOException $e) {
            $output = "Ошибка выполнения запроса к базе данных: " . $e->getMessage();
        }
    } else {
        $output = "Неизвестная команда.";
    }

    // Отправляем ответ клиенту
    socket_write($client, $output, strlen($output));

    // Закрываем соединение с клиентом
    socket_close($client);
} while (true);

// Закрываем серверный сокет
socket_close($socket);