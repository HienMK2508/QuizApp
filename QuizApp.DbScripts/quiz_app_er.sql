
--Create database QuizApp
--use QuizApp

CREATE TABLE [User] (
    UserId INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100),
    Email NVARCHAR(100)
);

CREATE TABLE Quiz (
    QuizId INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(255),
    Description NVARCHAR(500)
);

CREATE TABLE Question (
    QuestionId INT PRIMARY KEY IDENTITY,
    QuizId INT FOREIGN KEY REFERENCES Quiz(QuizId),
    Text NVARCHAR(1000)
);

CREATE TABLE [Option] (
    OptionId INT PRIMARY KEY IDENTITY,
    QuestionId INT FOREIGN KEY REFERENCES Question(QuestionId),
    Text NVARCHAR(500),
    IsCorrect BIT
);

CREATE TABLE Answer (
    AnswerId INT PRIMARY KEY IDENTITY,
    UserId INT FOREIGN KEY REFERENCES [User](UserId),
    QuizId INT FOREIGN KEY REFERENCES Quiz(QuizId),
    QuestionId INT FOREIGN KEY REFERENCES Question(QuestionId),
    SelectedOptionId INT FOREIGN KEY REFERENCES [Option](OptionId),
    IsCorrect BIT,
    TimeTaken INT -- in seconds
);

CREATE TABLE Result (
    ResultId INT PRIMARY KEY IDENTITY,
    UserId INT FOREIGN KEY REFERENCES [User](UserId),
    QuizId INT FOREIGN KEY REFERENCES Quiz(QuizId),
    TotalTime INT, -- in seconds
    CorrectAnswers INT,
    Passed BIT
);


-- Tạo User
INSERT INTO [User] (Name, Email)
VALUES (N'Tester', 'test@example.com');

-- Tạo Quiz
INSERT INTO Quiz (Title, Description)
VALUES (N'Developer Basics Quiz', N'10 câu hỏi về lập trình cơ bản');

-- Tạo 10 câu hỏi
INSERT INTO Question (QuizId, Text) VALUES 
(1, N'1. What is 2 + 2?'),
(1, N'2. Which keyword defines a method in C#?'),
(1, N'3. Which loop is most common in C#?'),
(1, N'4. What is a correct syntax to declare an int variable?'),
(1, N'5. Which symbol is used for comments?'),
(1, N'6. What does IDE stand for?'),
(1, N'7. Which data type is used for true/false?'),
(1, N'8. How do you write a conditional if?'),
(1, N'9. What is null in C#?'),
(1, N'10. What is the entry point of a console app?');

-- Tạo option cho mỗi câu (1 đáp án đúng / 3 sai)
-- Câu 1: 2 + 2
INSERT INTO [Option] (QuestionId, Text, IsCorrect) VALUES 
(1, '3', 0), (1, '4', 1), (1, '5', 0), (1, '22', 0);

-- Câu 2
INSERT INTO [Option] (QuestionId, Text, IsCorrect) VALUES 
(2, 'define', 0), (2, 'method', 0), (2, 'void', 1), (2, 'function', 0);

-- Câu 3
INSERT INTO [Option] (QuestionId, Text, IsCorrect) VALUES 
(3, 'for', 1), (3, 'foreach', 0), (3, 'while', 0), (3, 'loop', 0);

-- Câu 4
INSERT INTO [Option] (QuestionId, Text, IsCorrect) VALUES 
(4, 'int x;', 1), (4, 'int = x;', 0), (4, 'var int;', 0), (4, 'x int;', 0);

-- Câu 5
INSERT INTO [Option] (QuestionId, Text, IsCorrect) VALUES 
(5, '//', 1), (5, '/*', 0), (5, '#', 0), (5, '--', 0);

-- Câu 6
INSERT INTO [Option] (QuestionId, Text, IsCorrect) VALUES 
(6, 'Integrated Development Environment', 1), (6, 'Internet Dev Engine', 0), (6, 'Internal Dev Env', 0), (6, 'Interactive Drive Editor', 0);

-- Câu 7
INSERT INTO [Option] (QuestionId, Text, IsCorrect) VALUES 
(7, 'int', 0), (7, 'bool', 1), (7, 'string', 0), (7, 'bit', 0);

-- Câu 8
INSERT INTO [Option] (QuestionId, Text, IsCorrect) VALUES 
(8, 'if (x > 0)', 1), (8, 'if x > 0 then', 0), (8, 'x > 0 ?', 0), (8, 'when x > 0', 0);

-- Câu 9
INSERT INTO [Option] (QuestionId, Text, IsCorrect) VALUES 
(9, '0', 0), (9, 'undefined', 0), (9, 'null', 1), (9, 'empty', 0);

-- Câu 10
INSERT INTO [Option] (QuestionId, Text, IsCorrect) VALUES 
(10, 'void Start()', 0), (10, 'Main()', 1), (10, 'start()', 0), (10, 'run()', 0);

-- USER trả lời (giả sử đúng 5/10, mất 35s)
-- Câu 1: đúng (option 2)
INSERT INTO Answer (UserId, QuizId, QuestionId, SelectedOptionId, IsCorrect, TimeTaken)
VALUES (1, 1, 1, 2, 1, 4);

-- Câu 2: sai (option 1)
INSERT INTO Answer VALUES (1, 1, 2, 5, 0, 3);
-- Câu 3: đúng (option 9)
INSERT INTO Answer VALUES (1, 1, 3, 9, 1, 3);
-- Câu 4: đúng (option 13)
INSERT INTO Answer VALUES (1, 1, 4, 13, 1, 3);
-- Câu 5: sai (option 18)
INSERT INTO Answer VALUES (1, 1, 5, 18, 0, 2);
-- Câu 6: sai (option 23)
INSERT INTO Answer VALUES (1, 1, 6, 23, 0, 4);
-- Câu 7: đúng (option 26)
INSERT INTO Answer VALUES (1, 1, 7, 26, 1, 4);
-- Câu 8: đúng (option 29)
INSERT INTO Answer VALUES (1, 1, 8, 29, 1, 5);
-- Câu 9: sai (option 33)
INSERT INTO Answer VALUES (1, 1, 9, 33, 0, 4);
-- Câu 10: sai (option 38)
INSERT INTO Answer VALUES (1, 1, 10, 38, 0, 3);

-- Tổng hợp kết quả (5 đúng, 35s)
INSERT INTO Result (UserId, QuizId, TotalTime, CorrectAnswers, Passed)
VALUES (1, 1, 35, 5, 1);