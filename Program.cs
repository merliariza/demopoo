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
            
            switch(opcion)
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

    private static void RegistrarClub(List<Club> clubes)
    {
        do {
            Console.Clear();
            Console.WriteLine("\nRegistro de Club");
            
            Club club = new Club();
            string id;
            bool idValido;
            
            do {
                Console.WriteLine("Por favor ingrese el Id del Club:");
                id = Console.ReadLine();
                
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
            
            Console.WriteLine("Por favor ingrese el nombre del Club:");
            club.Nombre = Console.ReadLine()?.ToUpper();

            clubes.Add(club);

            Console.Write("Club registrado exitosamente. ¿Desea registrar otro club? (S/N): ");
            continuar = Utilidades.LeerTecla();
        } while(continuar);
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
            foreach(Club club in clubes)
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

    do {
        Console.Clear();
        Console.WriteLine("\nRegistro de Jugador");
        
        Console.WriteLine("Ingrese el Id del jugador:");
        string id = Console.ReadLine();

        Console.WriteLine("Ingrese el nombre del jugador:");
        string nombre = Console.ReadLine();

        Console.WriteLine("Ingrese el apellido del jugador:");
        string apellido = Console.ReadLine();

        Console.WriteLine("Ingrese el teléfono del jugador:");
        string telefono = Console.ReadLine();

        Console.WriteLine("Ingrese el correo del jugador:");
        string correo = Console.ReadLine();

        Console.WriteLine("Ingrese la dirección del jugador:");
        string direccion = Console.ReadLine();

        Console.WriteLine("Ingrese la posición del jugador:");
        string posicion = Console.ReadLine();

        Console.WriteLine("Ingrese el número del jugador:");
        int numero = int.Parse(Console.ReadLine());

        Console.WriteLine("\nClubes disponibles:");
        for (int i = 0; i < clubes.Count; i++)
        {
            Console.WriteLine($"{i+1}. {clubes[i].Nombre} (ID: {clubes[i].Id})");
        }

        int opcionClub;
        do {
            Console.WriteLine("\nSeleccione el número del club al que pertenece el jugador:");
            if (!int.TryParse(Console.ReadLine(), out opcionClub) || opcionClub < 1 || opcionClub > clubes.Count)
            {
                Console.WriteLine("Opción no válida. Intente nuevamente.");
            }
        } while (opcionClub < 1 || opcionClub > clubes.Count);

        // Crear el jugador
        Player nuevoJugador = new Player(id, nombre, apellido, telefono, correo, direccion, posicion, numero);

        // Agregar al club seleccionado
        clubes[opcionClub-1].Jugadores.Add(nuevoJugador);

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
                Console.WriteLine($"  ID: {jugador.Id} - Nombre: {jugador.Nombre} {jugador.Apellido} - Posición: {jugador.Position} - Número: {jugador.Number}");
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