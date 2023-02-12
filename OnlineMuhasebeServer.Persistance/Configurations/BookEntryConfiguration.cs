using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Persistance.Constans;

namespace OnlineMuhasebeServer.Persistance.Configurations;

public sealed class BookEntryConfiguration : IEntityTypeConfiguration<BookEntry>
{
    public void Configure(EntityTypeBuilder<BookEntry> builder)
    {
        builder.ToTable(TableNames.BookEntries);
        builder.HasKey(t => t.Id);
    }
}
