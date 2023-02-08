using System;

namespace ZetaVARDataExchange
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    public class GetLicenseStatus
    {     
        public NumberofProcessors NumberofProcessors { get; set; }
        public NumberofTenants NumberofTenants { get; set; }
        public NumberofUsers NumberofUsers { get; set; }       
        public Status Status { get; set; }
        public Valid Valid { get; set; }
        public ValidFrom ValidFrom { get; set; }
        public ValidTo ValidTo { get; set; }
        public Version Version { get; set; }
    }

    public class NumberofProcessors
    {
        public int value { get; set; }
    }

    public class NumberofTenants
    {
        public int value { get; set; }
    }

    public class NumberofUsers
    {
        public int value { get; set; }
    }

    public class Valid
    {
        public bool value { get; set; }
    }

    public class ValidFrom
    {
        public DateTime value { get; set; }
    }

    public class ValidTo
    {
        public DateTime value { get; set; }
    }

    public class Version
    {
        public string value { get; set; }
    }


}
