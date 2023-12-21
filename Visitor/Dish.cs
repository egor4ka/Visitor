using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    public class Dish : IComponent
    {
        private string _name;
        private bool _isVegan;
        public Dish(string name, bool isVegan)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name), "Пустое значение имени!");
            }
            _name = name;
            _isVegan = isVegan;
        }
        public override void Add(IComponent component)
        {
            if (component == null) { throw new ArgumentNullException(nameof(component), "Пустой компонент!"); }
            throw new InvalidOperationException("Блюдо не изменяется!");
        }
        public override void Remove(IComponent component)
        {
            if (component == null)
            {
                throw new ArgumentNullException(nameof(component), "Пустой компонент!");
            }
            throw new InvalidOperationException("Блюдо не изменяется!");
        }
        public override void Accept(Visitor visitor)
        {
            if (components == null) { throw new ArgumentNullException(nameof(visitor), "Пустое значение!"); }
            visitor.Visit(this);
        }
        public override void Print()
        {
            string isVegan = _isVegan ? "Веганское блюдо" : "Не веганское блюдо";
            Console.WriteLine($"{_name} {isVegan}");
        }
    }
}