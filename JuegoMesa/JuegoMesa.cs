using System;
class JuegoMesa
{
    private byte edadMinima, minimoJugadores, maximoJugadores;
    private string nombre;
    public float precio;

    public JuegoMesa()
    {
        edadMinima = 0;
        minimoJugadores = 0;
        maximoJugadores = 0;
        nombre = "";
        precio = 0.0f;
    }
    public JuegoMesa(byte edadMinima, byte minimoJugadores, byte maximoJugadores, string nombre, float precio)
    {
        this.EdadMinima = edadMinima;
        this.MinimoJugadores = minimoJugadores;
        this.MaximoJugadores = maximoJugadores;
        this.nombre = nombre;
        this.Precio = precio;

    }

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

    public string Nombre
    {
        get
        {
            return nombre;
        }
        set
        {
            nombre = value;
        }
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