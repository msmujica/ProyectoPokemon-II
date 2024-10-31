namespace Library;

public abstract class Efecto
{
    public abstract void IniciarEfecto(Pokemon pokemon);
    public abstract bool ProcesarEfecto(Pokemon pokemon);
}