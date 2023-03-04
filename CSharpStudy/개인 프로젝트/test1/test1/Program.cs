using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pokemon pokemon = new Pokemon();
            myPokemon mypokemon = new myPokemon();
            yourPokemon yourpokemon = new yourPokemon();

            Console.WriteLine($"{pokemon.att} {pokemon.def} {pokemon.hp}");
            Console.WriteLine($"{mypokemon.att} {mypokemon.def} {mypokemon.hp}");
            Console.WriteLine($"{yourpokemon.att} {yourpokemon.def} {yourpokemon.hp}\n");

            mypokemon.mypokeset();

            mypokemon.att = 1;

            Console.WriteLine($"{pokemon.att} {pokemon.def} {pokemon.hp}");
            Console.WriteLine($"{mypokemon.att} {mypokemon.def} {mypokemon.hp}");
            Console.WriteLine($"{yourpokemon.att} {yourpokemon.def} {yourpokemon.hp}\n");

            yourpokemon.yourpokeset();

            Console.WriteLine($"{pokemon.att} {pokemon.def} {pokemon.hp}");
            Console.WriteLine($"{mypokemon.att} {mypokemon.def} {mypokemon.hp}");
            Console.WriteLine($"{yourpokemon.att} {yourpokemon.def} {yourpokemon.hp}\n");

        }
    }


    class Pokemon
    {
        public int att = 0;
        public int def = 0;
        public int hp = 0;
    }

    class myPokemon : Pokemon
    {
        public Pokemon mypoke = new Pokemon();

        public void mypokeset()
        {
            mypoke.att = 1;
            mypoke.def = 1;
            mypoke.hp = 1;
        }
    }

    class yourPokemon : Pokemon
    {
        public Pokemon yourpoke = new Pokemon();

        public void yourpokeset()
        {
            yourpoke.att = 2;
            yourpoke.def = 2;
            yourpoke.hp = 2;
        }
    }

}
