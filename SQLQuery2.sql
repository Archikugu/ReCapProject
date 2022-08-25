INSERT INTO Users(FirstName,LastName,Email,Password) VALUES 
	('Engin','Demiroğ','engindemirog@gmail.com','12345'),
	('Gökhan','Gök','engokhangok@gmail.com','12345'),
	('Ali','Veli','aliveli@gmail.com','12345'),
	('Mustafa','Öztürk','mustafaozturk@gmail.com','12345'),
	('Sultan','Yiğit','sultanyigit@gmail.com','12345');


INSERT INTO Customers(UserId,CompanyName) VALUES 
	(1,'Audi Otomobil'),
	(2,'Hyundai Otomobil'),
	(3,'Bmw Otomobil'),
	(4,'Nissan Otomobil'),
	(5,'Cars otomobil');


INSERT INTO Rentals(CarId,CustomerId,RentDate,ReturnDate) VALUES 
(1,1,'2022-08-22 15:00:01','2022-08-24 16:16:05'),
(2,2,'2022-08-24 10:34:09',null),
(3,3,'2022-07-14 14:39:23','2022-08-14 12:02:48'),
(4,4,'2022-08-20 17:45:53',null),
(5,5,'2022-06-12 11:12:38','2022-07-16 18:01:41');