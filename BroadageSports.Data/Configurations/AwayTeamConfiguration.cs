using BroadageSports.Entity.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadageSports.Data.Configurations
{
    public class AwayTeamConfiguration:BaseConfiguration<AwayTeam>
    {
        public override void Configure(EntityTypeBuilder<AwayTeam> builder)
        {
            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.ShortName).IsRequired();
            builder.Property(a => a.MediumName).IsRequired();
          
        }
    }
}
