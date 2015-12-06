using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace KPaTS.Models
{
    public class InfoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public UserProfile Creator { get; set; }

        [Required]
        [AllowHtml]
        public string Body { get; set; }

        [NotMapped]
        public string StrippedBody {
            get
            {
                Regex rgx = new Regex(@"<abbr [^>]*>(.*?)< *\/ *abbr *>");
                var result = rgx.Matches(Body);
                string strippedBody = Body;
                foreach (Match match in result)
                {
                    strippedBody = strippedBody.Replace(match.Value, match.Groups[1].Value);
                }
                return strippedBody;
            }
        }

        public virtual ICollection<TestModel> Tests { get; set; }
    }
}