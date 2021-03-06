using BroadageSports.Entity.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadageSports.Data.Configurations
{
    public class StageConfiguration:BaseConfiguration<Stage>
    {
        public override void Configure(EntityTypeBuilder<Stage> builder)
        {
            builder.Property(s => s.Name).IsRequired();
            builder.Property(s => s.ShortName).IsRequired();
            base.Configure(builder);
        }
    }
}
