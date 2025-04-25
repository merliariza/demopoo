using System;

namespace demopoo.Equipo;

public class Player : Persona
{
    public string? Position { get; set; }
    public int Number { get; set; }

    public Player(string id, string nombre, string apellido, string telefono, string correo, string direccion, string position, int number) : base(id, nombre, apellido, telefono, correo, direccion)
    {
        Position = position;
        Number = number;
    }

    public Player(string id, string nombre, string apellido) : base(id, nombre, apellido){}

}
