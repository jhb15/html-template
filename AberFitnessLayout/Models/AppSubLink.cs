using System;
using System.ComponentModel.DataAnnotations;

namespace AberFitnessLayout.Models
{
    public class AppSubLink
    {
        [Key]
        public virtual int Id { get; set; }

        [Required]
        public virtual string IconName { get; set; }

        [Required]
        public virtual string DisplayName { get; set; }

        [Required]
        [Url]
        public virtual string Uri { get; set; }

        [Required]
        public virtual AppLinkAccessLevel AccessLevel { get; set; }

        [Required]
        public virtual int AppLinkId { get; set; }
    }
}
