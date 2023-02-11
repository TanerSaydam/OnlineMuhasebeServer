using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Persistance.Constans;

namespace OnlineMuhasebeServer.Persistance.Configurations;

public sealed class ReportConfiguration : IEntityTypeConfiguration<Report>
{
    public void Configure(EntityTypeBuilder<Report> builder)
    {
        builder.ToTable(TableNames.Reports);
        builder.HasKey(t => t.Id);
    }
}
