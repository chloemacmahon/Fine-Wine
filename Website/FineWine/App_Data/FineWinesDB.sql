CREATE TABLE GRAPE(
	Grape_ID	varchar(15)	PRIMARY KEY,
	Name		varchar(20),
	Grape_Type 	varchar(25),
	Description varchar(MAX)
	);
	
CREATE TABLE WINE(
	Wine_ID 	varchar(15)	PRIMARY KEY,
	Grape_ID 	varchar(15) FOREIGN KEY REFERENCES GRAPE(Grape_ID),
	Name		varchar(20),
	Wine_Type	varchar(25),
	Description varchar(MAX)
	);
	
CREATE TABLE HARVEST(
	Harvest_ID			varchar(15)	PRIMARY	KEY,
	Grape_ID 			varchar(15) FOREIGN KEY REFERENCES GRAPE(Grape_ID),
	Amount_Planted		int,
	Date_Planted		date,
	Estimated_Harvest	int,
	Actual_Harvest		int
	);
	
CREATE TABLE WINE_PRODUCTION(
	Wine_ID					varchar(15)		NOT NULL,
	Harvest_ID 				varchar(15)		NOT NULL,
	Estimated_Production	int,
	Actual_Production		int,
	Maturation_Period		int,
	CONSTRAINT PK_Wine_Production PRIMARY KEY(Wine_ID,Harvest_ID),
	FOREIGN KEY (Wine_ID) REFERENCES WINE(Wine_ID),
	FOREIGN KEY (Harvest_ID) REFERENCES HARVEST(Harvest_ID)
);

CREATE TABLE STOCK(
	Stock_ID 		varchar(15)	PRIMARY KEY,
	Wine_ID 		varchar(15)	FOREIGN KEY REFERENCES WINE(Wine_ID),
	Production_Year date,
	Stock_On_Hand 	int,
	Stock_Sold 		int,
	Unit_Price 		money,
	Selling_Price 	money
);

CREATE TABLE COUNTRY(
  Country_ID	int		IDENTITY(1,1) PRIMARY KEY,
  Name			varchar(30)
);

CREATE TABLE REGION(
	Region_ID	int		IDENTITY(1,1) PRIMARY KEY,
	Country_ID	int  	FOREIGN KEY REFERENCES COUNTRY(Country_ID),
	Name		varchar(30)	 NOT NULL
);

CREATE TABLE CITY_TOWN(
	City_Town_ID	int		IDENTITY(1,1) PRIMARY KEY,
	Region_ID		int		FOREIGN KEY REFERENCES REGION(Region_ID),
	Name			varchar(30)	NOT NULL
);

CREATE TABLE ADDRESS(
	Address_ID		varchar(15)		PRIMARY KEY,
	Country_ID		int				FOREIGN KEY REFERENCES COUNTRY(Country_ID),
	Region_ID		int				FOREIGN KEY REFERENCES REGION(Region_ID),	City_Town_ID	int				FOREIGN KEY REFERENCES CITY_TOWN(City_Town_ID),
	Street_Number	int,
	Street_Name		varchar(25),
	Zip_Code		varchar(15)
);

CREATE TABLE BUSINESS(
	Business_ID		varchar(15)	PRIMARY KEY,
	Address_ID		varchar(15)	FOREIGN KEY REFERENCES ADDRESS(Address_ID),
	Business_Name	varchar(25),
	Password 		varchar(15)
);

CREATE TABLE ADMIN(
	Admin_ID		varchar(15) PRIMARY KEY,
	User_Name		varchar(25),
	User_Password	varchar(15)
);

CREATE TABLE LOGIN(
	Login_ID	int			IDENTITY(1,1) PRIMARY KEY,
	Admin_ID	varchar(15) NULL,
	Business_ID	varchar(15) NULL,
	Account_Type char(1) DEFAULT 'B',
	FOREIGN KEY (Admin_ID) REFERENCES Admin(Admin_ID),
	FOREIGN KEY (Business_ID) REFERENCES Business(Business_ID)
);

CREATE TABLE SALES_ORDER(
	Sales_Order_ID	varchar(15)	PRIMARY KEY,
	Business_ID		varchar(15),
	Sales_Date		date,
	Sales_Time		time,
	Quantity_Bought	int,
	Sales_Total		money
);

CREATE TABLE SALES(
	Sales_Order_ID	varchar(15),
	Stock_ID		varchar(15),
	CONSTRAINT PK_Sales PRIMARY KEY(Sales_Order_ID, Stock_ID),
	FOREIGN KEY (Sales_Order_ID) REFERENCES Sales_Order(Sales_Order_ID),
	FOREIGN KEY (Stock_ID) REFERENCES Stock(Stock_ID)
);



