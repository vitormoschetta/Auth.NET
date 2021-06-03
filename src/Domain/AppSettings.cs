using System.Collections.Generic;

namespace Domain
{
    public class AppSettings
    {
        private static string ConnectionString { get; set; }

        public static void SetConnectionString(string connectionString)
        {
            if (!string.IsNullOrEmpty(ConnectionString))
                return;

            ConnectionString = connectionString;
        }

        public static string GetConnectionString()
        {
            return ConnectionString;
        }

        // Config JWT
        public static string Secret = "fedaf7d8863b48e197b9287d492b708e";
        public static int ExpirationHours = 2;        
        
    }
}
