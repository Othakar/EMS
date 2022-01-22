using EMS.CareStaff;

namespace EMS.CareStaffs
{
    public class Grade
    {
        public GradeName Name { get;private set; }
        
        public Grade(GradeName gradeName)
        {
            Name = gradeName;
        }
    }
}
