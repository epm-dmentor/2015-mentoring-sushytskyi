namespace Epam.NetMentoring.HashTable
{
    public interface IHashTable
    {
        WordDefinition this[WordEntity key] { get; set; }
    }
}