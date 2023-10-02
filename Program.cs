using System;

public interface IHabilidad
{
    double Atacar();
    double Defender();
}

public abstract class PokemonBase : IHabilidad
{
    private string nombre;
    private string tipo;
    private int ataque1;
    private int ataque2;
    private int ataque3;
    private int defensa;

    public PokemonBase(string nombre, string tipo)
    {
        this.nombre = nombre;
        this.tipo = tipo;

        // Solicitar valores de ataque por consola
        Console.Write($"Ingrese el valor de ataque1 entre 0 y 40 para {nombre}: ");
        this.ataque1 = Convert.ToInt32(Console.ReadLine());

        Console.Write($"Ingrese el valor de ataque2 entre 0 y 40 para {nombre}: ");
        this.ataque2 = Convert.ToInt32(Console.ReadLine());

        Console.Write($"Ingrese el valor de ataque3 entre 0 y 40 para {nombre}: ");
        this.ataque3 = Convert.ToInt32(Console.ReadLine());

        // Solicitar valor de defensa por consola
        Console.Write($"Ingrese el valor de defensa entre 10 y 35 para {nombre}: ");
        this.defensa = Convert.ToInt32(Console.ReadLine());
    }

    public string Nombre => nombre;
    public string Tipo => tipo;
    private int Ataque1 => ataque1;
    private int Ataque2 => ataque2;
    private int Ataque3 => ataque3;
    private int Defensa => defensa;

    public double Atacar()
    {
        Random random = new Random();
        int ataqueElegido = random.Next(1, 4);
        int puntaje = 0;

        switch (ataqueElegido)
        {
            case 1:
                puntaje = Ataque1;
                break;
            case 2:
                puntaje = Ataque2;
                break;
            case 3:
                puntaje = Ataque3;
                break;
        }

        return puntaje * (random.Next(0, 2));
    }

    public double Defender()
    {
        Random random = new Random();
        double multiplicador = (random.Next(0, 2) == 1) ? 1.0 : 0.5;
        return Defensa * multiplicador;
    }
}

public class Pokemon : PokemonBase
{
    public Pokemon(string nombre, string tipo) : base(nombre, tipo)
    {
    }
}

class Program
{
    static void Main()
    {
        // Crear dos instancias de Pokemon
        Pokemon pokemon1 = new Pokemon("Charizard", "Fuego");
        Pokemon pokemon2 = new Pokemon("Blastoise", "Agua");

        // Realizar la batalla
        for (int i = 0; i < 3; i++)
        {
            double ataquePokemon1 = pokemon1.Atacar();
            double defensaPokemon2 = pokemon2.Defender();

            double ataquePokemon2 = pokemon2.Atacar();
            double defensaPokemon1 = pokemon1.Defender();

            if (ataquePokemon1 > defensaPokemon2 && ataquePokemon2 > defensaPokemon1)
            {
                Console.WriteLine("Empate en el turno " + (i + 1));
            }
            else if (ataquePokemon1 > defensaPokemon2)
            {
                Console.WriteLine($"Pokemon 1 ganó el turno {i + 1}");
            }
            else if (ataquePokemon2 > defensaPokemon1)
            {
                Console.WriteLine($"Pokemon 2 ganó el turno {i + 1}");
            }
            else
            {
                Console.WriteLine("Empate en el turno " + (i + 1));
            }
        }

        // Mostrar el resultado final
        int victoriasPokemon1 = 0;
        int victoriasPokemon2 = 0;

        for (int i = 0; i < 3; i++)
        {
            double ataquePokemon1 = pokemon1.Atacar();
            double defensaPokemon2 = pokemon2.Defender();

            double ataquePokemon2 = pokemon2.Atacar();
            double defensaPokemon1 = pokemon1.Defender();

            if (ataquePokemon1 > defensaPokemon2)
            {
                victoriasPokemon1++;
            }
            else if (ataquePokemon2 > defensaPokemon1)
            {
                victoriasPokemon2++;
            }
        }

        if (victoriasPokemon1 > victoriasPokemon2)
        {
            Console.WriteLine("¡Pokemon 1 ganó la batalla!");
        }
        else if (victoriasPokemon2 > victoriasPokemon1)
        {
            Console.WriteLine("¡Pokemon 2 ganó la batalla!");
        }
        else
        {
            Console.WriteLine("La batalla terminó en empate.");
        }
    }
}
