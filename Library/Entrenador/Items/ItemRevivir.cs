namespace Library.Items;

public class ItemRevivir : IItem
{
    public int Contador { get; set; }
    public void Usar(Pokemon pokemon)
    {
            pokemon.EstaDerrotado = false;
            pokemon.Vida = (int)(100 * 0.5);   
        
    }
}