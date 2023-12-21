using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    public class CountVeganVisitor : Visitor
    {
        public int veganCount { get; private set; }
        public override void Visit(IComponent component)
        {
            if (component == null) { throw new ArgumentNullException(nameof(component), "Пустое значение!"); }
            if (component is MenuItem menuItem && menuItem.isVegan)
            {
                veganCount++;
            }
        }
        public object GetResult()
        {
            return veganCount;
        }
    }
}