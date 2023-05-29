SELECT [PrintSleeve].[ItemNo], [Item].[PartNo], SUM([PrintSleeve].[Quantity]) AS 'Quantity', [ExpireDate].[ExpireDate], [ExpireDate].[Time] +1 AS 'TimeExpire', 
[ExpireDate].[PriorExpiredSheetNo], [ExpireDate].[PriorExpiredSheetIssueDate], [ExpireDate].[IRSNo], [ExpireDate].[IRSIssueDate] 
FROM [PrintSleeve]
JOIN [Item] ON [Item].[ItemNo] = [PrintSleeve].[ItemNo]
JOIN [ExpireDate] ON [ExpireDate].[RollNo] = [PrintSleeve].[RollNo]
LEFT JOIN [Ship] ON [PrintSleeve].[RollNo] = [Ship].[RollNo]
WHERE [Ship].[RollNo] IS NULL AND ([ExpireDate].[PriorExpiredSheetNo] IS NOT NULL OR [ExpireDate].[IRSNo] IS NOT NULL)
GROUP BY [PrintSleeve].[ItemNo], [Item].[PartNo], [ExpireDate].[ExpireDate], [ExpireDate].[Time], [ExpireDate].[PriorExpiredSheetNo], [ExpireDate].[PriorExpiredSheetIssueDate], [ExpireDate].[IRSNo], [ExpireDate].[IRSIssueDate] 
ORDER BY [ExpireDate].[ExpireDate]