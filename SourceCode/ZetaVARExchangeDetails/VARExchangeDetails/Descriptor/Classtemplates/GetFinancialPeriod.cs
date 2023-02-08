using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZetaVARDataExchange
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    public class GetFinancialPeriod
    {
        public string id { get; set; }
        public int rowNumber { get; set; }
        public Note note { get; set; }
        public FinancialYear FinancialYear { get; set; }
        public List<FinDetail> FinDetails { get; set; }
        public NumberofPeriods NumberofPeriods { get; set; }
        public StartDate StartDate { get; set; }
        public UserDefinedPeriods UserDefinedPeriods { get; set; }
        public Custom custom { get; set; }
    }


    public class AdjustmentPeriod
    {
        public bool value { get; set; }
    }

    public class ClosedinAP
    {
        public bool value { get; set; }
    }

    public class ClosedinAR
    {
        public bool value { get; set; }
    }

    public class ClosedinCA
    {
        public bool value { get; set; }
    }

    public class ClosedinFA
    {
        public bool value { get; set; }
    }

    public class ClosedinGL
    {
        public bool value { get; set; }
    }

    public class ClosedinIN
    {
        public bool value { get; set; }
    }

    

    public class EndDate
    {
        public DateTime value { get; set; }
    }

    public class FinancialPeriodID
    {
        public string value { get; set; }
    }

    public class FinancialYear
    {
        public string value { get; set; }
    }

    public class FinDetail
    {
        public string id { get; set; }
        public int rowNumber { get; set; }
        public Note note { get; set; }
        public AdjustmentPeriod AdjustmentPeriod { get; set; }
        public ClosedinAP ClosedinAP { get; set; }
        public ClosedinAR ClosedinAR { get; set; }
        public ClosedinCA ClosedinCA { get; set; }
        public ClosedinFA ClosedinFA { get; set; }
        public ClosedinGL ClosedinGL { get; set; }
        public ClosedinIN ClosedinIN { get; set; }
        public Description Description { get; set; }
        public EndDate EndDate { get; set; }
        public FinancialPeriodID FinancialPeriodID { get; set; }
        public LengthDays LengthDays { get; set; }
        public StartDate StartDate { get; set; }
        public Status Status { get; set; }
        public Custom custom { get; set; }
    }

    public class LengthDays
    {
        public int value { get; set; }
    }

   
    public class NumberofPeriods
    {
        public int value { get; set; }
    }

  
    public class StartDate
    {
        public DateTime value { get; set; }
    }

  
    public class UserDefinedPeriods
    {
        public bool value { get; set; }
    }


   

}
