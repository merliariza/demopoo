using demopoo;
using demopoo.Equipo;

internal class Program
{
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
                    Console.WriteLine("\nFuncionalidad de Registrar Jugador pendiente de implementar");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;
                case 3:
                    ListarClubes(clubes);
                    break;
                case 4:
                    Console.WriteLine("\nFuncionalidad de Listar Jugadores pendiente de implementar");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
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
        Console.Clear();
        Console.WriteLine("Bienvenido al sistema de gestión de jugadores de fútbol.");

        Club club = new Club();
        Console.WriteLine("Por favor ingrese el Id del Club");
        club.Id = Console.ReadLine();
        Console.WriteLine("Por favor ingrese el nombre del Club");
        club.Nombre = Console.ReadLine()?.ToUpper();

        clubes.Add(club);

        Console.Write("Club registrado exitosamente. Presione cualquier tecla para continuar...");
        Console.ReadKey();
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
            foreach(Club myClub in clubes)
            {
                Console.WriteLine($"Id: {myClub.Id} Nombre: {myClub.Nombre}");
            }
        }
        
        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }
}