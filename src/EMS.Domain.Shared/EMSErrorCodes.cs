
namespace EMS
{
    public static class EMSErrorCodes
    {
        #region Citizen
        public const string CitizenAlreadyExist = "EMS:1001";
        public const string CitizenSizeMustBeGreaterThanZero = "EMS:1002";
        public const string CitizenWeightMustBeGreaterThanZero = "EMS:1002";
        public const string CitizenDoNotExist = "EMS:1003";
        #endregion

        #region Action
        public const string ActionPriceMustBeGreaterThanZero = "EMS:2001";
        public const string ActionAlreadyExist = "EMS:2002";
        #endregion
    }
}
