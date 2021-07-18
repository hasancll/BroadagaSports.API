using BroadageSports.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadageSports.Data.Configurations
{
    public class BaseConfiguration<Tentity> : IEntityTypeConfiguration<Tentity> where Tentity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<Tentity> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}
