namespace ZetaVARDataExchange
{
    public class ZetaVARConstants
    {
        //Standard Constants
        public const string ProcessData = "Process Data";
        public const string Process = "Process";
        public const string ContentType = "application/json";
        public const string Authorization = "Authorization";       
        public const string ViewExchangeDetails = "View Exchange Details";

        //Endpoint Url
        public const string EntityNameAndVersion = "/entity/VAREXCHANGE/20.200.001/";
        public const string LoginUrl = "/entity/auth/login";
        public const string LogOutUrl = "/entity/auth/logout";

        //Methods
        public const string Post = "Post";
        public const string Put = "Put";
        public const string Delete = "Delete";
        public const string Get = "Get";

        //Entity Names
        public const string GetBuildVersion = "GetBuildVersion";
        public const string GetFinancialPeriod = "GetFinancialPeriod";
        public const string GetLicenseDetails = "GetLicenseDetails";
        public const string GetLicenseStatus = "GetLicenseStatus";
        public const string GetPackageList = "GetPackageList"; 
        public const string GetTenantDetails = "GetTenantList";
        public const string GetSystemEvents = "GetSystemEvents";
    }

    public class StatusCode
    {
        public const string UnprocessableEntity = "422";
        public const string Accepted = "202";
        public const string Ok = "200";
        public const string Ok_200 = "OK";
    }
}