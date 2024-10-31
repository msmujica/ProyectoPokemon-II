using System.Collections.Generic;
using System.Linq;

namespace Library;

public class Tipos
{
    private string nombre;
    private List<Tipos> debil;
    private List<Tipos> resistente;
    private List<Tipos> inmune;

    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

    public List<Tipos> Debil
    {
        get { return debil; }
        set { debil = value; }
    }

    public List<Tipos> Resistente
    {
        get { return resistente; }
        set { resistente = value; }
    }

    public List<Tipos> Inmune
    {
        get { return inmune; }
        set { inmune = value; }
    }

    public Tipos(string nombre)
    {
        this.Nombre = nombre;
    }

    public void AgregarDebilidades(List<Tipos> debil)
    {
        this.Debil = debil;
    }

    public void EliminarDebilidades(Tipos tipo)
    {
        this.Debil.Remove(tipo);
    }

    public void AgregarResistencia(List<Tipos> resistente)
    {
        this.Resistente = resistente;
    }

    public void EliminarResistencia(Tipos tipo)
    {
        this.Resistente.Remove(tipo);
    }

    public void AgregarInmune(List<Tipos> inmune)
    {
        this.Inmune = inmune;
    }

    public void EliminarInmune(Tipos tipo)
    {
        this.Inmune.Remove(tipo);
    }

    public double multiplicadorDaño(Tipos tipoAtaque)
    {
        if (this.Debil.Contains(tipoAtaque))
        {
            return 2.0;
        }
        if (this.Resistente.Contains(tipoAtaque))
        {
            return 0.5;
        }

        if (this.Inmune.Contains(tipoAtaque))
        {
            return 0.0;
        }

        return 1.0;
    }
}