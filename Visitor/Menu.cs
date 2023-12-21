using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    public class Menu : IComponent
    {
        private string _name;
        public Menu(string name)
        {
            if (string.IsNullOrEmpty(name)) { throw new ArgumentNullException(nameof(name), "Пустое значение имени!"); }
            _name = name;
        }
        public override void Add(IComponent component)
        {
            if (component == null) { throw new ArgumentNullException(nameof(component), "Пустое значение компонента!"); }
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
                throw new InvalidOperationException("Блюдо не обнаружено!");
            }
            components.Remove(component);
        }
        public override void Accept(Visitor visitor)
        {
            if (visitor == null)
            {
                throw new ArgumentNullException(nameof(visitor), "Пустое значение!");
            }
            foreach (var component in components)
            {
                component.Accept(visitor);
            }
        }
        public override void Print()
        {
            Console.WriteLine($"Меню {_name}:");
            foreach (var component in components)
            {
                component.Print();
            }
        }
    }
}