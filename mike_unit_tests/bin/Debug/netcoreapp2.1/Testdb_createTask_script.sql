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