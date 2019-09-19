use CodeconDB

CREATE TABLE Project(
projectName NVARCHAR(100),
defconScale INT,
dueDate DATE,
PRIMARY KEY (projectName)
);

CREATE TABLE [User](
username NVARCHAR(100),
email NVARCHAR(100),
[password] NVARCHAR(100),
id INT,
PRIMARY KEY (username)
);

CREATE TABLE Task(
projectName NVARCHAR(100),
escalationValue INT,
assignee NVARCHAR(100),
taskName NVARCHAR(100),
description NVARCHAR(100),
PRIMARY KEY (taskName),
FOREIGN KEY (assignee) REFERENCES [User](username),
FOREIGN KEY (projectName) REFERENCES Project(projectName)
);

INSERT INTO Project VALUES('Codecon', 5, '2019-09-19');
INSERT INTO [User] VALUES('Mike', 'mike@hotmail.com', '12skipafew99100', 0);
INSERT INTO [User] VALUES('Jeff', 'jeff@hotmail.com', 'enieminiemoe', 1);
INSERT INTO [User] VALUES('Garrett', 'garrett@hotmail.com', 'whiskeytangofoxtrot', 2);
INSERT INTO [User] VALUES('Slater', 'slater@hotmail.com', '4224lyfe', 3);
INSERT INTO Task VALUES('Codecon', 1, 'Mike', 'Do The First Thing', 'The thing that needs to be done first will be done first');
INSERT INTO Task VALUES('Codecon', 2, 'Jeff', 'Do The Second Thing', 'The thing that needs to be done second will be done second');
INSERT INTO Task VALUES('Codecon', 3, 'Slater', 'Do The Third Thing', 'The thing that needs to be done third will be done third');
INSERT INTO Task VALUES('Codecon', 4, 'Garrett', 'Do The Right Thing', 'There is reddit karma in it for you');