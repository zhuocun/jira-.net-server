public static class DBHelpers
{
    public static string GetTableName(ETableName tableName)
    {
        return tableName switch
        {
            ETableName.User => "users",
            ETableName.Project => "projects",
            ETableName.Task => "tasks",
            ETableName.Column => "columns",
            _ => throw new ArgumentOutOfRangeException(nameof(tableName), $"Invalid table name: {tableName}"),
        };
    }

    public static Enum GetDBType(String dbType)
    {
        return dbType switch
        {
            "mongoDB" => EDBType.MongoDB,
            "postgreSQL" => EDBType.PostgreSQL,
            _ => throw new ArgumentOutOfRangeException(nameof(dbType), $"Invalid database type: {dbType}"),
        };
    }

}