namespace FcLinkedList.Model
{
    public class FcLinkedList<T>
    {
        private FcNode<T> Head;

        public FcLinkedList()
        {
            Head = new FcNode<T>();
        }

        public void AddFirst(T value)
        {
            FcNode<T> newNode = new FcNode<T>(value);

            if(Head.Next == null)
            {
                Head.Next = newNode;
            }
            else
            {
                var aux = Head.Next;
                newNode.Next = aux;
                Head.Next = newNode;
            }
        }

        public bool Remove(T toRem)
        {
            if(Head?.Next == null)
            {
                return false;
            }

            FcNode<T> sNode = Head.Next;

            while (sNode != null)
            {
                if (sNode.Next.value.Equals(toRem))
                {
                    var nextNode = sNode.Next.Next;
                    sNode.Next = nextNode;
                    return true;
                }

                sNode = sNode.Next;
            }

            return false;
        }

        public int Count()
        {
            int count = 0;
            if(Head?.Next == null)
            {
                return count;
            }

            FcNode<T> sNode = Head.Next;
            while (sNode != null)
            {
                count++;
                sNode = sNode.Next;
            }

            return count;
        }
    }
}
