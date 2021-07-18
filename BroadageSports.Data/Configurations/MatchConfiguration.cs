using BroadageSports.Entity.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadageSports.Data.Configurations
{
    public class MatchConfiguration:BaseConfiguration<Match>
    {
        public override void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.Property(m => m.Stoppage).IsRequired();
            builder.Property(m => m.CurrentMinute).IsRequired();
        
            base.Configure(builder);
        }
    }
}
