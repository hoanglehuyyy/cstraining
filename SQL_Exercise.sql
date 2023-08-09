-- Dimension module:
-- 1. Get information about United Kingdom customers with Country Region Code of GB including columns:
-- FullName, BirthDate, Gender, EmailAddress, Education (English), Phone, AddressLine1, AddressLine2

SELECT (FirstName + ' ' + ISNULL(MiddleName, '') + ' ' + LastName) AS FullName, BirthDate,
IIF(Gender = 'F', 'Female', IIF(Gender = 'M', 'Male', Gender)) AS Gender
, EmailAddress, EnglishEducation AS Education, Phone, AddressLine1, AddressLine2
FROM dbo.DimCustomer customers, dbo.DimGeography geo
WHERE customers.GeographyKey = geo.GeographyKey
    AND geo.CountryRegionCode = 'GB';

-- 2. Total number of customers by country includes 2 columns: CountryName, TotalCustomer

SELECT geo.EnglishCountryRegionName AS CountryName, COUNT(customers.CustomerKey) AS TotalCustomers
FROM dbo.DimCustomer customers, dbo.DimGeography geo
WHERE customers.GeographyKey = geo.GeographyKey
GROUP BY geo.CountryRegionCode, geo.EnglishCountryRegionName;

-- 3. Get the top 100 products of the highest selling price (ListPrice) including the following columns:
-- ProductName (English), ModelName, ProductLine, ProductCategoryName (English),
-- ProductSubcategoryName (English), DealerPrice, ListPrice, Color, Description (English)

SELECT TOP (100) EnglishProductName AS ProductName, ModelName, ProductLine, EnglishProductCategoryName AS CategoryName,
    EnglishProductSubcategoryName AS ProductSubCategoryName, DealerPrice, ListPrice, Color, EnglishDescription AS Description
FROM dbo.DimProduct product
JOIN dbo.DimProductSubcategory subcategory ON product.ProductSubcategoryKey = subcategory.ProductSubcategoryKey
JOIN dbo.DimProductCategory category ON subcategory.ProductCategoryKey = category.ProductCategoryKey
ORDER BY ListPrice DESC;

-- 4. Based on the financial table (FactFinace),
-- calculate the total amount of transactions according to each specific type of accounting compared
-- between the three regions France, Germany, Australia, including the following columns:
-- AccountDescription, France, Germany, Australia

SELECT AccountDescription, SUM(France) AS France, SUM(Germany) AS Germany, SUM(Australia) AS Australia
FROM (
    SELECT account.AccountKey, account.AccountDescription, finance.Amount, organization.OrganizationName
    FROM dbo.FactFinance finance
    JOIN dbo.DimAccount account ON finance.AccountKey = account.AccountKey
    JOIN dbo.DimOrganization organization ON finance.OrganizationKey = organization.OrganizationKey
) AS SourceTable
PIVOT (
    SUM(Amount)
    FOR OrganizationName IN (France, Germany, Australia)
) AS PivotTable
GROUP BY AccountDescription, AccountKey;

-- 5. Get the latest stock information of all products including the following columns:
-- ProductKey, ProductName (English), ModelName, ProductCategoryName, ProductSubcategoryName, UnitsBalance, UnitCost

SELECT p.ProductKey, EnglishProductName AS ProductName, ModelName, EnglishProductCategoryName AS ProductCategoryName,
    EnglishProductSubcategoryName AS ProductSubCategoryName, UnitsBalance, UnitCost
FROM dbo.FactProductInventory pi
JOIN dbo.DimProduct p ON pi.ProductKey = p.ProductKey
JOIN dbo.DimProductSubcategory ps ON p.ProductSubcategoryKey = ps.ProductSubcategoryKey
JOIN dbo.DimProductCategory pc ON ps.ProductCategoryKey = pc.ProductCategoryKey
WHERE DateKey = (
    SELECT MAX(DateKey)
    FROM dbo.FactProductInventory pi1
    WHERE pi1.ProductKey = pi.ProductKey
);

-- 6. Let's get the inventory information of the 10 products with the highest inventory value including the following columns:
-- ProductName (English), ModelName, ProductCategoryName, ProductSubcategoryName, UnitsBalance, UnitCost

SELECT TOP (10) EnglishProductName AS ProductName, ModelName, EnglishProductCategoryName AS ProductCategoryName,
    EnglishProductSubcategoryName AS ProductSubCategoryName, UnitsBalance, UnitCost
FROM dbo.FactProductInventory pi
JOIN dbo.DimProduct p ON pi.ProductKey = p.ProductKey
JOIN dbo.DimProductSubcategory ps ON p.ProductSubcategoryKey = ps.ProductSubcategoryKey
JOIN dbo.DimProductCategory pc ON ps.ProductCategoryKey = pc.ProductCategoryKey
WHERE pi.DateKey = (
    SELECT MAX(DateKey)
    FROM dbo.FactProductInventory pi1
    WHERE pi1.ProductKey = pi.ProductKey
)
ORDER BY UnitsBalance * UnitCost DESC;

-- 8. Get the Internet Sales invoice details of the product whose English Name is "Road-150 Red, 48" including the following columns:
-- SalesOrderNumber, SalesOrderLineNumber, CustomerName, ProductName, OrderQuantity, UnitPrice,
-- DiscountAmount, SalesAmount, ProductStandardCost, TotalProductCost

SELECT SalesOrderNumber, SalesOrderLineNumber, (FirstName + ' ' + ISNULL(MiddleName, '') + ' ' + LastName) AS CustomerName,
    EnglishProductName AS ProductName, OrderQuantity, UnitPrice, DiscountAmount, SalesAmount, ProductStandardCost, TotalProductCost
FROM dbo.FactInternetSales fis
JOIN dbo.DimProduct p ON fis.ProductKey = p.ProductKey
JOIN dbo.DimCustomer c ON fis.CustomerKey = c.CustomerKey
WHERE EnglishProductName = 'Road-150 Red, 48';

-- 9. Get information 20 Internet Sales invoices with the highest total payable including the following columns:
-- CustomerName, SalesOrderNumber, CustomerKey, TotalOrderCost

SELECT TOP 20
    c.FirstName + ' ' + ISNULL(c.MiddleName, '') + ' ' + c.LastName AS CustomerName,
    s.SalesOrderNumber,
    c.CustomerKey,
    SUM(s.TotalProductCost) AS TotalOrderCost
FROM dbo.FactInternetSales s
JOIN dbo.DimCustomer c ON s.CustomerKey = c.CustomerKey
GROUP BY c.CustomerKey, c.FirstName, c.MiddleName, c.LastName, s.SalesOrderNumber
ORDER BY TotalOrderCost DESC;

-- 10. Get the top 10 resellers with the highest revenue including the following schools:
-- ResellerName, ResellerKey, TotalQuantity, TotalOrderCost

SELECT TOP 10
    r.ResellerName,
    r.ResellerKey,
    SUM(s.OrderQuantity) AS TotalQuantity,
    SUM(s.TotalProductCost) AS TotalOrderCost
FROM dbo.FactResellerSales s
JOIN dbo.DimReseller r ON s.ResellerKey = r.ResellerKey
GROUP BY r.ResellerName, r.ResellerKey
ORDER BY TotalOrderCost DESC;