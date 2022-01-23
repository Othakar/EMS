using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Uow;

namespace EMS.Citizens
{
    public class CitizenDomainService : DomainService
    {
        private readonly IRepository<Citizen, int> _citizenRepository;
        private readonly UnitOfWorkManager _unitOfWorkManager;

        public CitizenDomainService(IRepository<Citizen, int> citizenRepository, UnitOfWorkManager unitOfWorkManager)
        {
            _citizenRepository = citizenRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }

        [UnitOfWork]
        public virtual async Task<Citizen> Create(
            string name, 
            string surname, 
            decimal size, 
            decimal weight, DateOnly birthDate,
            string jobName, int phoneNumber, 
            BloodType bloodType,
            bool isDoingDrug = false, 
            bool haveInsurance = false
        )
        {
            var existingCitizen = await _citizenRepository.FirstOrDefaultAsync(c => c.Name == name && c.Surname == surname);
            if(existingCitizen != null)
            {
                throw new BusinessException(EMSErrorCodes.CitizenAlreadyExist);
            }

            var newCitizen = new Citizen(name,surname,size,weight,birthDate,jobName,phoneNumber, bloodType, isDoingDrug, haveInsurance);
            return await _citizenRepository.InsertAsync(newCitizen);
        }

        public virtual async Task<Citizen> Update(string name,
            string surname,
            decimal size,
            decimal weight, DateOnly birthDate,
            string jobName, int phoneNumber,
            BloodType bloodType,
            bool isDoingDrug = false,
            bool haveInsurance = false)
        {
            var existingCitizen = await _citizenRepository.FirstOrDefaultAsync(c => c.Name == name && c.Surname == surname);
            if (existingCitizen == null)
            {
                throw new BusinessException(EMSErrorCodes.CitizenDoesNotExist);
            }
            existingCitizen = new Citizen(name, surname, size, weight, birthDate, jobName, phoneNumber, bloodType, isDoingDrug, haveInsurance);
            return await _citizenRepository.UpdateAsync(existingCitizen);
        }
    }
}
