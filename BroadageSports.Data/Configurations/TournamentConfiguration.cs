using BroadageSports.Entity.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadageSports.Data.Configurations
{
    public class TournamentConfiguration:BaseConfiguration<Tournament>
    {
        public override void Configure(EntityTypeBuilder<Tournament> builder)
        {
            builder.Property(t => t.Name).IsRequired();
            builder.Property(t => t.ShortName).IsRequired();
            base.Configure(builder);
        }
    }
}
