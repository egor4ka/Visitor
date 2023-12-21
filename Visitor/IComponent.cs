using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    public abstract class IComponent
    {
        public List<IComponent> components = new List<IComponent>();
        public int counter = 0;

        public virtual IComponent Next()
        {
            if (IsNext())
            {
                if (!components[counter].IsNext())
                {
                    counter++;
                    if (IsNext())
                        return Next();
                    else
                        throw new Exception("Вы дошли до конца!");
                }
                return components[counter].Next();
            }
            else
            {
                throw new Exception("Вы дошли до конца!");
            }
        }
        public bool IsNext()
        {
            return counter < components.Count;
        }
        public abstract void Add(IComponent component);
        public abstract void Remove(IComponent component);
        public abstract void Accept(Visitor visitor);
        public abstract void Print();
    }
}
