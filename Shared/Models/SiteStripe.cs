using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace GIBS.Module.SiteStripe.Models
{
    [Table("GIBS_SiteStripe")]
    public class SiteStripe : ModelBase
    {
        [Key]
        public int SiteStripeId { get; set; }
        public int ModuleId { get; set; }
        public string Name { get; set; }
    }
}
