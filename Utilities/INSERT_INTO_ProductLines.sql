declare @description  varchar(max);
set @description = 'Lorem ipsum dolor, sit amet consectetur adipisicing elit. Numquam animi nobis earum, quisquam facere aperiam maiores tempora modi';


INSERT INTO ProductLines ([Title], [Description]) VALUES ('All Time Classic', @description)

INSERT INTO ProductLines ([Title], [Description]) VALUES ('Berry Special', @description)

INSERT INTO ProductLines ([Title], [Description]) VALUES ('Fruit Blast', @description)
