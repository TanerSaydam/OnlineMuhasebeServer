using OnlineMuhasebeServer.Domain.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineMuhasebeServer.Domain.AppEntities;

public sealed class MainRole : Entity
{
    public MainRole()
    {

    }
    public MainRole(string id, string title, bool isRoleCreatedByAdmin = false, string companyId = null) : base(id)
    {
        Title = title;
        IsRoleCreatedByAdmin = isRoleCreatedByAdmin;
        CompanyId = companyId;        
    }

    public string Title { get; set; }   
    public bool IsRoleCreatedByAdmin { get; set; }

    [ForeignKey("Company")]
    public string CompanyId { get; set; }
    public Company? Company { get; set; }
}
