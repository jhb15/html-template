using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AberFitnessLayout.Models
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
        public virtual string IconName { get; set; }

        [Required]
        public virtual string DisplayName { get; set; }

        [Url]
        public virtual string Uri { get; set; }

        [Required]
        public virtual IList<AppSubLink> SubLinks { get; set; }

        [Required]
        public virtual AppLinkAccessLevel AccessLevel { get; set; }
    }
}
