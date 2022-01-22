using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Uow;

namespace EMS.Actions
{
    public class ActionDomainService : DomainService
    {
        private readonly IRepository<Action, int> _actionRepository;
        private readonly UnitOfWorkManager _unitOfWorkManager;

        public ActionDomainService(IRepository<Action, int> actionRepository, UnitOfWorkManager unitOfWorkManager)
        {
            _actionRepository = actionRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }

        [UnitOfWork]
        public virtual async Task<Action> Create(string name, int price, string description, ActionType type)
        {
           var existingAction = await _actionRepository.FirstOrDefaultAsync(a => a.Name == name);
            if (existingAction == null)
            {
                throw new BusinessException(EMSErrorCodes.ActionAlreadyExist);
            }
            var newAction = new Action(name,price,description,type);
            return await _actionRepository.InsertAsync(newAction);
        }
    }
}
