using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PhoneManager.Models.Entities
{
    /// <summary>
    /// Сущность вызов (звонок)
    /// </summary>
    public class Call: BaseEntity<Guid>
    {
        public Guid? CallerId { get; set; }
        /// <summary>
        /// Вызывающий абонент
        /// </summary>
        public Contact Caller { get; set; }

        public Guid? SubscriberId { get; set; }
        /// <summary>
        /// Абонент цель
        /// </summary>
        public Contact Subscriber { get; set; }

        /// <summary>
        /// Начало звонка
        /// </summary>
        [Required]
        public DateTime CallStart { get; set; }

        /// <summary>
        /// Конец звонка
        /// </summary>
        public DateTime CallEnd { get; set; }
    }
}
