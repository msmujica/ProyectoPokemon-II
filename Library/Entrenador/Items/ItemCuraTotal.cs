namespace Library.Items;

public class ItemCuraTotal : IItem
{
    public int Contador { get; set; }
    public void Usar(Pokemon pokemon)
    {
            GestorEfectos.LimpiarEfectos(pokemon);
        
    }
}