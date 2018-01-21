namespace FcLinkedList.Model
{
    public class FcNode<T>
    {
        public T value { get; set; }

        public FcNode<T> Next { get; set; }

        public FcNode()
        {
            Next = null;
            value = default(T);
        }

        public FcNode(T value)
        {
            Next = null;
            this.value = value;
        }
    }
}
