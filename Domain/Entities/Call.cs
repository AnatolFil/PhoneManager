using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PhoneManager.Models.Entities
{
    public class Call: BaseEntity<Guid>
    {
        public Guid? CallerId { get; set; }
        public Contact Caller { get; set; }

        public Guid? SubscriberId { get; set; }       
        public Contact Subscriber { get; set; }

        [Required]
        public DateTime CallStart { get; set; }

        public DateTime CallEnd { get; set; }
    }

    //public class CallEntityConfiguration : IEntityTypeConfiguration<Call>
    //{
    //    public void Configure(EntityTypeBuilder<Call> builder)
    //    {
    //        builder.HasOne(e => e.Subscriber).OnDelete(DeleteBehavior.NoAction);
    //    }
    //}
}
