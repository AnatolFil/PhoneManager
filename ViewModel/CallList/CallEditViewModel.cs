using PhoneManager.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace PhoneManager.ViewModel.CallList
{
    /// <summary>
    /// Модель для редактирования или создания нового вызова
    /// </summary>
    public class CallEditViewModel
    {
        public Guid? Id { get; set; }

        /// <summary>
        /// Вызывающий абонент
        /// </summary>
        [Required(ErrorMessage = "Выбере абонента")]
        public Guid? CallerId { get; set; }

        /// <summary>
        /// Принимающий вызов абонент
        /// </summary>
        [Required(ErrorMessage = "Выбере абонента")]
        public Guid? SubscriberId { get; set; }

        /// <summary>
        /// Начало звонка
        /// </summary>
        [Required(ErrorMessage = "Заполните поле")]
        public DateTime? CallStart { get; set; }

        /// <summary>
        /// Конец звонка
        /// </summary>
        public DateTime? CallEnd { get; set; }

        public string ReturnUrl { get; set; }

        public CallEditViewModel Init(CallModel callModel = null)
        {
            if(callModel != null)
            {
                Id = callModel.Id;
                CallerId = callModel.Caller.Id;
                SubscriberId = callModel.Subscriber?.Id;
                CallStart = callModel.CallStart;
                CallEnd = callModel.CallEnd;
            }
            else
            {
                CallStart = DateTime.Now;
                CallEnd = DateTime.Now;
            }
            return this;
        }
    }
}
