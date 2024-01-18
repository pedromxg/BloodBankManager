using BloodBankManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManager.Infrastructure.Persistence.Configurations
{
    public class DonorConfigurations : IEntityTypeConfiguration<Donor>
    {
        public void Configure(EntityTypeBuilder<Donor> builder)
        {
            builder.HasKey(d => d.Id);

            builder.HasMany(d => d.Donations)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
