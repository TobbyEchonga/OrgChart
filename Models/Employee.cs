using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrgChart.Models
{
    public class Employee
    {
        [Key]
        public string RecordId { get; set; }

        public string id { get; set; }

        public string pid { get; set; }

        public string Title { get; set; }

        public string name { get; set; }

        [NotMapped]
        public string[] tags
        {
            get
            {
                if (string.IsNullOrEmpty(InternalTags))
                {
                    return new string[0];
                }
                else
                {
                    return InternalTags.Split(',');
                }
            }
            set
            {
                if (value == null)
                {
                    InternalTags = "";
                }
                else
                {
                    InternalTags = string.Join(",", value);
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string InternalTags { get; set; }
    }
}
