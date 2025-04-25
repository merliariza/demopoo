using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demopoo.Equipo;

public class Club
{
    public string? Id { get; set; } = string.Empty;
    public string? Nombre { get; set; } = string.Empty;
    public List<Player> Jugadores { get; set; } = new List<Player>();
}
