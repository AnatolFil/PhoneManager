using PhoneManager.Domain.Models;
using PhoneManager.Models.Entities;
using PhoneManager.Models.Interfaces;
using PhoneManager.Models.Interfaces.Services;
using PhoneManager.Models.Repositories;

namespace PhoneManager.Domain.Services
{
    /// <summary>
    /// Сервис для работы с контактами
    /// </summary>
    public class ContactService : IContactService
    {
        private readonly IContactRepository contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        public async Task<Guid> AddOrUpdateAsync(ContactModel model)
        {
            var entity = await contactRepository.GetAsync(model.Id);
            
            if (entity != null)
            {
                entity.Address = model.Address;
                if (entity.PhoneNumber == null)
                {
                    entity.PhoneNumber = new PhoneNumber()
                    {
                        Number =  model.PhoneNumber.Number
                    };
                }
                else
                {
                    entity.PhoneNumber.Number = model.PhoneNumber.Number;
                }
                entity.FIO = model.FIO;

                await contactRepository.UpdateAsync(entity);
            }
            else
            {
                var newEtity = new Contact()
                {
                    Address = model.Address,
                    FIO = model.FIO,
                    PhoneNumber = new PhoneNumber()
                    {
                        Number = model.PhoneNumber.Number
                    }
                };
                
                await contactRepository.AddAsync(newEtity);
                return newEtity.Id;
            }

            return entity.Id;
        }

        public async Task<IEnumerable<ContactModel>> GetAllAsync()
        {
            var entities = await contactRepository.GetAllAsync();
            return entities?.Any() == true
                ? entities.Select(i => new ContactModel()
                {
                    Id = i.Id,
                    Address = i.Address,
                    FIO = i.FIO,
                    PhoneNumber = i.PhoneNumber != null
                    ? new PhoneNumberModel() { Id = i.PhoneNumberId.Value, Number = i.PhoneNumber.Number }
                    : null
                })
                : null;
        }

        public async Task<ContactModel> GetAsync(Guid id)
        {
            var entity = await contactRepository.GetAsync(id);

            return entity == null
                ? null
                : new ContactModel() 
                { 
                    Address = entity.Address, 
                    FIO = entity.FIO, 
                    Id = entity.Id, 
                    PhoneNumber = new PhoneNumberModel() 
                    { 
                        Id = entity.PhoneNumberId.Value, 
                        Number = entity.PhoneNumber?.Number 
                    } 
                };
        }

        public async Task RemoveAsync(Guid id)
        {
            var entity = await contactRepository.GetAsync(id);
            await contactRepository.RemoveAsync(entity);
        }
    }
}
