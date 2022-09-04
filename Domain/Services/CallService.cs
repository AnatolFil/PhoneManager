using PhoneManager.Domain.Interfaces.Services;
using PhoneManager.Domain.Models;
using PhoneManager.Models.Entities;
using PhoneManager.Models.Interfaces;
using PhoneManager.Models.Repositories;

namespace PhoneManager.Domain.Services
{
    public class CallService :  ICallService
    {
        private readonly ICallRepository callRepository;

        public CallService(ICallRepository callRepository)
        {
            this.callRepository = callRepository;
        }

        public async Task<Guid> AddOrUpdateAsync(CallModel model)
        {
            var entity = await callRepository.GetAsync(model.Id);

            if (entity != null)
            {
                entity.Caller.Id = model.Caller.Id;
                if (entity.Subscriber != null) entity.Subscriber.Id = model.Subscriber.Id;
                else entity.Subscriber = new Contact() { Id = model.Subscriber.Id };
                entity.CallStart = model.CallStart;
                entity.CallEnd = model.CallEnd;

                await callRepository.UpdateAsync(entity);
            }
            else
            {
                var newEtity = new Call()
                {
                    SubscriberId = model.Subscriber != null
                        ? model.Subscriber.Id
                        : null,
                    CallerId = model.Caller.Id,
                    CallStart = model.CallStart,
                    CallEnd = model.CallEnd,
                };

                await callRepository.AddAsync(newEtity);
                return newEtity.Id;
            }

            return entity.Id;
        }

        public async Task<IEnumerable<CallModel>> GetAllAsync()
        {
            var entities = await callRepository.GetAllAsync();
            return entities?.Any() == true
                ? entities.Select(i => new CallModel()
                {
                    Id = i.Id,
                    Caller = new ContactModel()
                    {
                        Id = i.Caller.Id,
                        Address = i.Caller.Address,
                        FIO = i.Caller.FIO,
                        PhoneNumber = new PhoneNumberModel() { Id = i.Caller.Id, Number = i.Caller.PhoneNumber.Number }
                    },
                    Subscriber = i.Subscriber != null
                        ? new ContactModel()
                        {
                            Id = i.Subscriber.Id,
                            Address = i.Subscriber.Address,
                            FIO = i.Subscriber.FIO,
                            PhoneNumber = new PhoneNumberModel() { Id = i.Subscriber.Id, Number = i.Subscriber.PhoneNumber.Number }
                        }
                        : null,
                    CallStart = i.CallStart,
                    CallEnd = i.CallEnd
                })
                : null;
        }

        public async Task<CallModel> GetAsync(Guid id)
        {
            var entity = await callRepository.GetAsync(id);

            return entity == null
                ? null
                : new CallModel()
                {
                    Id = entity.Id,
                    Caller = new ContactModel()
                    {
                        Id = entity.Caller.Id,
                        Address = entity.Caller.Address,
                        FIO = entity.Caller.FIO,
                        PhoneNumber = new PhoneNumberModel() { Id = entity.Caller.Id, Number = entity.Caller.PhoneNumber.Number }
                    },
                    Subscriber = entity.Subscriber != null
                        ? new ContactModel()
                        {
                            Id = entity.Subscriber.Id,
                            Address = entity.Subscriber.Address,
                            FIO = entity.Subscriber.FIO,
                            PhoneNumber = new PhoneNumberModel() { Id = entity.Subscriber.Id, Number = entity.Subscriber.PhoneNumber.Number }
                        }
                        : null,
                    CallStart = entity.CallStart,
                    CallEnd = entity.CallEnd
                };
        }

        public async Task RemoveAsync(Guid id)
        {
            var entity = await callRepository.GetAsync(id);
            await callRepository.RemoveAsync(entity);
        }
    }
}
