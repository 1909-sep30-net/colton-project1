--INSERTING OUR LOCATIONS
INSERT INTO Location (Address)
Values ('1001 Center St, Arlington TX, 77031'),
		('223 Crest Hill Dr., Conroe TX, 77301'),
		('10003 Allegheny Dr., Dallas TX, 75229');

SELECT * FROM Location

--INSERTING PRODUCTS INTO DB
INSERT INTO Products(Name, Price)
VALUES ('Wand', 500), 
		('Sword', 300),
		('Sheild', 350)



SELECT * FROM Inventory

--INSERTED INVENTORY FOR LOCATION 1, 2, 3
INSERT INTO Inventory(LocationId, ProductId, Quantity)
VALUES (1, 1, 20),
		(1, 2, 25),
		(1, 3, 30),
		(2, 1, 20),
		(2, 2, 25),
		(2, 3, 30),
		(3, 1, 20),
		(3, 2, 35),
		(3, 3, 30);
--INSERTING FIRST CUSTOMER
INSERT INTO Customers(FirstName, LastName)
VALUES ('Colton', 'Clary');
	
SELECT * FROM Customers;

