using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AberFitnessLayout.Models
{
    public class AppLink
    {
        public virtual string DisplayName { get; set; }

        public virtual Uri Uri { get; set; }
    }
}
