namespace Cyan.WebAPI.Constants
{
    public class BetHistoryResourcesNames
    {
        public static class Routes
        {
            public const string GetQuery = "Resource_BetHistory_Get_Query";
            public const string GetById = "Resource_BetHistory_Get_Id";
            public const string PostCreate = "Resource_BetHistory_Post_Create";
            public const string PutUpdate = "Resource_BetHistory_Put_Update";
            public const string Patch = "Resource_BetHistory_Patch";
            public const string Delete = "Resource_BetHistory_Delete";
            public const string Delete_Country = "Resource_BetHistory_Delete_Country";
            public const string Put_Country = "Resource_BetHistory_Put_Country";
            public const string GetBetHistoryByMerchant = "Resource_BetHistory_Get_Merchant_By_Id";
            public const string PostBetHistoryByMerchant = "Resource_BetHistory_Post_Merchant_By_Id";
            public const string GetQueryByAlternativeMethods = "Resource_BetHistory_Get_Alternative_Mehtods";   
        }

        public static class Profiles
        {
            public const string BetHistoryV1 = "itcyan:bethistory:v1";
        }
    }
}
