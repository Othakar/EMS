using EMS.Acts;
using EMS.CareStaffs;
using EMS.Citizens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace EMS.Records
{
    public class Record : Entity<int>
    {
        #region Constructors
        private Record() { }

        public Record(List<Act> acts, int idCareStaff, int idCitizen, DateTime? created = null)
        {
            this.Acts = acts;
            this.IdCareStaff = idCareStaff;
            this.IdCitizen = idCitizen;
            this.SetDate(created);
        }


        #endregion

        #region Properties
        public List<Act> Acts { get; private set; }

        public DateTime Created { get; private set; }

        [ForeignKey("Caregiver")]
        public int IdCareStaff { get; private set;}
        public CareStaff Caregiver { get; private set;  }

        [ForeignKey("CareFor")]
        public int IdCitizen { get; private set; }
        public Citizen CareFor { get; private set; }
        #endregion

        #region Setters
        private void SetDate(DateTime? created)
        {
            this.Created = created == null ? DateTime.Now : (DateTime)created;
        }
        #endregion  
    }
}
