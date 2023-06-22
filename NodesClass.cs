using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog7312_task1
{
    public class NodesClass
    {
      public NodesClass(string value)
    {
        Value = value;
        Children = new List<NodesClass>();
    }

    public string Value { get; }

    public List<NodesClass> Children{ get; }

        public void PrintNode(string indent, bool last)
        {
            Console.Write(indent);
            if (last)
            {
                Console.Write("\\-");
                indent += "  ";
            }
            else
            {
                Console.Write("|-");
                indent += "| ";
            }
            Console.WriteLine(Value);

            for (int i = 0; i < Children.Count; i++)
                Children[i].PrintNode(indent, i == Children.Count - 1);
        }

       

    }

    }


















