namespace Library.Items;

public class ItemRevivir : IItem
{
    public void Usar(Pokemon pokemon)
    {
        if (pokemon.EstaDerrotado)
        {
            pokemon.EstaDerrotado = false;
            pokemon.Vida = (int)(100 * 0.5);   
        }
    }
}