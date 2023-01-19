namespace OnlineMuhasebeServer.Infrasturcture.Authentication
{
    public sealed class JwtOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecretKey { get; set; }
    }
}
