using Microsoft.EntityFrameworkCore;
using PhoneManager.Domain.Interfaces;
using PhoneManager.Models.Entities;
using System.Net;

namespace PhoneManager.Models.Interfaces
{
    public interface IContactRepository : IBaseRepository<Contact, Guid>
    {

    }
}
