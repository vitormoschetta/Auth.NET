using System.Collections.Generic;

namespace Domain
{
    public class AppSettings
    {
        // DB
        public static string ConnectionString { get; private set; }      

        public AppSettings(string con)
        {
            if (ConnectionString != null)
                return;
                
            ConnectionString = con;
        }                
        

        // Email 
        public static string EmailFrom = "vitormoschetta.suporte@gmail.com";
        public static string EmailPassword = "Suporte123*";
        

        // Config JWT
        public static string Secret = "fedaf7d8863b48e197b9287d492b708e";
        public static int ExpirationHours = 2;        
        
    }
}
