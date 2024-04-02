using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Utility
{
    [Serializable]
    public class SLL : ILinkedListADT
    {
        
        private Node head;
      
        private Node tail;
      
        private int count = 0;
        public SLL()
        {
            head = tail = null;
            count = 0;
        }

        public bool IsEmpty()
        {
            return (count == 0);
        }

        public void Clear()
        {
            head = tail = null;
            count = 0;
        }

        public void AddLast(User value)
        {
            if (!IsEmpty())
            {
                tail.Next = new Node(value);
                tail = tail.Next;
            }
            else
            {
                head = tail = new Node(value);
            }
            count++;
        }

        public void AddFirst(User value)
        {
            Node newNode = new Node(value);
            newNode.Next = head;
            head = newNode;
            count++;
        }

        public void Add(User value, int index)
        {
            if (index < 0 || index > count)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                Node newNode = new Node(value);
                if (index != 0)
                {
                    Node current = head;
                    for (int i = 0; i < index - 1; i++)
                    {
                        current = current.Next;
                    }
                    newNode.Next = current.Next;
                    current.Next = newNode;
                }
                else
                {
                    newNode.Next = head;
                    head = newNode;
                }

            }
            count++;
        }

        public void Replace(User value, int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException();
            }
            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            current.Element = value;
        }

        public int Count()
        {
            return count;
        }

        public void RemoveFirst()
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty.");
            }
            head = head.Next;
            count--;
        }

        public void RemoveLast()
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty.");
            }
            if (count == 1)
            {
                head = tail = null;
            }
            else
            {
                Node current = head;
                while (current.Next != tail)
                {
                    current = current.Next;
                }
                current.Next = null;
                tail = current;
            }
            count--;
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException();
            }
            if (index == 0)
            {
                head = head.Next;
            }
            else
            {
                Node current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                current.Next = current.Next.Next;

                if (index == count - 1)
                {
                    tail = current;
                }
            }
            count--;
        }

        public User GetValue(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException();
            }
            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return (User)current.Element;
        }

        public int IndexOf(User value)
        {
            Node current = head;
            int currentIndex = 0;

            while (current != null)
            {
                if (current.Element.Equals(value))
                {
                    return currentIndex;
                }

                current = current.Next;
                currentIndex++;
            }

            return -1;
        }

        public bool Contains(User value)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Element.Equals(value))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }
        public void Reverse()
        {
            Node previous = null;
            Node current = head;
            Node next = null;

            while (current != null)
            {
                next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }

            head = previous;
        }
    }
}
