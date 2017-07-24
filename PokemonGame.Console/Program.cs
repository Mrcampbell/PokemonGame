using PokemonGame.Library.Models;
using PokemonGame.Library.Models.Move;
using PokemonGame.Library.Models.Pokemon;
using PokemonGame.Library.Models.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGame.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            UIConsole ui = new UIConsole();
            BasePokemon archie = new Growlithe(15);
            archie.Moves.AddMove(new Ember());
            archie.Moves.AddMove(new RockThrow());
            archie.Moves.AddMove(new Earthquake());
            archie.Moves.AddMove(new Tackle());

            BasePokemon pikachu = new Pikachu(17);
            pikachu.Moves.AddMove(new ThunderBolt());
            pikachu.Moves.AddMove(new Tackle());

            BasePokemon paras = new Paras(12);
            paras.Moves.AddMove(new Tackle());
            paras.Moves.AddMove(new Ember());
            paras.Moves.AddMove(new HydroPump());

            Console.WriteLine(paras.Moves.Get(1));
            Console.WriteLine(paras.Moves.Get(2));
            Console.WriteLine(paras.Moves.Count);

            Battle b = new Battle(archie, paras, Battle.Type.WILD);

            Console.WriteLine("Program Ended.  Press any key to continue...");
            Console.ReadKey(true);
        }
    }
}
