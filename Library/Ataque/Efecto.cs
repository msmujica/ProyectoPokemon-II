namespace Library;

public interface Efecto
{
    public void IniciarEfecto(Pokemon pokemon);
    public bool ProcesarEfecto(Pokemon pokemon);
}