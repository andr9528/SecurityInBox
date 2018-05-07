using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityInAMobile
{

    public class BurgerMenuItem
    {
        public BurgerMenuItem()
        {
            TargetType = typeof(BurgerDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}