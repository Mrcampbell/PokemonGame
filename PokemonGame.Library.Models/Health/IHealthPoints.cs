using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGame.Library.Models.Health
{
    public interface IHealthPoints
    {
        int GetHalfHealth();
        int GetQuarterHealth();
        int GetEighthHealth();
        bool IsFainted();
        void AddPoints(int i);
        void SubtractPoints(int i);

        void ReduceHalfOfMax();
        void ReduceQuarterOfMax();
        void ReduceEighthOfMax();
        void ReduceHealthToZero();

        void AddHalfOfMax();
        void AddQuarterOfMax();
        void AddEighthOfMax();
        void FullyHeal();

    }
}
