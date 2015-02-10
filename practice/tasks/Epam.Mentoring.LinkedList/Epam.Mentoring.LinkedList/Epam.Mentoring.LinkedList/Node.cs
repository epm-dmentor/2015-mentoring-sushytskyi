namespace Epam.Mentoring.LinkedList
{
    public class Node
    {
        public object Value { get; set; }
        public Node Previous { get; set; }
        public Node Next { get; set; }
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
