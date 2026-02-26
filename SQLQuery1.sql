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


INSERT INTO Taches (Title, Description, IsDone, UserId, CreatedAt)
VALUES
('Faire la vaisselle', 'Laver les assiettes et verres', 0, 1, GETDATE()),
('Préparer le rapport', 'Rapport mensuel pour le manager', 0, 1, GETDATE()),
('Réviser le projet Todo', 'Corriger les bugs de l\'application React', 0, 1, GETDATE()),
('Appeler le fournisseur', 'Confirmer la livraison des fournitures', 1, 1, GETDATE()),
('Envoyer l\'email de suivi', 'Envoyer l\'email à l\'équipe', 0, 1, GETDATE()),
('Planifier réunion', 'Organiser la réunion hebdomadaire du projet', 0, 1, GETDATE()),
('Nettoyer le bureau', 'Ranger les documents et organiser les tiroirs', 1, 1, GETDATE()),
('Mettre à jour le CV', 'Ajouter les derniers projets réalisés', 0, 1, GETDATE()),
('Lire un article technique', 'Se tenir à jour sur les nouvelles technologies', 0, 1, GETDATE()),
('Faire les courses', 'Acheter fruits, légumes et lait', 0, 1, GETDATE());

