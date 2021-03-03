create table Customers
(
	id int identity primary key,
	name varchar(50) not null,
	address varchar(50) not null,
	phone varchar(15) not null,
);

create table Products
(
	id int identity primary key,
	name varchar(50) not null,
	shortname varchar(10) not null,
	description varchar(100) not null,
	category int references productCategories(id) not null,
	price int not null
);

create table Locations
(
	id int identity primary key,
	name varchar(50) not null,
	address varchar(100) not null,
);

create table Orders
(
	id int identity primary key,
	custID int references Customers(id) not null,
	locID int references Locations(id) not null,
	date datetime not null,
);

create table Inventories
(
	id int identity primary key,
	quantity int not null,
	productID int references Products(id) not null,
	locationID int references Locations(id) not null
);

create table OrderItems
(
	id int identity primary key,
	orderID int references orders(id) not null,
	productID int references Products(id) not null,
	quantity int not null,
);

create table cart
(
	id int identity primary key,
	custID int references Customers(id) not null,
	locID int references Locations(id) not null,
	productID int references Products(id) not null,
	quantity int not null,
);

create table productCategories
(
	id int identity primary key,
	category varchar(20) not null
);


---------------------------------------------------------------------------
	

insert into Customers (name, address, phone) values
	('Steve J', '1 Infinite Loop', '(800)-888-8181'),
	('Joseph B','1600 Pennsylvania Ave', '(162)-777-4567'),
	('Alex Honnold', '5100 Las Vegas Blvd S', '(624)-626-8371'),
	('Jerry Seinfeld', '321 Baker St', '(369)-596-5487');

insert into Products (name, shortname, description, price, category) values
	('Black Diamond Cosmo 300 Headlamp', 'BDHead', 'Rechargeable headlamp with night red-light', 7000, 3),
	('Black Diamond Momentum Unisex Climbing Shoes', 'BDShoes', 'An excellent shoe for beginner-climbers', 19000,3),
	('Big Agnes Blacktail 2', 'BTTent', 'Blacktail tents are designed for backpacking in comfort - ultra light and still comfy', 54000, 2),
	('Sea to Summit Aluminum Spork', 'STSSpork', 'Lightweight metal alloy for the toughest of backpacking trips', 2200, 2),
	('prAna Stretch Zion Pant', 'prAnaZion', 'The Classic Pant worn by hikers, climbers, and outdoorspeople alike', 20000, 4),
	('Patagonia Better Sweater Fleece Vest', 'PFVest', 'An iconic full-zip vest that will keep you warm round the fire', 20000, 4),
	('Osprey Manta 24', 'OspManta', 'An all-around great backpack with everything you need for a hike', 32000, 1),
	('Patagonia Black Hole Duffel Bag 55L', 'BHDuffel', 'One of the toughest duffels on the market with the track record to prove it', 26000, 1),
	('La Sportiva Jackal Running Shoes', 'LSJackal', 'Cushioned Running shoes perfect for your next trail-race', 28000, 5),
	('Chaco Z/2 Classic Sandal', 'ChacoZ2', 'Available in a wide array of colors to match any outfit', 20000, 5);

insert into locations (name, address) values
	('New York', '10 Rockefeller Plz, New York City, NY 10020'),
	('Chicago', '201 E Randolph St, Chicago, IL 60602'),
	('Los Angeles', '1313 Disneyland Dr, Anaheim, CA 92802');

insert into orders (custID, locID, date) values
(1, 3, '20210101 10:34:09 AM'),
(2, 1, '20210101 12:34:06 AM'),
(3, 3, '20210103 08:34:49 AM'),
(3, 3, '20210130 06:34:29 PM'),
(4, 2, '20210101 07:34:24 PM'),
(4, 2, '20210108 10:36:00 AM'),
(4, 2, '20210214 11:17:38 PM'),
(4, 2, '20210224 10:34:19 PM');

insert into OrderItems (orderID, productID, quantity) values
(1, 6, 5),
(2, 5, 1),
(2, 1, 2),
(3, 4, 3),
(4, 8, 1),
(5, 5, 1),
(5, 1, 2),
(5, 4, 8),
(5, 8, 1),
(6, 4, 1),
(7, 2, 2),
(8, 7, 1),
(8, 3, 1),
(8, 9, 1);


insert into inventories (locationID, productID, quantity) values
(1, 1, 10),
(1, 5, 25),
(1, 6, 20),
(2, 5, 20),
(2, 1, 8),
(2, 6, 25),
(3, 6, 20),
(3, 4, 15),
(3, 8, 8),
(3, 7, 8),
(3, 3, 4),
(3, 5, 20);

insert into productCategories (category) values
('Backpacks'), ('Camping'), ('Climbing'), ('Clothing'), ('Shoes');


--------------------------------------------------------------------


CREATE PROCEDURE selectalldatabases
AS 
SELECT * FROM customers
SELECT * FROM products
SELECT * FROM locations
SELECT * FROM orders
SELECT * FROM inventories
SELECT * FROM orderitems
select * from cart
select * from productcategories
GO;

--Execute selectalldatabases
exec selectalldatabases;

--drop procedure
drop procedure selectalldatabases;

--Drop all tables
drop table Customers;
drop table Products;
drop table Orders;
drop table Locations;
drop table Inventories;
drop table OrderItems;
drop table productCategories;
drop table cart;