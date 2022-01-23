using EMS.Citizens;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace EMS.CareStaffs
{
    public class CareStaff : Entity<int>, ISoftDelete
    {
        public int GradeId { get;private set; }
        public Grade Grade { get; private set; }

        [ForeignKey("Citizen")]
        public int CitizenId { get; private set; }

        public bool IsDeleted { get; set; }

        public Citizen Citizen{ get; set; }

    private CareStaff() { }

    public CareStaff(Grade grade, Citizen citizen)
    {
        this.Grade = grade;
        this.Citizen = citizen;
        this.CitizenId = citizen.Id;
    }
}
}
