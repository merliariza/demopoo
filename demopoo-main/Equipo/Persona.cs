using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demopoo.Equipo;

public class Persona
{

    public string Id { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public string? Telefono { get; set; }
    public string? Correo { get; set; }
    public string? Direccion { get; set; }
    public Persona(string id, string nombre, string apellido, string telefono, string correo, string direccion)
    {
        Id = id;
        Nombre = nombre;
        Apellido = apellido;
        Telefono = telefono;
        Correo = correo;
        Direccion = direccion;
    }
    public Persona(string id, string nombre, string apellido)
    {
        Id = id;
        Nombre = nombre;
        Apellido = apellido;
    }

}
