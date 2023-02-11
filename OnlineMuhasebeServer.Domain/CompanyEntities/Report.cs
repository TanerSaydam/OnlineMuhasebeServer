using OnlineMuhasebeServer.Domain.Abstractions;

namespace OnlineMuhasebeServer.Domain.CompanyEntities;

public sealed class Report : Entity
{
    public string Name { get; set; }
    public bool Status { get; set; }
    public string FileUrl { get; set; } 
}
