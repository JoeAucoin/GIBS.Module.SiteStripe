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
        public int SiteId { get; set; } = 0;
        public string Name { get; set; }
        public string ASIN { get; set; }
        public string AffiliateURL { get; set; }
        public string ImageURL { get; set; }
        public decimal? PricePoint { get; set; }
        public string ProductCategory { get; set; }
        public int CategoryId { get; set; }
        public bool IsPrimeEligible { get; set; }
        public bool IsActive { get; set; } = true;
        public string DisplayTemplate { get; set; }
        public bool OpenInNewTab { get; set; } = true;
        public string RelAttribute { get; set; }
        public string RawHTMLEmbed { get; set; }
        public string VideoURL { get; set; }
        [NotMapped]
        public string SmallName => Name.Length > 35 ? Name.Substring(0, 32) + "..." : Name;
        [NotMapped]
        public string CategoryName { get; set; }
    }

}
