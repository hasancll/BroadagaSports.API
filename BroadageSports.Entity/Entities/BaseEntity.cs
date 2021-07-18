using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BroadageSports.Entity.Entities
{
    public class BaseEntity
    {
     
        [Key]
        public virtual int Id { get; set; }
    }
}
