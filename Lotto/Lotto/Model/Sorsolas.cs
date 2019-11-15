using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto.Model
{
    class Sorsolas
    {
        public DateTime sorsolasDatum { get; set; }
        public List<int> nyeroSzamok { get; set; }

        public Sorsolas(DateTime sorsolasDatum)
        {
            this.sorsolasDatum = sorsolasDatum;
        }
    }
}
