using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace EMS.Records
{
    public class Record : Entity<int>
    {
        #region Constructors
        private Record() { }

        public Record(List<Action> actions, int idCareStaff, int idCitizen, DateTime? created = null)
        {
            this.Actions = actions;
            this.IdCareStaff = idCareStaff;
            this.IdCitizen = idCitizen;
            this.SetDate(created);
        }


        #endregion

        #region Properties
        public List<Action> Actions { get; private set; }
        public DateTime Created { get; private set; }
        public int IdCareStaff { get; private set; }
        public int IdCitizen { get; private set; }
        #endregion

        #region Setters
        private void SetDate(DateTime? created)
        {
            this.Created = created == null ? DateTime.Now : (DateTime)created;
        }
        #endregion  
    }
}
