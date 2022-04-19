namespace PushNotifaction.Models
{
    public class SiteKeys
    {
        private static IConfigurationSection _configuration;
        public static void Configure(IConfigurationSection configuration)
        {
            _configuration = configuration;
        }

        public static string Firebase_Public_Key => _configuration["Firebase_Public_Key"];
        public static string Firebase_Server_Key => _configuration["Firebase_Server_Key"];
        public static string FireBaseApiUrl => _configuration["FireBaseApiUrl"];
        public static string ImageUrlDomain => _configuration["ImageUrlDomain"];
        public static string Domain => _configuration["Domain"];

    }
}
