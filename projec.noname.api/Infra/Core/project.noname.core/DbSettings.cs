namespace project.noname.core
{
    public class DbSettings
    {
        public string Server { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Port { get; set; }
        public string Database { get; set; }
            
        public DbSettings(string prefix)
        {
            var configurationManager = new ConfigurationManager();

            Server = configurationManager.AppSettings[prefix + "_host"];
            Port = configurationManager.AppSettings[prefix + "_port"];
            Username = configurationManager.AppSettings[prefix + "_username"];
            Password = configurationManager.AppSettings[prefix + "_password"];
            Database = configurationManager.AppSettings[prefix + "_database"];
        }
    }
}
