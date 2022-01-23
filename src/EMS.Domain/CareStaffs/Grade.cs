using Volo.Abp.Domain.Entities;

namespace EMS.CareStaffs
{
    public class Grade : Entity<int>
    {
        private Grade()
        {

        }
        public GradeName Name { get; private set; }

        public Grade(GradeName gradeName)
        {
            Name = gradeName;
        }
    }
}
