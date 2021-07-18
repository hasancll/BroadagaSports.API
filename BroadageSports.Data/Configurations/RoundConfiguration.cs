using BroadageSports.Entity.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadageSports.Data.Configurations
{
    public class RoundConfiguration:BaseConfiguration<Round>
    {
        public override void Configure(EntityTypeBuilder<Round> builder)
        {
            
            base.Configure(builder);
        }
    }
}
