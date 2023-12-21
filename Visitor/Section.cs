using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    public class Section : IComponent
    {
        private string _name;
        public Section(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name), "Пустое значение имени!");
            }
            _name = name;
        }
        public override void Add(IComponent component)
        {
            if (component == null)
            {
                throw new ArgumentNullException(nameof(component), "Пустое значение!");
            }
            components.Add(component);
        }
        public override void Remove(IComponent component)
        {
            if (component == null)
            {
                throw new ArgumentNullException(nameof(component), "Пустое значение!");
            }
            if (!components.Contains(component))
            {
                throw new InvalidOperationException("Пустое значение!");
            }
            components.Remove(component);
        }
        public override void Accept(Visitor visitor)
        {
            if (visitor == null) { throw new ArgumentNullException(nameof(visitor), "Пустое значение!"); }
            visitor.Visit(this);
        }
        public override void Print()
        {
            Console.WriteLine($"{_name} :");
            foreach (var component in components)
            {
                component.Print();
            }
        }
    }
}