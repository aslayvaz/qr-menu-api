namespace QrMenu.Utils.Auth
{
    public class JwtConfig
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpiresInDays { get; set; }
        public string Secret { get; set; }
    }
}

