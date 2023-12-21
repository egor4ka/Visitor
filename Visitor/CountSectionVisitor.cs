using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    public class CountSectionVisitor : Visitor
    {
        public int sectionCount { get; private set; }
        public override void Visit(IComponent component)
        {
            if (component == null)
            {
                throw new NotImplementedException();
            }
            if (component is Section section)
            {
                sectionCount++;
            }
        }
        public object GetResult()
        {
            return sectionCount;
        }
    }
}