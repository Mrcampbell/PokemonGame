using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGame.Library.Models
{
    public interface IUserInterface
    {
        // pressing enter or whatever button means "Continue"
        void GetAdvance();


        void DisplayAlertWithoutOptions(string message);
        bool DisplayAlertForPositiveOrNegative(string message, string positiveMessage, string negativeMessage);

        void DisplayBattleStats(BasePokemon ally, BasePokemon enemy);
        void DisplayBattleMessageWithNoOptions(string message);
        int  DisplayBattleMessageForInt(string message, string option1, string option2, string option3, string option4);
    }
}
