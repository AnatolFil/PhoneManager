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
    public class ContactService : BaseService<Contact, ContactModel, Guid>, IContactService
    {
        private readonly IContactRepository contactRepository;
        private readonly IPhoneNumberRepository phoneNumberRepository;

        public ContactService(
            IContactRepository contactRepository,
            IPhoneNumberRepository phoneNumberRepository
            )
        {
            this.contactRepository = contactRepository;
            this.phoneNumberRepository = phoneNumberRepository;
        }

        public override async Task<Guid> AddOrUpdateAsync(ContactModel model)
        {
            var entity = await contactRepository.GetAsync(model.Id);

            if (entity != null)
            {
                entity.Address = model.Address;
                if(entity.PhoneNumber == null)
                {
                    //entity.PhoneNumber = model.PhoneNumber;
                }
                
                entity.FIO = model.FIO;

                await contactRepository.UpdateAsync(entity);
            }
            else
            {// Add
                var newEtity = new Contact();
                //entity = mapper.Map<AppealEntity>(model);
                //await repository.AddAsync(entity);
            }

            return entity.Id;
        }
    }
}
