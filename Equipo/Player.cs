using System;

namespace demopoo.Equipo;

public class Player : Persona
{
    public string? Position { get; set; }
    public int Number { get; set; }

    public double Price { get; set; }

    public Player(string id, string nombre, string apellido, string telefono, string correo, string direccion, string position, int number, double price) : base(id, nombre, apellido, telefono, correo, direccion)
    {
        Position = position;
        Number = number;
        Price = price;
    }

    public Player(string id, string nombre, string apellido) : base(id, nombre, apellido){}

}
