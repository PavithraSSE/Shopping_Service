INSERT INTO Category( Name)
VALUES ( 'Dress'),( 'Grocery'),('Mobile'),( 'Beauty')

INSERT INTO SubCategory(CategoryId, Name)
VALUES (1, 'Sarees'),(1,'Tops'),(1,'Jeans'),(2,'Rice and Rice Products'),(2,'Atta and Flour'),(3,'Basic Phone'),(3,'Anroid Phone')
,(4,'Body Lotion'),(4, 'Face Creams')

INSERT INTO Item(SubCategoryId,Name,Description)
VALUES(1,'Silk Sarees', 'Hard and Softsilks are available'),
      (1,'Cotton Sarees','Pure and semi cotton sarees are available'),
	  (2,'Leggin Tops','All colors are available'),
	  (2,'Jean Tops','All colors are available'),
	  (3,'Ladies Jeans','All Types are available'),
	  (3,'Boys Jeans','All Types are available'),
	  (4,'Ponni Rice','Good Quality'),
	  (4,'Pulav','Good Quality'),
	  (5,'Ragi Flour','Good Quality'),
	  (5,'Rice Atta','Good Quality'),
	  (6,'Nokia','Price differ based on model'),
	  (7,'Samsung','Price differ based on model'),
	  (8,'Himalaya','Good for dry and oily skin'),
	  (9,'Ponds','Good for oily skin')


