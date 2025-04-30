# Sistema de Gestión de Clubes - Conmebol Libertadores

Este es un sistema de consola en C# diseñado para registrar clubes y jugadores que participan en la Conmebol Libertadores. Permite almacenar datos básicos de clubes y jugadores, y visualizar la información de manera organizada.

## Características

- Registrar nuevos clubes con validación de ID único.
- Registrar jugadores asociados a clubes previamente registrados.
- Visualizar la lista de clubes registrados.
- Visualizar jugadores agrupados por club.
- Interfaz por consola simple y funcional.

## Estructura del Proyecto

El sistema está organizado en varios componentes:

- `Program.cs`: Archivo principal donde se ejecuta el menú principal y se gestionan las acciones.
- `Utilidades.cs`: Contiene funciones auxiliares como la lectura de opciones del menú y validaciones.
- `Club.cs`: Clase que representa un club y contiene la lista de jugadores asociados.
- `Player.cs`: Clase que representa a un jugador con atributos como ID, nombre, posición, número, etc.

## Cómo Ejecutarlo

1. Abre el proyecto en Visual Studio.
2. Asegúrate de que el archivo `Program.cs` sea el punto de entrada.
3. Compila y ejecuta el proyecto.
4. Interactúa con el menú para registrar clubes o jugadores y listar la información.

## Requisitos

- .NET 6 o superior
- Sistema operativo compatible con .NET (Windows, Linux o macOS)

## Ejemplo de Uso

```text
Sistema de gestión de la Conmebol Libertadores.
1. Registrar Club
2. Registrar Jugador
3. Listar Clubes
4. Listar Jugadores
5. Salir
Seleccione una opción: _
