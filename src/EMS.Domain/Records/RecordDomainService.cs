using EMS.Acts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace EMS.Records
{
    public class RecordDomainService
    {
        private readonly IRepository<Record, int> _recordRepository;

        public RecordDomainService(IRepository<Record, int> recordRepository)
        {
            _recordRepository = recordRepository;
        }

        public virtual async Task<Record> Create(List<Act> acts, int idCareStaff, int idCitizen, DateTime? created = null)
        {
            var newRecord = new Record(acts, idCareStaff, idCitizen, created);
            return await _recordRepository.InsertAsync(newRecord);
        }
    }
}
