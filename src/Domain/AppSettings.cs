using System.Collections.Generic;

namespace Domain
{
    public class AppSettings
    {
        public AppSettings(string con)
        {
            if (connectionString != null)
                return;
                
            connectionString = con;
        }        

        public static string connectionString { get; private set; }      
        

        // Config JWT
        public static string Secret = "fedaf7d8863b48e197b9287d492b708e";
        public static int ExpirationHours = 2;

        // public static List<string> Dominios = new List<string>() { "http://localhost:4200" };
        // public static List<string> Emissores = new List<string>() { "SEDUC" };
        
    }
}