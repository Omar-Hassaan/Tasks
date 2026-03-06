CREATE DATABASE Barwon_Health
GO

USE Barwon_Health
GO

CREATE TABLE Doctor (
    DoctorID INT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Email VARCHAR(100),
    Phone VARCHAR(20),
    Specialty VARCHAR(100) NOT NULL,
    YearsExperience INT CHECK (YearsExperience >= 0)
);
GO

CREATE TABLE Patient (
    UR_Number INT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Address VARCHAR(200),
    Age INT CHECK (Age >= 0),
    Email VARCHAR(100),
    Phone VARCHAR(20),
    MedicareNumber VARCHAR(50),

    PrimaryDoctorID INT NOT NULL,

    CONSTRAINT FK_Patient_Doctor
    FOREIGN KEY (PrimaryDoctorID)
    REFERENCES Doctor(DoctorID)
);
GO

CREATE TABLE PharmaceuticalCompany (
    CompanyName VARCHAR(100) PRIMARY KEY,
    Address VARCHAR(200),
    Phone VARCHAR(20)
);
GO

CREATE TABLE Drug (
    DrugID INT PRIMARY KEY,
    TradeName VARCHAR(100) NOT NULL,
    DrugStrength VARCHAR(50) NOT NULL,
    CompanyName VARCHAR(100) NOT NULL,

    CONSTRAINT FK_Drug_Company
    FOREIGN KEY (CompanyName)
    REFERENCES PharmaceuticalCompany(CompanyName)
    ON DELETE CASCADE
);
GO

CREATE TABLE Prescription (
    PrescriptionDate DATE NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0),

    PatientURNumber INT NOT NULL,
    DoctorID INT NOT NULL,
    DrugID INT NOT NULL,

    CONSTRAINT PK_Prescription
    PRIMARY KEY (PatientURNumber, DoctorID, DrugID),

    CONSTRAINT FK_Prescription_Patient
    FOREIGN KEY (PatientURNumber)
    REFERENCES Patient(UR_Number),

    CONSTRAINT FK_Prescription_Doctor
    FOREIGN KEY (DoctorID)
    REFERENCES Doctor(DoctorID),

    CONSTRAINT FK_Prescription_Drug
    FOREIGN KEY (DrugID)
    REFERENCES Drug(DrugID)
);
GO

INSERT INTO Doctor VALUES
(101,'Dr.Ahmed','doc1@mail.com','01211111111','Cardiology',10),
(102,'Dr.Mohamed','doc2@mail.com','01222222222','Dermatology',8),
(103,'Dr.Sara','doc3@mail.com','01233333333','Neurology',12),
(104,'Dr.Omar','doc4@mail.com','01244444444','Orthopedic',15),
(105,'Dr.Mona','doc5@mail.com','01255555555','Pediatrics',7),
(106,'Dr.Ali','doc6@mail.com','01266666666','Dentistry',6),
(107,'Dr.Heba','doc7@mail.com','01277777777','Cardiology',9),
(108,'Dr.Khaled','doc8@mail.com','01288888888','ENT',11),
(109,'Dr.Nour','doc9@mail.com','01299999999','Urology',13),
(110,'Dr.Youssef','doc10@mail.com','01300000000','Surgery',14);
GO

INSERT INTO Patient VALUES
(1,'Ahmed Ali','Cairo',25,'ahmed@gmail.com','01011111111','MC1001',101),
(2,'Mohamed Samy','Giza',30,'mohamed@gmail.com','01022222222','MC1002',102),
(3,'Sara Adel','Alex',22,'sara@gmail.com','01033333333',NULL,103),
(4,'Omar Khaled','Tanta',28,'omar@gmail.com','01044444444','MC1004',104),
(5,'Mona Hassan','Mansoura',35,'mona@gmail.com','01055555555','MC1005',105),
(6,'Ali Mahmoud','Zagazig',40,'ali@gmail.com','01066666666',NULL,106),
(7,'Heba Fathy','Cairo',27,'heba@gmail.com','01077777777','MC1007',107),
(8,'Khaled Nabil','Giza',32,'khaled@gmail.com','01088888888','MC1008',108),
(9,'Nour Ahmed','Alex',24,'nour@gmail.com','01099999999',NULL,109),
(10,'Youssef Tarek','Tanta',29,'youssef@gmail.com','01100000000','MC1010',110);
GO

INSERT INTO PharmaceuticalCompany VALUES
('Pfizer','USA','111111111'),
('Novartis','Switzerland','222222222'),
('Roche','Switzerland','333333333'),
('Merck','Germany','444444444'),
('Sanofi','France','555555555'),
('AstraZeneca','UK','666666666'),
('GSK','UK','777777777'),
('Bayer','Germany','888888888'),
('AbbVie','USA','999999999'),
('Takeda','Japan','101010101');
GO

INSERT INTO Drug VALUES
(1,'Panadol','500mg','Pfizer'),
(2,'Brufen','400mg','Novartis'),
(3,'Aspirin','100mg','Bayer'),
(4,'Augmentin','625mg','GSK'),
(5,'Lipitor','20mg','Pfizer'),
(6,'Voltaren','50mg','Novartis'),
(7,'Zithromax','250mg','Pfizer'),
(8,'Crestor','10mg','Roche'),
(9,'Amoxil','500mg','Sanofi'),
(10,'Plavix','75mg','Bayer');
GO

INSERT INTO Prescription VALUES
('2026-01-01',2,1,101,1),
('2026-01-02',1,2,102,2),
('2026-01-03',3,3,103,3),
('2026-01-04',2,4,104,4),
('2026-01-05',1,5,105,5),
('2026-01-06',2,6,106,6),
('2026-01-07',1,7,107,7),
('2026-01-08',4,8,108,8),
('2026-01-09',2,9,109,9),
('2026-01-10',1,10,110,10);