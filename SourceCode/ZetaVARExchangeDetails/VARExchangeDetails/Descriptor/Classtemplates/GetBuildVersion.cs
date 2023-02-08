using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZetaVARDataExchange
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);


    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    public class CurrentVersion
    {
        public string value { get; set; }
    }

    public class Custom
    {
    }

    public class LastUpdateDate
    {
        public DateTime value { get; set; }
    }

    public class GetBuildVersion
    {
        public string id { get; set; }
        public int rowNumber { get; set; }
        public object note { get; set; }
        public CurrentVersion CurrentVersion { get; set; }
        public LastUpdateDate LastUpdateDate { get; set; }
        public Custom custom { get; set; }
    }



  


}
