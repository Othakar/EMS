using EMS.Citizens;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace EMS.CareStaffs
{
    public class CareStaffDomainService
    {
        private readonly IRepository<CareStaff, int> _careStaffRepository;
        private readonly IRepository<Citizen, int> _citizenRepository;

        public CareStaffDomainService(IRepository<CareStaff, int> careStaffRepository, IRepository<Citizen, int> citizenRepository)
        {
            _careStaffRepository = careStaffRepository;
            _citizenRepository = citizenRepository;
        }

        [UnitOfWork]
        public virtual async Task<CareStaff> Create(Grade grade, int citizenId)
        {
            var citizen = await _citizenRepository.FirstOrDefaultAsync(c=>c.Id == citizenId);
            if(citizen == null)
            {
                throw new BusinessException(EMSErrorCodes.CareStaffCitizenDoesNotExist);
            }
            var newCareStaff = new CareStaff(grade, citizenId);
            return await _careStaffRepository.InsertAsync(newCareStaff);
        }
    }
}
