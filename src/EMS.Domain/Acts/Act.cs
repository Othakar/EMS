using EMS.Records;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace EMS.Acts
{
    public class Act : Entity<int>, ISoftDelete
    {
        #region Constructors
        private Act() {
        }

        public Act(string name, int price, string description, ActType type)
        {
            Name = name;
            this.SetPrice(price);
            Description = description;
            Type = type;
        }
        #endregion

        #region Propeties
        [Required]
        public string Name { get; private set; }

        [Required]
        public int Price { get; private set; }

        [Required]
        public string Description { get; private set; }

        [Required]
        public ActType Type { get; private set; }

        [ForeignKey("ActRecord")]
        public int RecordId { get; private set; }

        public Record ActRecord { get; private set; }
        
        public bool IsDeleted { get; set; }

        #endregion

        #region Setters
        private void SetPrice(int price)
        {
            if(price <= 0)
            {
                throw new BusinessException(EMSErrorCodes.ActionPriceMustBeGreaterThanZero);
            }
            this.Price = price;
        } 
        #endregion
    }
}
