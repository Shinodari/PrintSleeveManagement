SELECT DATEADD(DAY, -1,DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()) +2, '1'))

SELECT [PrintSleeve].[ItemNo], [Item].[PartNo], SUM([PrintSleeve].[Quantity]) AS 'Quantity', [ExpireDate].[ExpireDate], [ExpireDate].[Time] +1 AS 'TimeExpire' FROM [PrintSleeve]
JOIN [Item] ON [Item].[ItemNo] = [PrintSleeve].[ItemNo]
JOIN [ExpireDate] ON [ExpireDate].[RollNo] = [PrintSleeve].[RollNo] AND [ExpireDate].[ExpireDate] < DATEADD(DAY, -1,DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()) +2, '1'))
LEFT JOIN [Ship] ON [PrintSleeve].[RollNo] = [Ship].[RollNo]
WHERE [Ship].[RollNo] IS NULL
GROUP BY [PrintSleeve].[ItemNo], [Item].[PartNo], [ExpireDate].[ExpireDate], [ExpireDate].[Time]
ORDER BY [ExpireDate].[ExpireDate]

SELECT * FROM [ExpireDate]
WHERE [ExpireDate].[ExpireDate] < (DATEADD(MONTH, 1, GETDATE()))
