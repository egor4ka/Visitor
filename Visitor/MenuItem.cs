using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    public class MenuItem : IComponent
    {
        public string name { get; private set; }
        public bool isVegan { get; private set; }
        public MenuItem(string name, bool isVegan)
        {
            if (name == null) { throw new ArgumentNullException(nameof(name), "Пустое имя!"); }
            this.name = name;
            this.isVegan = isVegan;
        }
        public override void Add(IComponent component)
        {
            if (component == null) { throw new ArgumentNullException(nameof(component), "Пустой компонент!"); }
            throw new InvalidOperationException("Вы не можете добавить это к блюду!");
        }
        public override void Remove(IComponent component)
        {
            if (component == null) { throw new ArgumentNullException(nameof(component), "Пустой компонент!"); }
            throw new InvalidOperationException("Вы не можете удалить это из блюда!");
        }
        public override void Accept(Visitor visitor)
        {
            if (visitor == null) { throw new ArgumentNullException(nameof(visitor), "Пустой компонент!"); }
            visitor.Visit(this);
        }
        public override void Print()
        {
            string isVeg = isVegan ? "(Веганское блюдо)" : "Не веганское блюдо";
            Console.WriteLine($"{name} {isVeg}");
        }
    }
}