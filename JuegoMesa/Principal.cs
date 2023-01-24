using System;
using System.Text;

class Principal
{
    enum opciones { SALIR, INSERTAR, BORRAR, CARO, TITULO }

    static int MostrarMenu()
    {
        int opcion;

        Console.WriteLine("Menú de opciones:");
        Console.WriteLine((int)opciones.INSERTAR +
            ". Nuevo juego");
        Console.WriteLine((int)opciones.BORRAR +
            ". Borrar juego");
        Console.WriteLine((int)opciones.CARO +
            ". Juego más caro");
        Console.WriteLine((int)opciones.TITULO +
            ". Juegos por titulo");
        Console.WriteLine((int)opciones.SALIR +
            ". Salir");
        Console.WriteLine("Elige una opción del menú:");

        opcion = Convert.ToInt32(Console.ReadLine());

        return opcion;
    }


    static void RecogerInfoJuego(out JuegoMesa nuevoJuego, ref bool errorCatch)
    {
        nuevoJuego = new JuegoMesa();
        Console.Write("Nombre del juego: ");
        nuevoJuego.Nombre = Console.ReadLine();

        Console.WriteLine("Información del juego: ");

        Console.Write(" -Edad minima: ");
        nuevoJuego.EdadMinima =
            Convert.ToByte(Console.ReadLine());

        Console.Write(" -Mínimo de jugadores: ");
        nuevoJuego.MinimoJugadores =
            Convert.ToByte(Console.ReadLine());

        Console.Write(" -Máximo de jugadores: ");
        nuevoJuego.MaximoJugadores =
            Convert.ToByte(Console.ReadLine());

        Console.Write("Precio del juego: ");
        if (!float.TryParse(Console.ReadLine(), out nuevoJuego.precio))
        {
            errorCatch = true;
        }
    }

    static void NuevoJuego(JuegoMesa[] juegos, ref int cantidad)
    {
        JuegoMesa nuevoJuego;
        bool errorCatch = false;

        if (cantidad < juegos.Length)
        {
            RecogerInfoJuego(out nuevoJuego, ref errorCatch);

            if (nuevoJuego.Precio > 0 && errorCatch == false)
            {
                juegos[cantidad] = nuevoJuego;
                cantidad++;
            }
            else
            {
                Console.WriteLine("Precio incorrecto");
                Console.WriteLine("Juego no guardado");
            }
        }

        Console.WriteLine("Pulsa ENTER para continuar");
        Console.ReadLine();
    }

    static void BorrarJuego(JuegoMesa[] juegos, ref int cantidad)
    {
        for (int i = 0; i < cantidad; i++)
        {
            Console.WriteLine("{0}- {1}", i + 1, juegos[i].Nombre);
        }

        Console.WriteLine("Posición del juego: ");
        int posicion = Convert.ToInt32(Console.ReadLine());
        posicion--;

        Console.WriteLine("Seguro? S/N");
        string respuestaConfirmacion = Console.ReadLine();


        if (respuestaConfirmacion == "S")
        {
            if (cantidad > 0 && posicion >= 0 && posicion < cantidad)
            {
                for (int i = posicion; i < cantidad - 1; i++)
                {
                    juegos[i] = juegos[i + 1];
                }
                cantidad--;

                System.Console.WriteLine("Borrado realizado");
            }
        }
        else
        {
            System.Console.WriteLine("Borrado cancelado");
        }

        Console.WriteLine("Pulsa ENTER para continuar");
        Console.ReadLine();
    }

    static int JuegoMasCaro(JuegoMesa[] juegos, int cantidad)
    {
        float precioMax = juegos[0].Precio;
        int maximo = 0;

        if (cantidad > 0)
        {
            for (int i = 0; i < cantidad; i++)
            {
                if (juegos[i].Precio > precioMax)
                {
                    precioMax = juegos[i].Precio;
                    maximo = i;
                }
            }
        }
        else
            maximo = -1;

        return maximo;
    }

    // cuando hago uso de esta funcion el programa deja de funcionar, pero
    // antes me muestra absolutamente todos los juegps guardados, no consigo 
    // ver el problema
    static void MostrarInfoJuego(JuegoMesa[] juegos, int i)
    {
        foreach (JuegoMesa juego in juegos)
        {
            juego.Mostrar();
        }
    }

    static void BuscarPorTitulo(JuegoMesa[] juegos, int cantidad)
    {
        Console.Write("Introduce el nombre del juego: ");

        string buscarTitulo = Console.ReadLine();

        for (int i = 0; i < cantidad; i++)
        {
            if (juegos[i].Nombre.ToUpper().Contains
                (buscarTitulo.ToUpper()))
            {
                MostrarInfoJuego(juegos);
            }
        }

        Console.WriteLine("Pulsa ENTER para continuar");
        Console.ReadLine();
    }

    static void Main()
    {
        JuegoMesa[] juegos = new JuegoMesa[5];
        int cantidad = 0, opcion;


        do
        {
            Console.Clear();
            opcion = MostrarMenu();

            switch ((opciones)opcion)
            {
                case opciones.INSERTAR:
                    NuevoJuego(juegos, ref cantidad);
                    break;
                case opciones.BORRAR:
                    BorrarJuego(juegos, ref cantidad);
                    break;
                case opciones.CARO:

                    int masCaro = JuegoMasCaro(juegos, cantidad);

                    if (masCaro != -1)
                    {
                        Console.WriteLine("El juego mas caro es: ");
                        MostrarInfoJuego(juegos, masCaro);
                    }

                    else
                    {
                        Console.WriteLine("No hay juegos");
                    }

                    Console.WriteLine("Pulsa ENTER para continuar");
                    Console.ReadLine();

                    break;

                case opciones.TITULO:
                    BuscarPorTitulo(juegos, cantidad);
                    break;

                case opciones.SALIR:
                    Console.WriteLine("Fin del programa");
                    break;
                default:
                    Console.WriteLine("Opción incorrecta");
                    break;
            }
        }
        while (opcion != (int)opciones.SALIR);

    }
}
