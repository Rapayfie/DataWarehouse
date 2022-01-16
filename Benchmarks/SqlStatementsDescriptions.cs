namespace DataWarehouse.Benchmarks;

public static class SqlStatementsDescriptions
{
    #region Public fields
    public const string Insert = @"
        INSERT INTO table_name (column1, column2, column3, ...)
        VALUES (value1, value2, value3, ...)";
    #endregion
}