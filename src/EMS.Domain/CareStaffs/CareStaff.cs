using EMS.Citizens;
using System;
using Volo.Abp;

namespace EMS.CareStaffs
{
    public class CareStaff : Citizen, ISoftDelete
    {
        private Grade Grade { get; set; }

        public CareStaff(string name, string surname, decimal size, decimal weight, 
                            DateOnly birthDate, string jobName, int phoneNumber, BloodType bloodType, 
                            Grade grade, bool isDoingDrug = false, bool haveInsurance = false) 
            : base(name, surname, size, weight, birthDate, jobName, phoneNumber, bloodType)
        {
            this.Grade = grade;
        }
    }
}
