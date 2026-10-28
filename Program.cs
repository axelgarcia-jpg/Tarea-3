using System;

namespace S01Tarjeta
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GENERADOR DE TARJETA DIGITAL\n");

            // Declaración de variables tipos
            string nombre = "";
            int nivel = 0;
            bool esVip = false;
            char simboloBorde;

            Console.Write("Ingrese el nombre del usuario: ");
            nombre = Console.ReadLine() ?? "Invitado";

            //  para evitar FormatException
            bool nivelValido = false;
            while (!nivelValido)
            {
                Console.Write("Ingrese el nivel (número entero positivo): ");
                string? entradaNivel = Console.ReadLine();

                if (int.TryParse(entradaNivel, out nivel) && nivel > 0)
                {
                    nivelValido = true;
                }
                else
                {
                    Console.WriteLine("Error Debe ingresar un número entero mayor a 0.");
                }
            }

            Console.Write("¿Es usuario VIP? (s/n) ");
            string respuestaVip = Console.ReadLine()?.Trim().ToLower() ?? "n";
            
            // alterar el aspecto/salida
            if (respuestaVip == "s" || respuestaVip == "si")
            {
                esVip = true;
                simboloBorde = '★';
            }
            else
            {
                esVip = false;
                simboloBorde = '=';
            }

            Console.WriteLine("\n--- Generando Resultado ---\n");

            // método con parámetros
            GenerarTarjeta(nombre, nivel, esVip, simboloBorde);
        }

        // Método cn múltiples parametros
        static void GenerarTarjeta(string nombreUsuario, int nivelUsuario, bool esVip, char borde)
        {
            int anchoTarjeta = 38;

            //  Uso de ciclos para bordes visuales
            DibujarLinea(borde, anchoTarjeta);

            string etiquetaRol = esVip ? "[ MIEMBRO VIP ]" : "[ MIEMBRO ESTÁNDAR ]";
            Console.WriteLine($"| {etiquetaRol.PadRight(anchoTarjeta - 4)} |");

            DibujarLinea('-', anchoTarjeta);

            Console.WriteLine($"| Usuario: {nombreUsuario.PadRight(anchoTarjeta - 13)} |");
            Console.WriteLine($"| Nivel:   {nivelUsuario.ToString().PadRight(anchoTarjeta - 13)} |");

            // 8. Ciclo para construir patrón repetitivo de la barra de nivel
            string barraNivel = "";
            int limiteGrafico = Math.Min(nivelUsuario, 15); // Límite visual de 15 bloques
            for (int i = 0; i < limiteGrafico; i++)
            {
                barraNivel += "▓";
            }
            Console.WriteLine($"| Rango:   {barraNivel.PadRight(anchoTarjeta - 13)} |");

            DibujarLinea(borde, anchoTarjeta);
        }

        // ciclo 'for' para dibujar un patrón repetitivo
        static void DibujarLinea(char caracter, int longitud)
        {
            for (int i = 0; i < longitud; i++)
            {
                Console.Write(caracter);
            }
            Console.WriteLine();
        }
    }
}