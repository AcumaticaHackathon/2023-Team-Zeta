using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZetaVARDataExchange
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);

    public class GetTenantDetails
    {
        public string id { get; set; }
        public int rowNumber { get; set; }
        public object note { get; set; }
        public CloudTenantID CloudTenantID { get; set; }
        public LoginName LoginName { get; set; }
        public Status Status { get; set; }
        public TenantID TenantID { get; set; }
        public TenantName TenantName { get; set; }
        public Custom custom { get; set; }
    }

    public class CloudTenantID
    {
        public string value { get; set; }
    }

    public class LoginName
    {
        public string value { get; set; }
    }

    public class Status
    {
        public string value { get; set; }
    }

    public class TenantID
    {
        public int value { get; set; }
    }

    public class TenantName
    {
        public string value { get; set; }
    }



}
