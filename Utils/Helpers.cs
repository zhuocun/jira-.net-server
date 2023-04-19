public static class Helpers
{
    public static string GetCollectionName(ETableName tableName)
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

}