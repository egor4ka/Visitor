using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    public class ObjectStruct
    {
        private IComponent _root;
        public ObjectStruct(IComponent root)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root), " Пустое значение!");
            }
            _root = root;
        }
        public void Accept(Visitor visitor)
        {
            List<IComponent> components = new List<IComponent>();
            IComponent root = _root;
            while (root != null || components.Count > 0)
            {
                while (root != null)
                {
                    components.Add(root);
                    root = root.IsNext() ? root.Next() : null;
                }
                int lastIndex = components.Count - 1;
                root = components[lastIndex];
                components.RemoveAt(lastIndex);
                root.Accept(visitor);
                root = root.IsNext() ? root.Next() : null;
            }
        }
    }
}