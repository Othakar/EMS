using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Uow;

namespace EMS.Acts
{
    public class ActionDomainService : DomainService
    {
        private readonly IRepository<Act, int> _actionRepository;
        private readonly UnitOfWorkManager _unitOfWorkManager;

        public ActionDomainService(IRepository<Act, int> actionRepository, UnitOfWorkManager unitOfWorkManager)
        {
            _actionRepository = actionRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }

        [UnitOfWork]
        public virtual async Task<Act> Create(string name, int price, string description, ActType type)
        {
           var existingAction = await _actionRepository.FirstOrDefaultAsync(a => a.Name == name);
            if (existingAction == null)
            {
                throw new BusinessException(EMSErrorCodes.ActionAlreadyExist);
            }
            var newAction = new Act(name,price,description,type);
            return await _actionRepository.InsertAsync(newAction);
        }
    }
}
