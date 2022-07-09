 --CREATE DATABASE DeltaXDB

--Table creation Commands
 --CREATE TABLE tblMaster
 --(
 --    MasterID int IDENTITY(1,1) PRIMARY KEY,
 --    MasterName varchar(50) NOT NULL,
 --    MasterType VARCHAR(50) NOT NULL
 --)

 --CREATE TABLE tblActor
 --(  
 --    ActorID int IDENTITY(1,1) PRIMARY KEY,
 --    ActorName nvarchar(50) NOT NULL,
 --    Bio varchar(200) NOT NULL,
 --    DateOfBirth DATE NULL,
 --    Gender int NULL
 --);

 --CREATE TABLE tblProducer
 --(  
 --    ProducerID int IDENTITY(1,1) PRIMARY KEY,
 --    ProducerName nvarchar(50) NOT NULL,
 --    Bio varchar(200) NOT NULL,
 --    DateOfBirth DATE NULL,
 --    Gender int NULL,
 --    ProductionHouse varchar(50) NOT NULL
 --);

 --CREATE TABLE tblMovie
 --(  
 --    MovieID int IDENTITY(1,1) PRIMARY KEY,
 --    MovieName nvarchar(50) NOT NULL,
 --    Plot nvarchar(max) NULL,
 --    Poster nvarchar(max) NOT NULL,
 --    ReleaseDate date,
 --    ProducerID int NOT NULL
 --);

 --CREATE TABLE tblMovieDetails
 --(  
 --    MovieDetailsID int IDENTITY(1,1) PRIMARY KEY,
 --    MovieID int NOT NULL,
 --    ActorID int NOT NULL
 --);


--Adding foreign key relations
 --ALTER TABLE tblMovie    
 --ADD CONSTRAINT FK_tblMovie_tblProducer FOREIGN KEY (ProducerID)     
 --REFERENCES tblProducer (ProducerID)     
 --ON DELETE CASCADE    
 --ON UPDATE CASCADE

 --ALTER TABLE tblMovieDetails    
 --ADD CONSTRAINT FK_tblMovieDetails_tblMovie FOREIGN KEY (MovieID)     
 --REFERENCES tblMovie (MovieID)     
 --ON DELETE CASCADE    
 --ON UPDATE CASCADE

 --ALTER TABLE tblMovieDetails    
 --ADD CONSTRAINT FK_tblMovieDetails_tblActor FOREIGN KEY (ActorID)     
 --REFERENCES tblActor (ActorID)     
 --ON DELETE CASCADE    
 --ON UPDATE CASCADE


--Inserting tblmaster
 --INSERT INTO tblMaster VALUES
 --('Male','Gender'),
 --('Female','Gender'),
 --('Others','Gender')
 
 
 
 
 
 -- insert into tblProducer values('Niki Marvin','Shawshank Redemption Producer',GETDATE(),1,'Warner Bros')

 --insert into tblMovie values('Shawshank Redemption','Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency','Shawshank Redemption poster',GETDATE(),1)

 --insert into tblActor values('Tim Robbins','Shawshank Redemption actor',GETDATE(),1),('Morgon Freeman','Shawshank Redemption actor',GETDATE(),1)
 
 --insert into tblMovieDetails values (1,1),(1,2)
 
 
 
