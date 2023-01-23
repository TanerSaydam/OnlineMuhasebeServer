using OnlineMuhasebeServer.Domain.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineMuhasebeServer.Domain.AppEntities;

public sealed class MainRole : Entity
{
    public MainRole(string id, string title, bool ısRoleCreatedByAdmin = false, string companyId = null) : base(id)
    {
        Title = title;
        IsRoleCreatedByAdmin = ısRoleCreatedByAdmin;
        CompanyId = companyId;        
    }

    public string Title { get; set; }   
    public bool IsRoleCreatedByAdmin { get; set; }

    [ForeignKey("Company")]
    public string CompanyId { get; set; }
    public Company? Company { get; set; }
}
