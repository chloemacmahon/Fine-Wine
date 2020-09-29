/* Add Initial Data To DataBase */

/* G R A P E S */
/* White */
-- Airen
INSERT INTO GRAPE (Grape_ID, Name, Grape_Type, Description)
VALUES ('aire2183', 'Airen', 'White Grape', 'Dry');
-- Arneis
INSERT INTO GRAPE (Grape_ID, Name, Grape_Type, Description)
VALUES ('arne1208', 'Arneis', 'White Grape', 'Crisp, Floral');
-- Catarratto
INSERT INTO GRAPE (Grape_ID, Name, Grape_Type, Description)
VALUES ('cata0281', 'Catarratto', 'White Grape', 'Acidity & Citrus-, Melon-, Passion Fruit Aromas');
-- Chardonnay
INSERT INTO GRAPE (Grape_ID, Name, Grape_Type, Description)
VALUES ('char8372', 'Chardonnay', 'White Grape', 'Crisp, Fruit Flavor');
-- Furmint
INSERT INTO GRAPE (Grape_ID, Name, Grape_Type, Description)
VALUES ('furm9463', 'Furmint', 'White Grape', 'Acidity, Dry Varietal, Sweet Dessert Wine');
/* Red */
-- Agiorgitiko
INSERT INTO GRAPE (Grape_ID, Name, Grape_Type, Description)
VALUES ('agio7186', 'Agiorgitiko', 'Red Grape', 'Fruit-Filled');
-- Brachetto
INSERT INTO GRAPE (Grape_ID, Name, Grape_Type, Description)
VALUES ('brac9270', 'Brachetto', 'Red Grape', 'Low-Alcohol, Aromatic, Light Bodied');
-- Ciliegiolo
INSERT INTO GRAPE (Grape_ID, Name, Grape_Type, Description)
VALUES ('cili0831', 'Ciliegiolo', 'Red Grape', 'Cherry Aroma, Light Meduim Bodied Varietal');
-- Corvina
INSERT INTO GRAPE (Grape_ID, Name, Grape_Type, Description)
VALUES ('corv1229', 'Corvina', 'Red Grape', 'Acidity, Cherry and Herbaceous Flavors');
-- Merlot
INSERT INTO GRAPE (Grape_ID, Name, Grape_Type, Description)
VALUES ('merl9010', 'Merlot', 'Red Grape', 'Soft Tannis, Intense Fruit Flavors');

/* W I N E S */
-- Dry White
INSERT INTO WINE (Wine_ID, Grape_ID, Name, Wine_Type, Description)
VALUES ('dryw8758', 'aire2183', 'Dry White', 'White Wine', 'A dry white wine.');
-- White Floral
INSERT INTO WINE (Wine_ID, Grape_ID, Name, Wine_Type, Description)
VALUES ('whit1290', 'arne1208', 'White Floral', 'White Wine', 'A crisp, floral white wine.');
-- White Fruit
INSERT INTO WINE (Wine_ID, Grape_ID, Name, Wine_Type, Description)
VALUES ('whit0927', 'cata0281', 'White Fruit', 'White Wine', 'An acidic wine with a fruity aroma.');
-- Chardonnay Crisp
INSERT INTO WINE (Wine_ID, Grape_ID, Name, Wine_Type, Description)
VALUES ('char2188', 'char8372', 'Chardonnay Crisp', 'White Wine', 'A crisp, fruity flavored chardonnay.');
-- Dry Furmint
INSERT INTO WINE (Wine_ID, Grape_ID, Name, Wine_Type, Description)
VALUES ('dryf2190', 'furm9463', 'Dry Furmint', 'White Wine', 'A dry, acidic yet sweet dessert wine.');
-- Red Fruit
INSERT INTO WINE (Wine_ID, Grape_ID, Name, Wine_Type, Description)
VALUES ('redf9271', 'agio7186', 'Red Fruit', 'Red Wine', 'A fruit-filled red wine.');
-- Low Red
INSERT INTO WINE (Wine_ID, Grape_ID, Name, Wine_Type, Description)
VALUES ('lowr1270', 'brac9270', 'Low Red', 'Red Wine', 'A low-alcohol, light bodied wine.');
-- Cherry I
INSERT INTO WINE (Wine_ID, Grape_ID, Name, Wine_Type, Description)
VALUES ('cher1208', 'cili0831', 'Cherry I', 'Red Wine', 'A cherry aroma, light meduim bodied wine.');
-- Cherry II
INSERT INTO WINE (Wine_ID, Grape_ID, Name, Wine_Type, Description)
VALUES ('cher0297', 'corv1229', 'Cherry II', 'Red Wine', 'An acidic, cherry and herbaceous flavored wine.');
-- Red Merlot
INSERT INTO WINE (Wine_ID, Grape_ID, Name, Wine_Type, Description)
VALUES ('redm6253', 'merl9010', 'Red Merlot', 'Red Wine', 'Merlot with a soft tannis & intense fruit flavor.');

