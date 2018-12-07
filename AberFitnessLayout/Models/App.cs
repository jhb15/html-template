using System;
using System.Collections.Generic;

namespace AberFitnessLayout.Models
{
    public class App
    {
        public virtual string DisplayName { get; set; }

        public virtual Uri Uri { get; set; }

        public virtual IList<AppLink> AppLinks { get; set; }
    }
}
