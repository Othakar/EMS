namespace EMS
{
    public static class EMSDbProperties
    {
        public static string DbTablePrefix { get; set; } = "";

        public static string DbTableSchema { get; set; } = null;

        public const string DbConnectionStringName = "Default";
    }
}
