using Oqtane.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GIBS.Module.SiteStripe.Models
{
    [Table("GIBS_SiteStripe_Category")]
    public class Category : ModelBase
    {
        [Key]
        public int CategoryId { get; set; }
        public int ModuleId { get; set; }
        public int SiteId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public int ParentId { get; set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }

        [NotMapped]
        public List<Category> Children { get; set; } = new List<Category>();
    }
}
