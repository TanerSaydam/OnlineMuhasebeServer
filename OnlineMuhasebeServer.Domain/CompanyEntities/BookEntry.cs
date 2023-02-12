using OnlineMuhasebeServer.Domain.Abstractions;

namespace OnlineMuhasebeServer.Domain.CompanyEntities;

public sealed class BookEntry : Entity
{
    public string BookEntryNumber { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
}
