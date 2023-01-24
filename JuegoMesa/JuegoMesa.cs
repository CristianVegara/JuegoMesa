using System;
class JuegoMesa
{
    private byte edadMinima, minimoJugadores, maximoJugadores;
    private string nombre;
    private float precio;

    public byte EdadMinima
    {
        get
        {
            return edadMinima;
        }
        set
        {
            if (value >= 0)
                edadMinima = value;
            else
                edadMinima = 0;
        }
    }
    public byte MinimoJugadores
    {
        get
        {
            return minimoJugadores;
        }
        set
        {
            if (value >= 0)
                minimoJugadores = value;
            else
                minimoJugadores = 0;
        }
    }
    public byte MaximoJugadores
    {
        get
        {
            return maximoJugadores;
        }
        set
        {
            if (value >= 0)
                maximoJugadores = value;
            else
                maximoJugadores = 0;
        }
    }

    public string GetTituloJuego()
    {
        return nombre;
    }
    public void SetTituloJuego(string nombre)
    {
        this.nombre = nombre;
    }
    public float Precio
    {
        get
        {
            return precio;
        }
        set
        {
            if (value >= 0)
                precio = value;
            else
                precio = 0;
        }
    }

    public void Mostrar()
    {
        Console.WriteLine("{0} ({1}, {2} - {3}): {4} euros.",
             nombre, edadMinima, minimoJugadores, maximoJugadores, precio);
    }
}