/* S T O C K S */
-- Dry White
INSERT INTO STOCK (Stock_ID, Wine_ID, Production_Year, Stock_On_Hand, Stock_Sold, Unit_Price, Selling_Price)
VALUES ('dryw2011', 'dryw8758', 2011, 102, 23, 60.00, 90.00);
-- White Floral
INSERT INTO STOCK (Stock_ID, Wine_ID, Production_Year, Stock_On_Hand, Stock_Sold, Unit_Price, Selling_Price)
VALUES ('whit2012', 'whit1290', 2012, 94, 31, 75.00, 105.00);
-- White Fruit
INSERT INTO STOCK (Stock_ID, Wine_ID, Production_Year, Stock_On_Hand, Stock_Sold, Unit_Price, Selling_Price)
VALUES ('whit2010', 'whit0927', 2010, 113, 43, 50.00, 80.00);
-- Chardonnay Crisp
INSERT INTO STOCK (Stock_ID, Wine_ID, Production_Year, Stock_On_Hand, Stock_Sold, Unit_Price, Selling_Price)
VALUES ('char2011', 'char2188', 2011, 221, 53, 30.00, 50.00);
-- Dry Furmint
INSERT INTO STOCK (Stock_ID, Wine_ID, Production_Year, Stock_On_Hand, Stock_Sold, Unit_Price, Selling_Price)
VALUES ('dryf2012', 'dryf2190', 2012, 81, 47, 55.00, 80.00);
-- Red Fruit
INSERT INTO STOCK (Stock_ID, Wine_ID, Production_Year, Stock_On_Hand, Stock_Sold, Unit_Price, Selling_Price)
VALUES ('redf2011', 'redf9271', 2011, 132, 65, 60.00, 90.00);
-- Low Red
INSERT INTO STOCK (Stock_ID, Wine_ID, Production_Year, Stock_On_Hand, Stock_Sold, Unit_Price, Selling_Price)
VALUES ('lowr2011', 'lowr1270', 2011, 78, 22, 40.00, 65.00);
-- Cherry I
INSERT INTO STOCK (Stock_ID, Wine_ID, Production_Year, Stock_On_Hand, Stock_Sold, Unit_Price, Selling_Price)
VALUES ('cher2010', 'cher1208', 2010, 112, 34, 55.00, 75.00);
-- Cherry II
INSERT INTO STOCK (Stock_ID, Wine_ID, Production_Year, Stock_On_Hand, Stock_Sold, Unit_Price, Selling_Price)
VALUES ('cher2013', 'cher0297', 2013, 82, 19, 60.00, 85.00);
-- Red Merlot
INSERT INTO STOCK (Stock_ID, Wine_ID, Production_Year, Stock_On_Hand, Stock_Sold, Unit_Price, Selling_Price)
VALUES ('redm2010', 'redm6253', 2010, 231, 122, 30.00, 50.00);

-- still busy hey...