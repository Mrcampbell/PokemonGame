using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGame.Library.Models.UI
{
    public class UIConsole : IUserInterface
    {

        public void PrintInstructions(string message)
        {
            Console.WriteLine(message);
        }

        public void GetAdvance()
        {
            Console.ReadKey(true);
        }

        public int GetNumberBetweenInclusive(int min, int max)
        {
            Console.Write("> ");
            int given;

            string input = Console.ReadLine();
            if (int.TryParse(input, out given))
            {
                if (min <= given && given <= max)
                    return given;
                else
                {
                    Console.WriteLine("Number out of range");
                    return GetNumberBetweenInclusive(min, max);
                }
            }
            else
            {
                Console.WriteLine("Not a valid number");
                return GetNumberBetweenInclusive(min, max);
            }
        }

        public void DisplayAlertWithoutOptions(string message)
        {
            Console.WriteLine(message);
        }

        public bool DisplayAlertForPositiveOrNegative(string message, string positiveMessage, string negativeMessage)
        {
            Console.WriteLine(message);
            Console.WriteLine("1: " + positiveMessage);
            Console.WriteLine("2: " + negativeMessage);
            int choice = GetNumberBetweenInclusive(1, 2);
            return choice == 1;
        }

        public void DisplayBattleMessageWithNoOptions(string message)
        {
            Console.WriteLine(message);
        }

        public int DisplayBattleMessageForInt(string message, string option1, string option2, string option3, string option4)
        {
            PrintInstructions(message);
            PrintInstructions("1: " + option1);

            if (!String.IsNullOrWhiteSpace(option2))
                PrintInstructions("2: " + option2);
            if (!String.IsNullOrWhiteSpace(option3))
                PrintInstructions("3: " + option3);
            if (!String.IsNullOrWhiteSpace(option4))
                PrintInstructions("4: " + option4);

            // TODO: limit range
            return GetNumberBetweenInclusive(1, 4);
        }

        public void DisplayBattleStats(BasePokemon ally, BasePokemon enemy)
        {
            string output = "Battle: ";
            output += "\n\nAlly: " + ally.Name;
            output += "\nLvl: " + ally.Level;
            output += "  HP: " + ally.HP.ToString();
            output += "\n\nEnemy: " + enemy.Name;
            output += "\nLvl: " + enemy.Level;
            output += "  HP: " + enemy.HP.ToString();
            output += "\n";

            Console.WriteLine(output);
        }
    }
}
