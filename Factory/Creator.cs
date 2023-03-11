using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public abstract class Creator
    {
        public abstract IEnemy create();


    }

    public class ConcreteSkeleton:Creator
    {
        public override IEnemy create()
        {
            return new Skeleton("Skeleton",10,10);
        }
    }
}
