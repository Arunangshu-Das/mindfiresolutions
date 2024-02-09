select * from Product;
select * from Category;
select CategoryGuid from Category where ParentCategoryGuid=NULL;

select c2.CategoryName, c1.CategoryName, p.ProductName from Category c1, Product p, Category c2 where p.CategoryGuid=c1.CategoryGuid and c1.ParentCategoryGuid=c2.CategoryGuid;

WITH cte
AS (
     SELECT c.*
     FROM Category c
     where c.ParentCategoryGuid is null
     
     UNION ALL
     
     SELECT c1.*
     FROM Category c1
     INNER JOIN cte r ON c1.ParentCategoryGuid = r.CategoryGuid
     )
SELECT Distinct c2.CategoryName, c1.CategoryName, p.ProductName from cte c1, Product p, Category c2 where p.CategoryGuid=c1.CategoryGuid and c1.ParentCategoryGuid=c2.CategoryGuid order by p.ProductName;



 SELECT c.*
     FROM Category c
     where c.ParentCategoryGuid is null

WITH cte
AS (
     SELECT c.*
     FROM Category c
     where c.ParentCategoryGuid is null
	  
		UNION ALL

		SELECT c1.*
     FROM Category c1
     INNER JOIN cte r ON c1.ParentCategoryGuid = r.CategoryGuid
	 )
	 select * from cte;


WITH cte
AS (
     SELECT c.*
     FROM Category c
     where c.ParentCategoryGuid is null
     
     UNION ALL
     
     SELECT c1.*
     FROM Category c1
     INNER JOIN cte r ON c1.ParentCategoryGuid = r.CategoryGuid
     )
SELECT * from cte;

WITH RecursiveCategory AS (
    SELECT c.categoryguid, c.categoryname, c.parentcategoryguid
    FROM Category c
    WHERE c.parentcategoryguid IS NULL
    
    UNION ALL
    
    SELECT c.categoryguid, c.categoryname, c.parentcategoryguid
    FROM Category c
    INNER JOIN RecursiveCategory rc ON c.parentcategoryguid = rc.categoryguid
)

SELECT 
    root_category.categoryname AS [Root Category Name Of Product], 
    immediate_category.categoryname AS [Immediate Category Name Of Product], 
    p.productname AS [Product Name]
FROM 
    Product p
JOIN 
    RecursiveCategory immediate_category ON p.categoryguid = immediate_category.categoryguid
JOIN 
    RecursiveCategory root_category ON immediate_category.parentcategoryguid = root_category.categoryguid;



WITH cte AS (
    SELECT
        c.CategoryGuid,
        c.CategoryName AS RootCategoryName,
        NULL AS ImmediateCategoryName
    FROM Category c
    WHERE c.ParentCategoryGuid IS NULL

    UNION ALL

    SELECT
        c1.CategoryGuid,
        cte.RootCategoryName,
        c1.CategoryName AS ImmediateCategoryName
    FROM Category c1
    INNER JOIN cte ON c1.ParentCategoryGuid = cte.CategoryGuid
)

SELECT
    p.ProductGuid,
    p.ProductName,
    COALESCE(cte.ImmediateCategoryName, cte.RootCategoryName) AS ProductCategory
FROM Product p
INNER JOIN cte ON p.CategoryGuid = cte.CategoryGuid
ORDER BY p.ProductGuid;





WITH RecursiveCategory AS (
    SELECT 
        CategoryGuid,
        CategoryName,
        ParentCategoryGuid,
        CategoryName AS RootCategoryName
    FROM 
        Category
    WHERE 
        ParentCategoryGuid IS NULL

    UNION ALL

    SELECT 
        C.CategoryGuid,
        C.CategoryName,
        C.ParentCategoryGuid,
        RC.RootCategoryName
    FROM 
        Category AS C
    INNER JOIN 
        RecursiveCategory AS RC ON C.ParentCategoryGuid = RC.CategoryGuid
)

SELECT 
    RC.RootCategoryName AS [Root Category Name Of Product],
    C1.CategoryName AS [Immediate Category Name Of Product],
    P.ProductName AS [Product Name]
FROM 
    Product AS P
JOIN 
    RecursiveCategory AS RC ON P.CategoryGuid = RC.CategoryGuid
JOIN 
    Category AS C1 ON P.CategoryGuid = C1.CategoryGuid
WHERE  RC.RootCategoryName IS NOT NULL
ORDER BY 
    [Root Category Name Of Product], 
    [Immediate Category Name Of Product], 
    [Product Name];



