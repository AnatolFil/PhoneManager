using PhoneManager.Domain.Models;
using PhoneManager.ViewModel.ContactList;
using System.ComponentModel.DataAnnotations;

namespace PhoneManager.ViewModel.CallList
{
    /// <summary>
    /// Модель списка вызовов
    /// </summary>
    public class CallListViewModel
    {
        public List<CallItem> Items { get; set; }

        public Filter Filter { get; set; }

        public string ReturnUrl { get; set; }

        public CallListViewModel Init(List<CallModel> callModels)
        {
            Items = callModels?.Select(i => new CallItem().Init(i)).ToList();
            return this;
        }
    }

    /// <summary>
    /// Вызов
    /// </summary>
    public class CallItem
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Вызывающий абонент
        /// </summary>
        public Contact Caller { get; set; }

        /// <summary>
        /// Принимающий вызов абонент
        /// </summary>
        public Contact Subscriber { get; set; }

        /// <summary>
        /// Начало звонка
        /// </summary>
        public DateTime CallStart { get; set; }

        /// <summary>
        /// Конец звонка
        /// </summary>
        public DateTime CallEnd { get; set; }

        public CallItem Init(CallModel callModel)
        {
            Id = callModel.Id;
            Caller = new Contact().Init(callModel.Caller);
            Subscriber = new Contact().Init(callModel.Subscriber);
            CallStart = callModel.CallStart;
            CallEnd = callModel.CallEnd;

            return this;
        }
    }

    /// <summary>
    /// Контакт
    /// </summary>
    public class Contact
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// ФИО
        /// </summary>
        public string FIO { get; set; }

        /// <summary>
        /// Адрес
        /// </summary>
        public string Address { get; set; }

        public Contact Init(ContactModel contact)
        {
            Id = contact.Id;
            PhoneNumber = contact.PhoneNumber?.Number;
            FIO = contact.FIO;
            Address = contact.Address;

            return this;
        }
    }

    /// <summary>
    /// Фильтр по контакту и переоду звонков
    /// </summary>
    public class Filter
    {
        public Guid? CallerId { get; set; }

        public DateTime? CallStart { get; set; }

        public DateTime? CallEnd { get; set; }
    }
}
