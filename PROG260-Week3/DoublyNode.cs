
using Microsoft.VisualBasic;

namespace PROG260_Week3
{
    public class DoublyNode<T> 
    {
        public T Data { get; protected set;}

        public DoublyNode<T>? Previous { get; protected set;}
        public DoublyNode<T>? Next { get; protected set;}

        public DoublyNode()
        {

        }

        public DoublyNode(T data, DoublyNode<T> previous)
        {
            Data = data;
            Previous = previous;
            if(Previous != null) Previous.SetNext(this);
        }

        public void SetNext(DoublyNode<T> next)
        {
            Next = next;
        }

        public override string ToString()
        {
            string PrevData = "Null";
            string NextData = "Null";

            if(Previous != null) PrevData = Previous.Data.ToString();
            if(Next != null) NextData = Next.Data.ToString();

            return $"{PrevData} {Data} {NextData}";
        }
    }
}