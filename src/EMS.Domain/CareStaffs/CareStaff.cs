using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace EMS.CareStaffs
{
    public class CareStaff : Entity<int>, ISoftDelete
    {
        public Grade Grade { get; private set; }

        public int CitizenId { get; private set; }

        public bool IsDeleted { get;  set;}

        private CareStaff() { }

        public CareStaff(Grade grade, int citizenId)
        {
            this.Grade = grade;
            this.CitizenId = citizenId;
        }
    }
}
