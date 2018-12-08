using System;
using System.ComponentModel.DataAnnotations;

namespace AberFitnessLayout.Models
{
    public class AppSubLink
    {
        [Required]
        public virtual string DisplayName { get; set; }

        [Required]
        public virtual Uri Uri { get; set; }

        [Required]
        public virtual AppLinkAccessLevel AccessLevel { get; set; }
    }
}
