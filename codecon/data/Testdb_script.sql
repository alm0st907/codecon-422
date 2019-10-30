CREATE TABLE TestCodeconDB Project(
projectName NVARCHAR(100),
defconScale INT,
dueDate DATE,
PRIMARY KEY (projectName)
);

CREATE TABLE TestCodeconDB [User](
username NVARCHAR(100),
email NVARCHAR(100),
[password] NVARCHAR(100),
id INT,
PRIMARY KEY (username)
);

CREATE TABLE TestCodeconDB Task(
projectName NVARCHAR(100),
escalationValue INT,
assignee NVARCHAR(100),
taskName NVARCHAR(100),
description NVARCHAR(100),
PRIMARY KEY (taskName),
FOREIGN KEY (assignee) REFERENCES [User](username),
FOREIGN KEY (projectName) REFERENCES Project(projectName)
);

INSERT INTO Project VALUES('Testproject', 5, '2019-10-25');
INSERT INTO [User] VALUES('User1', 'user1@email.com', '12345', 1);
INSERT INTO [User] VALUES('User2', 'user2@email.com', 'abcde', 2);
INSERT INTO [User] VALUES('User3', 'user3@email.com', 'zyxwv', 3);
INSERT INTO Task VALUES('Testproject', 1, 'User1', 'Task1', 'Task1 is a test task');
INSERT INTO Task VALUES('Testproject', 2, 'User2', 'Task2', 'Task2 is a test task');
INSERT INTO Task VALUES('Testproject', 3, 'User3', 'Task3', 'Task3 is a test task');