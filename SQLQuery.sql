SELECT [Order].[OrderNo], SUM([Order_Item].[Quantity]), (SELECT SUM([PrintSleeve].[Quantity]) FROM [PrintSleeve], [Stage]
WHERE [PrintSleeve].[RollNo] = [Stage].[RollNo] AND [Stage].[OrderNo] = '221206')
FROM [Order]
LEFT JOIN [Order_Item] 
ON [Order].[OrderNo] = [Order_Item].[OrderNo]
WHERE [Order].[OrderNo] = '221206'
GROUP BY [Order].[OrderNo]

SELECT SUM([PrintSleeve].[Quantity]) FROM [PrintSleeve], [Stage]
WHERE [PrintSleeve].[RollNo] = [Stage].[RollNo] AND [Stage].[OrderNo] = '221206'