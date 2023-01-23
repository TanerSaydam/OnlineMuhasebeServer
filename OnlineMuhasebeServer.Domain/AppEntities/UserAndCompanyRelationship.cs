using OnlineMuhasebeServer.Domain.Abstractions;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineMuhasebeServer.Domain.AppEntities;

public class UserAndCompanyRelationship: Entity
{
    public UserAndCompanyRelationship()
    {

    }

    public UserAndCompanyRelationship(string id, string appUserId, string companyId): base(id)
    {
        AppUserId = appUserId;
        CompanyId = companyId;
    }

    [ForeignKey("AppUser")]
    public string AppUserId { get; set; }
    public AppUser AppUser { get; set; }

    [ForeignKey("Company")]
    public string CompanyId { get; set; }
    public Company Company { get; set; }
}
