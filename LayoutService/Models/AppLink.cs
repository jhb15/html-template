using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LayoutService.Models
{
    public class AppLink
    {
        public AppLink()
        {
            SubLinks = new List<AppSubLink>();
        }

        [Key]
        public virtual int Id { get; set; }

        [Required]
        [Display(Name = "FontAwesome Icon")]
        public virtual string IconName { get; set; }

        [Required]
        [Display(Name = "Name")]
        public virtual string DisplayName { get; set; }

        [Required]
        [Display(Name = "URI")]
        public virtual string Uri { get; set; }

        [Required]
        public virtual IList<AppSubLink> SubLinks { get; set; }

        [Required]
        [Display(Name = "Access Level")]
        public virtual AppLinkAccessLevel AccessLevel { get; set; }

        [Required]
        [Range(0, 10000)]
        [Display(Name = "Link Priority")]
        public virtual int Priority { get; set; }
    }
}
