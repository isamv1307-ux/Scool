CREATE DATABASE SchoolEquipmentDB;
GO
USE SchoolEquipmentDB;
GO
CREATE TABLE Users(UserID int identity primary key,Login nvarchar(50) not null unique,Password nvarchar(255) not null,FullName nvarchar(150) not null);
CREATE TABLE Employees(EmployeeID int identity primary key,FullName nvarchar(150) not null,Position nvarchar(100),Department nvarchar(100),Phone nvarchar(30));
CREATE TABLE Equipment(EquipmentID int identity primary key,Name nvarchar(150) not null,Type nvarchar(100),InventoryNumber nvarchar(50) unique not null,PurchaseDate date,Status nvarchar(50),Location nvarchar(100),EmployeeID int null foreign key references Employees(EmployeeID));
CREATE TABLE Components(ComponentID int identity primary key,Name nvarchar(150) not null,Type nvarchar(100),Quantity int,Unit nvarchar(50),Price decimal(10,2),Note nvarchar(255));
CREATE TABLE Issuance(IssuanceID int identity primary key,EmployeeID int foreign key references Employees(EmployeeID),EquipmentID int foreign key references Equipment(EquipmentID),IssueDate date,ReturnDate date null,IssuanceStatus nvarchar(50),Comment nvarchar(255));
CREATE TABLE Logs(LogID int identity primary key,UserID int null foreign key references Users(UserID),Action nvarchar(255),ActionDate datetime default getdate());
INSERT INTO Users(Login,Password,FullName) VALUES('admin','admin',N'Мантаков Ислам Мадатович');
INSERT INTO Employees(FullName,Position,Department,Phone) VALUES
(N'Москвина Светлана Олеговна',N'Директор',N'Администрация','111-11-11'),(N'Иванов Алексей Петрович',N'Системный администратор',N'ИТ-кабинет','222-22-22'),(N'Петрова Анна Сергеевна',N'Учитель',N'Кабинет 21','333-33-33'),(N'Сидорова Марина Викторовна',N'Бухгалтер',N'Бухгалтерия','444-44-44'),(N'Кузнецов Дмитрий Андреевич',N'Ответственный за материально-техническое обеспечение',N'Склад','555-55-55');
INSERT INTO Equipment(Name,Type,InventoryNumber,PurchaseDate,Status,Location,EmployeeID) VALUES
(N'Компьютер Lenovo ThinkCentre',N'Компьютер','INV-001','2023-01-10',N'Исправна',N'Кабинет 12',2),(N'Ноутбук HP ProBook',N'Ноутбук','INV-002','2022-03-01',N'В ремонте',N'Кабинет 14',3),(N'Принтер Canon',N'Принтер','INV-003','2021-09-19',N'Исправна',N'Бухгалтерия',4),(N'МФУ Kyocera',N'МФУ','INV-004','2020-02-20',N'Неисправна',N'Учительская',null),(N'Проектор Epson',N'Проектор','INV-005','2024-05-11',N'Исправна',N'Актовый зал',3),(N'Интерактивная доска Smart Board',N'Интерактивная доска','INV-006','2024-09-01',N'Исправна',N'Кабинет 10',3),(N'Коммутатор TP-Link',N'Сетевое оборудование','INV-007','2023-07-17',N'Исправна',N'Серверная',2),(N'Монитор Samsung',N'Монитор','INV-008','2021-08-20',N'Списана',N'Склад',5),(N'Системный блок Acer',N'Компьютер','INV-009','2022-11-03',N'Исправна',N'Кабинет 17',2),(N'Ноутбук Lenovo IdeaPad',N'Ноутбук','INV-010','2025-01-16',N'Исправна',N'Кабинет 18',1);
INSERT INTO Components(Name,Type,Quantity,Unit,Price,Note) VALUES
(N'Оперативная память DDR4',N'Память',14,N'шт',3500,N''),(N'SSD 240 GB',N'Накопитель',8,N'шт',2900,N''),(N'Кабель HDMI',N'Кабель',20,N'шт',450,N''),(N'Кабель питания',N'Кабель',15,N'шт',300,N''),(N'Картридж Canon',N'Расходники',4,N'шт',2200,N''),(N'Мышь USB',N'Периферия',25,N'шт',500,N''),(N'Клавиатура USB',N'Периферия',17,N'шт',950,N''),(N'Блок питания',N'Запчасти',2,N'шт',3100,N'Заканчиваются');
