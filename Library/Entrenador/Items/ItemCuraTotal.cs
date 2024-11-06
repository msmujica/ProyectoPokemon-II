namespace Library.Items;

public class ItemCuraTotal : IItem
{
    public int Contador { get; set; } = 2;
    public void Usar(Pokemon pokemon)
    {
            GestorEfectos.LimpiarEfectos(pokemon);
        
    }
}