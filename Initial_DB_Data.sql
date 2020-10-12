/* Add Initial Data To DataBase */

USE [|DataDirectory|\FineWines.mdf]

/*

    I used a site provided by one of the team members to choose between different
    types of grapes for Fine Wine. I also got the properties of the grapes from that
    site which is useful as it indicates the wine type and properties of the wines in
    which these grapes will be used.

*/

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

/*

    Accoriding to a certain source, a grape vine can produce up to 40 clusters of
    grapes which adds up to approx 100 x 40 which is 4000 grapes per vine. Another
    source states that a single vine may produce up to 10 bottles of wine.

    According to this research, I will create random data for the grape harvest.

    I am using the Amount_Planted field to account for the amount of grape vines planted,
    as grapes cannot be planted and it would not make sence, if you are unhappy with this,
    it can in some sence be seen as a grape that is planted and that produces more grapes.

    Assuming Fine-Wines makes equal amounts of their wine, they have equal amount of vines
    for each type of grape.

*/

/* H A R V E S T */ --!!!!!!!!!! CHECK HARVEST_IDs !!!!!!!!!!--
-- Airen
INSERT INTO HARVEST (Harvest_ID, Grape_ID, Amount_Planted, Date_Planted, Estimated_Harvest, Actual Harvest)
VALUES ('str', 'aire2183', 25, 2019, 92000, 91028);
-- Arneis
INSERT INTO HARVEST (Harvest_ID, Grape_ID, Amount_Planted, Date_Planted, Estimated_Harvest, Actual Harvest)
VALUES ('str', 'arne1208', 20, 2019, 64740, 64293);
-- Catarratto
INSERT INTO HARVEST (Harvest_ID, Grape_ID, Amount_Planted, Date_Planted, Estimated_Harvest, Actual Harvest)
VALUES ('str', 'cata0281', 21, 2019, 72570, 54783);
-- Chardonnay
INSERT INTO HARVEST (Harvest_ID, Grape_ID, Amount_Planted, Date_Planted, Estimated_Harvest, Actual Harvest)
VALUES ('str', 'char8372', 20, 2019, 68080, 65743);
-- Furmint
INSERT INTO HARVEST (Harvest_ID, Grape_ID, Amount_Planted, Date_Planted, Estimated_Harvest, Actual Harvest)
VALUES ('str', 'furm9463', 20, 2019, 65320, 64301);
-- Agiorgiriko
INSERT INTO HARVEST (Harvest_ID, Grape_ID, Amount_Planted, Date_Planted, Estimated_Harvest, Actual Harvest)
VALUES ('str', 'agio7186', 22, 2019, 76070, 76124);
-- Brachetto
INSERT INTO HARVEST (Harvest_ID, Grape_ID, Amount_Planted, Date_Planted, Estimated_Harvest, Actual Harvest)
VALUES ('str', 'brac9270', 20, 2019, 66200, 65491);
-- Ciliegiolo
INSERT INTO HARVEST (Harvest_ID, Grape_ID, Amount_Planted, Date_Planted, Estimated_Harvest, Actual Harvest)
VALUES ('str', 'cili0831', 20, 2019, 63450, 63892);
-- Corvina
INSERT INTO HARVEST (Harvest_ID, Grape_ID, Amount_Planted, Date_Planted, Estimated_Harvest, Actual Harvest)
VALUES ('str', 'corv1229', 23, 2019, 79833, 78932);
-- Merlot
INSERT INTO HARVEST (Harvest_ID, Grape_ID, Amount_Planted, Date_Planted, Estimated_Harvest, Actual Harvest)
VALUES ('str', 'merl9010', 21, 2019, 72340, 72507);

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