
namespace ZetaVARDataExchange
{
    public class GetLicenseDetails
    {
        public CommercialTransactionsofLimit CommercialTransactionsofLimit { get; set; }
        public ERPTransactionsofLimit ERPTransactionsofLimit { get; set; }
        public LicenseStatus LicenseStatus { get; set; }
        public LicenseTier LicenseTier { get; set; }
        public Month Month { get; set; }
      
    }

    public class CommercialTransactionsofLimit
    {
        public string value { get; set; }
    }

   
    public class ERPTransactionsofLimit
    {
        public string value { get; set; }
    }

    public class LicenseStatus
    {
        public string value { get; set; }
        public string error { get; set; }
    }

    public class LicenseTier
    {
        public string value { get; set; }
    }

    public class Month
    {
        public string value { get; set; }
    }

}
