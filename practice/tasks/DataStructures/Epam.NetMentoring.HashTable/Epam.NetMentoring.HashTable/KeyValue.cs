namespace Epam.NetMentoring.HashTable
{
    public class KeyValue
    {
        public WordEntity Key { get; set; }
        public WordDefinition Value { get; set; }

        public KeyValue(WordEntity key, WordDefinition value)
        {
            Key = key;
            Value = value;
        }

        public KeyValue(){}
    }
}
