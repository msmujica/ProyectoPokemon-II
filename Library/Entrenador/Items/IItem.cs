namespace Library.Items;

public interface IItem
{
    int Contador { get; }
    void Usar(Pokemon pokemon);
}