using Domain.Investors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Investors;

public class InvestorConfiguration : IEntityTypeConfiguration<Investor>
{

    public void Configure(EntityTypeBuilder<Investor> builder)
    {
        builder.HasKey(_ => _.Id);
    }
}