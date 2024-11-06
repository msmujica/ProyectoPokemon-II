namespace Library.Items;

public class ItemSuperPocion : IItem
{
    public int Contador { get; set; }
    public void Usar(Pokemon pokemon)
    {
        if (pokemon.Vida + 70 > 100)
        {
            pokemon.Vida = 100;
        }
        else
        {
            pokemon.Vida += 70;
        }
    }
}