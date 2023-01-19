using Microsoft.AspNetCore.Identity;

namespace OnlineMuhasebeServer.Domain.AppEntities.Identity
{
    public sealed class AppRole : IdentityRole<string>
    {
        public string Code { get; set; }
    }
}
