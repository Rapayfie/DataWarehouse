namespace DataWarehouse.Benchmarks;

public static class SqlStatementsDescriptions
{
    #region Public fields
    public const string Insert = 
        @"INSERT INTO table_name (column1, column2, column3, ...)
VALUES (value1, value2, value3, ...)";

    public const string SelectAllPatients_WithoutDependencies_Where_AgeGreaterThan50_And_FirstNameStartsWithB =
        @"
DECLARE @__p_0 int = 2147483647;

SELECT TOP(@__p_0) [p].[Id], [p].[Address], [p].[Age], [p].[FirstName], [p].[LastName]
FROM [Patients] AS [p]
WHERE ([p].[Age] > 50) AND ([p].[FirstName] IS NOT NULL AND ([p].[FirstName] LIKE N'B%'))
ORDER BY [p].[FirstName], [p].[LastName]";
    
    public const string SelectAllPatients_WithDependencies_Where_AnyDiseaseStartsWithAletter_AndHasNoEndValue_AndAnyDiseaseHospitalHistoryStartsWithALetter_OrderByPatientAddress =
        @"
DECLARE @__p_0 int = 2147483647;

SELECT [t].[Id], [t].[Address], [t].[Age], [t].[FirstName], [t].[LastName], [t0].[Id], [t0].[EndDate], [t0].[Name], [t0].[PatientId], [t0].[StartDate], [t0].[Id0], [t0].[Description], [t0].[DiseaseId], [t0].[HospitalName], [t0].[StayFrom], [t0].[StayTo]
FROM (
    SELECT TOP(@__p_0) [p].[Id], [p].[Address], [p].[Age], [p].[FirstName], [p].[LastName]
    FROM [Patients] AS [p]
    WHERE EXISTS (
        SELECT 1
        FROM [Diseases] AS [d]
        WHERE ([p].[Id] = [d].[PatientId]) AND ((([d].[Name] IS NOT NULL AND ([d].[Name] LIKE N'A%')) AND [d].[EndDate] IS NULL) AND EXISTS (
            SELECT 1
            FROM [DiseaseHospitalHistories] AS [d0]
            WHERE ([d].[Id] = [d0].[DiseaseId]) AND ([d0].[Description] IS NOT NULL AND ([d0].[Description] LIKE N'A%')))))
    ORDER BY [p].[FirstName], [p].[LastName]
) AS [t]
LEFT JOIN (
    SELECT [d1].[Id], [d1].[EndDate], [d1].[Name], [d1].[PatientId], [d1].[StartDate], [d2].[Id] AS [Id0], [d2].[Description], [d2].[DiseaseId], [d2].[HospitalName], [d2].[StayFrom], [d2].[StayTo]
    FROM [Diseases] AS [d1]
    LEFT JOIN [DiseaseHospitalHistories] AS [d2] ON [d1].[Id] = [d2].[DiseaseId]
) AS [t0] ON [t].[Id] = [t0].[PatientId]
ORDER BY [t].[FirstName], [t].[LastName], [t].[Id], [t0].[Id], [t0].[Id0]";

    #endregion
}