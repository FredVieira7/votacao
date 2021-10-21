namespace Votacao.Infra.Settings
{
    public class AppSettings
    {
        public string ConnectionString { get; set; }
        public string Secret { get; set; }
        public int Expiration { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}