create database TachesDB;
GO
Use TachesDB;

CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Email NVARCHAR(255) NOT NULL UNIQUE,
    Nom NVARCHAR(100) NOT NULL,
    Password NVARCHAR(255) NOT NULL,
);

CREATE TABLE Taches (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    Title NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX) NULL,
    IsDone BIT DEFAULT 0,
    CreatedAt DATETIME2 DEFAULT GETDATE(),
);

ALTER TABLE Taches
ADD CONSTRAINT FK_Taches_User
FOREIGN KEY (UserId) REFERENCES Users(Id);


INSERT INTO Users (Email, Nom, Password)
VALUES ('ouma@mail.com', 'Oumaima', 'hashedpassword1');


INSERT INTO Taches(UserId, Title, Description)
VALUES 
(1, 'Faire les courses', 'Acheter lait et pain'),
(1, 'Lire la formation', 'Réaliser le projet CRUD');

SELECT t.Id, t.Title, t.Description, t.IsDone, u.Nom
FROM Taches t
JOIN Users u ON t.UserId = u.Id
WHERE u.Email = 'ouma@mail.com';