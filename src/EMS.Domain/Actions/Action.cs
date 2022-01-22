using System.ComponentModel.DataAnnotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace EMS.Actions
{
    public class Action : Entity<int>
    {
        #region Constructors
        internal Action() { }

        internal Action(string name, int price, string description, ActionType type)
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
        public ActionType Type { get; private set; }

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
