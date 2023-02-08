using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZetaVARDataExchange
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);

    public class GetPackageList
    {
        public string id { get; set; }
        public int rowNumber { get; set; }
        public Note note { get; set; }
        public CreatedBy CreatedBy { get; set; }
        public Description Description { get; set; }
        public LastModifiedOn LastModifiedOn { get; set; }
        public Level Level { get; set; }
        public ProjectName ProjectName { get; set; }
        public Published Published { get; set; }
        public ScreenNames ScreenNames { get; set; }
        public Selected Selected { get; set; }
        public Custom custom { get; set; }
    }

    public class CreatedBy
    {
        public string value { get; set; }
    }
  
    public class Description
    {
        public string value { get; set; }
    }

    public class LastModifiedOn
    {
        public DateTime value { get; set; }
    }

    public class Level
    {
        public int? value { get; set; }
    }

    public class Note
    {
        public string value { get; set; }
    }

    public class ProjectName
    {
        public string value { get; set; }
    }

    public class Published
    {
        public bool value { get; set; }
    }
  
    public class ScreenNames
    {
    }

    public class Selected
    {
        public bool value { get; set; }
    }


}
