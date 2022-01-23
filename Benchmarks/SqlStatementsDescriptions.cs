namespace DataWarehouse.Benchmarks;

public static class SqlStatementsDescriptions
{
    #region Public fields
    public const string Insert = 
        @"INSERT INTO table_name (column1, column2, column3, ...)
VALUES (value1, value2, value3, ...)";

    public const string SelectAllPatients_WithoutDependencies =
        @"SELECT TOP(@__p_0) [p].[Id], [p].[Address], [p].[Age], [p].[FirstName], [p].[LastName]
FROM [Patients] AS [p]";
    
    public const string SelectAllPatients_WithDependencies =
        @"SELECT [t].[Id], [t].[Address], [t].[Age], [t].[FirstName], [t].[LastName], [t0].[Id], [t0].[EndDate], [t0].[Name], [t0].[PatientId], [t0].[StartDate], [t0].[Id0], [t0].[Description], [t0].[DiseaseId], [t0].[HospitalName], [t0].[StayFrom], [t0].[StayTo]
FROM (
    SELECT TOP(@__p_0) [p].[Id], [p].[Address], [p].[Age], [p].[FirstName], [p].[LastName]
    FROM [Patients] AS [p]
) AS [t]
LEFT JOIN (
    SELECT [d].[Id], [d].[EndDate], [d].[Name], [d].[PatientId], [d].[StartDate], [d0].[Id] AS [Id0], [d0].[Description], [d0].[DiseaseId], [d0].[HospitalName], [d0].[StayFrom], [d0].[StayTo]
    FROM [Diseases] AS [d]
    LEFT JOIN [DiseaseHospitalHistories] AS [d0] ON [d].[Id] = [d0].[DiseaseId]
) AS [t0] ON [t].[Id] = [t0].[PatientId]
ORDER BY [t].[Id], [t0].[Id], [t0].[Id0]";

    public const string SelectAllPatients_WithDependencies_WhereDiseaseStartsWith_A_letter_OrderByPatientAddress =
        @"SELECT [t].[Id], [t].[Address], [t].[Age], [t].[FirstName], [t].[LastName], [t0].[Id], [t0].[EndDate], [t0].[Name], [t0].[PatientId], [t0].[StartDate], [t0].[Id0], [t0].[Description], [t0].[DiseaseId], [t0].[HospitalName], [t0].[StayFrom], [t0].[StayTo]
FROM (
    SELECT TOP(@__p_0) [p].[Id], [p].[Address], [p].[Age], [p].[FirstName], [p].[LastName]
    FROM [Patients] AS [p]
    WHERE EXISTS (
        SELECT 1
        FROM [Diseases] AS [d]
        WHERE ([p].[Id] = [d].[PatientId]) AND ([d].[Name] IS NOT NULL AND ([d].[Name] LIKE N'a%')))
    ORDER BY [p].[Address]
) AS [t]
LEFT JOIN (
    SELECT [d0].[Id], [d0].[EndDate], [d0].[Name], [d0].[PatientId], [d0].[StartDate], [d1].[Id] AS [Id0], [d1].[Description], [d1].[DiseaseId], [d1].[HospitalName], [d1].[StayFrom], [d1].[StayTo]
    FROM [Diseases] AS [d0]
    LEFT JOIN [DiseaseHospitalHistories] AS [d1] ON [d0].[Id] = [d1].[DiseaseId]
) AS [t0] ON [t].[Id] = [t0].[PatientId]
ORDER BY [t].[Address], [t].[Id], [t0].[Id], [t0].[Id0]";
    #endregion
}