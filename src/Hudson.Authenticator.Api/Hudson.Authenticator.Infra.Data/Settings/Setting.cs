namespace Hudson.Authenticator.Infra.Data.Settings
{
    public class Setting
    {
        public string ConnectionString { get; set; }
        public string Secret { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
    }
}
