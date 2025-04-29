using System;
using System.Collections.Generic;
using demopoo;
using demopoo.Equipo;

internal class Program
{
    public static bool continuar { get; private set; }

    private static void Main(string[] args)
    {
        string menu = "1. Registrar Club\n2. Registrar Jugador\n3. Listar Clubes\n4. Listar Jugadores\n5. Salir\nSeleccione una opción: ";
        List<Club> clubes = new List<Club>();
        bool salir = false;

        do
        {
            Console.Clear();
            Console.WriteLine("Sistema de gestión de la Conmebol Libertadores.");
            Console.WriteLine(menu);

            int opcion = Utilidades.LeerOpcionMenuKey(menu);

            switch (opcion)
            {
                case 1:
                    RegistrarClub(clubes);
                    break;
                case 2:
                    RegistrarJugador(clubes);
                    break;
                case 3:
                    ListarClubes(clubes);
                    break;
                case 4:
                    ListarJugadores(clubes);
                    break;
                case 5:
                    salir = true;
                    break;
                default:
                    Console.WriteLine("\nOpción no válida. Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;
            }

        } while (!salir);
    }

    private static string LeerTextoNoVacio(string mensaje)
    {
        string input;
        do
        {
            Console.WriteLine(mensaje);
            input = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("El campo no puede estar vacío. Intente nuevamente.");
            }
        } while (string.IsNullOrEmpty(input));

        return input;
    }

    private static int LeerEntero(string mensaje)
    {
        int valor;
        bool valido;
        do
        {
            Console.WriteLine(mensaje);
            valido = int.TryParse(Console.ReadLine(), out valor);
            if (!valido)
            {
                Console.WriteLine("Error: Ingrese un número entero válido.");
            }
        } while (!valido);

        return valor;
    }

    private static double LeerDouble(string mensaje)
    {
        double valor;
        bool valido;
        do
        {
            Console.WriteLine(mensaje);
            valido = double.TryParse(Console.ReadLine(), out valor);
            if (!valido)
            {
                Console.WriteLine("Error: Ingrese un número decimal válido.");
            }
        } while (!valido);

        return valor;
    }

    private static void RegistrarClub(List<Club> clubes)
    {
        do
        {
            Console.Clear();
            Console.WriteLine("\nRegistro de Club");

            Club club = new Club();
            string id;
            bool idValido;

            do
            {
                id = LeerTextoNoVacio("Por favor ingrese el Id del Club:");
                idValido = true;
                foreach (Club c in clubes)
                {
                    if (c.Id == id)
                    {
                        Console.WriteLine("Error: El ID ya existe. Por favor ingrese un ID único.");
                        idValido = false;
                        break;
                    }
                }
            } while (!idValido);

            club.Id = id;
            club.Nombre = LeerTextoNoVacio("Por favor ingrese el nombre del Club:").ToUpper();

            clubes.Add(club);

            Console.Write("Club registrado exitosamente. ¿Desea registrar otro club? (S/N): ");
            continuar = Utilidades.LeerTecla();
        } while (continuar);
    }

    private static void ListarClubes(List<Club> clubes)
    {
        Console.Clear();
        Console.WriteLine("Lista de clubes registrados:");

        if (clubes.Count == 0)
        {
            Console.WriteLine("No hay clubes registrados.");
        }
        else
        {
            foreach (Club club in clubes)
            {
                Console.WriteLine($"ID: {club.Id} - Nombre: {club.Nombre}");
            }
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    private static void RegistrarJugador(List<Club> clubes)
    {
        if (clubes.Count == 0)
        {
            Console.Clear();
            Console.WriteLine("Primero debe registrar al menos un club.");
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            return;
        }

        do
        {
            Console.Clear();
            Console.WriteLine("\nRegistro de Jugador");

            string id = LeerTextoNoVacio("Ingrese el Id del jugador:");
            string nombre = LeerTextoNoVacio("Ingrese el nombre del jugador:");
            string apellido = LeerTextoNoVacio("Ingrese el apellido del jugador:");
            string telefono = LeerTextoNoVacio("Ingrese el teléfono del jugador:");
            string correo = LeerTextoNoVacio("Ingrese el correo del jugador:");
            string direccion = LeerTextoNoVacio("Ingrese la dirección del jugador:");
            string posicion = LeerTextoNoVacio("Ingrese la posición del jugador:");
            int numero = LeerEntero("Ingrese el número del jugador:");
            double precio = LeerDouble("Ingrese el precio del jugador:");

            Console.WriteLine("\nClubes disponibles:");
            for (int i = 0; i < clubes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {clubes[i].Nombre} (ID: {clubes[i].Id})");
            }

            int opcionClub;
            do
            {
                opcionClub = LeerEntero("\nSeleccione el número del club al que pertenece el jugador:");
                if (opcionClub < 1 || opcionClub > clubes.Count)
                {
                    Console.WriteLine("Opción no válida. Ingrese una opción válida.");
                }
            } while (opcionClub < 1 || opcionClub > clubes.Count);

            Player nuevoJugador = new Player(id, nombre, apellido, telefono, correo, direccion, posicion, numero, precio);

            clubes[opcionClub - 1].Jugadores.Add(nuevoJugador);

            Console.WriteLine("Jugador registrado exitosamente.");
            Console.Write("¿Desea registrar otro jugador? (S/N): ");
            continuar = Utilidades.LeerTecla();
        } while (continuar);
    }

    private static void ListarJugadores(List<Club> clubes)
    {
        Console.Clear();
        Console.WriteLine("Lista de jugadores registrados:");

        bool hayJugadores = false;

        foreach (Club club in clubes)
        {
            if (club.Jugadores.Count > 0)
            {
                Console.WriteLine($"\nClub: {club.Nombre}");

                foreach (Player jugador in club.Jugadores)
                {
                    Console.WriteLine($"  ID: {jugador.Id} - Nombre: {jugador.Nombre} {jugador.Apellido} - Posición: {jugador.Position} - Número: {jugador.Number} - Precio: {jugador.Price}");
                }

                hayJugadores = true;
            }
        }

        if (!hayJugadores)
        {
            Console.WriteLine("No hay jugadores registrados.");
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }
}
