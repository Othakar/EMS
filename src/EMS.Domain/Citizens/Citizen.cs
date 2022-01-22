using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace EMS.Citizens
{
    public class Citizen : Entity<int>, ISoftDelete

    {
        internal Citizen()
        {

        }

        public Citizen(string name,string surname,decimal size,decimal weight,DateOnly birthDate, string jobName,  int phoneNumber, BloodType bloodType, bool isDoingDrug = false, bool haveInsurance = false)
        {
            this.Name = name;
            this.Surname = surname;
            this.SetSize(size);
            this.SetWeigth(weight);
            this.BirthDate = birthDate;
            this.JobName = jobName;
            this.PhoneNumber = phoneNumber;
            this.IsDoingDrug = isDoingDrug;
            this.HaveInsurance = haveInsurance;
            this.BloodType = bloodType;
        }

        #region properties
        [Required]
        public string Name { get; private set; }

        [Required]
        public string Surname { get; private set; }

        [Required]
        public decimal Weight { get; private set; }

        [Required]
        public decimal Size { get; private set; }

        [Required]
        public DateOnly BirthDate { get; private set; }

        [Required]
        public bool IsDoingDrug { get; private set; }

        [Required]
        public bool HaveInsurance { get; private set; }

        [Required]
        public int PhoneNumber { get; private set; }

        [Required]
        public string JobName { get; private set; }// note ça pourrait etre une enum

        [Required]
        public bool IsDeleted { get; set; }

        [Required]
        public BloodType BloodType { get; private set; }
        #endregion

        #region setter
        private void SetSize(decimal size)
        {
            if(size <= 0)
            {
                throw new BusinessException(EMSErrorCodes.CitizenSizeMustBeGreaterThanZero);
            }
            this.Size = size;
        }

        private void SetWeigth(decimal weigth)
        {
            if (weigth <= 0)
            {
                throw new BusinessException(EMSErrorCodes.CitizenWeightMustBeGreaterThanZero);
            }
            this.Weight = weigth;
        }

        #endregion
    }
}
