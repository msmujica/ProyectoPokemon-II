namespace Library.Items;

public class ItemCuraTotal : IItem
{
    
    public void Usar(Pokemon pokemon)
    {
        GestorEfectos.LimpiarEfectos(pokemon);
    }
}