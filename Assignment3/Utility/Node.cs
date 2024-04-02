using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Utility
{
    [Serializable]
    public class Node
    {
        
        private User element;
       
        private Node next;

        public Node(User o)
        {
            this.Element = o;
        }

        public Node(User o, Node n)
        {
            this.Element = o;
            this.Next = n;
        }

        public User Element { get => element; set => element = value; }
        public Node Next { get => next; set => next = value; }
    }
}
