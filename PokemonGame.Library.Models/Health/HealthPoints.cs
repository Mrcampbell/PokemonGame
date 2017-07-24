using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGame.Library.Models.Health
{
    public class HealthPoints : IHealthPoints
    {
        private int _max;
        private int _current;
        
        public HealthPoints(int max)
        {
            if (max < 1)
                throw new ArgumentOutOfRangeException("HP Max must be greater than zero!");
            Max = max;
            Current = max;
        }

        public int Current
        {
            get { return _current; }
            set
            {
                if (value < 0 || value > _max)
                    throw new ArgumentOutOfRangeException("Current Health Points must be Greater than or Equal to Zero and Less than Max");

                _current = value;
            }
        }

        public int Max
        {
            get
            {
                { return _max; }
            }
            set
            {
                if (value <= 0 || value < _current)
                    throw new ArgumentOutOfRangeException("Max Health Points must be greater than Zero and Greater than Min");

                _max = value;
            }
        }

        public void AddPoints(int i)
        {
            if (i < 0)
                throw new ArgumentOutOfRangeException("Cannot Add Negative Points to Health");

            int tmp = Current;
            tmp += i;

            if (tmp > Max)
                tmp = Max;

            Current = tmp;
        }

        public void SubtractPoints(int i)
        {
            if (i < 0)
                throw new ArgumentOutOfRangeException("Cannot Subtract Negative Points from Health");
            int tmp = Current;
            tmp -= i;
            if (tmp < 0)
                tmp = 0;

            Current = tmp;
        }

        private int _divideMaxByInt(int i)
        {
            return (int)Math.Ceiling((double)(Max / i));

        }

        public void AddEighthOfMax()
        {
            AddPoints(GetEighthHealth());
        }

        public void AddHalfOfMax()
        {
            AddPoints(GetHalfHealth());
        }

        public void AddQuarterOfMax()
        {
            AddPoints(GetQuarterHealth());
        }

        public void FullyHeal()
        {
            Current = Max;
        }

        public int GetEighthHealth()
        {
            return _divideMaxByInt(8);
        }

        public int GetQuarterHealth()
        {
            return _divideMaxByInt(4);
        }

        public int GetHalfHealth()
        {
            return _divideMaxByInt(2);

        }

        public bool IsFainted()
        {
            return Current == 0;
        }

        public void ReduceEighthOfMax()
        {
            SubtractPoints(GetEighthHealth());
        }

        public void ReduceHalfOfMax()
        {
            SubtractPoints(GetHalfHealth());

        }

        public void ReduceQuarterOfMax()
        {
            SubtractPoints(GetQuarterHealth());

        }

        public void ReduceHealthToZero()
        {
            Current = 0;
        }

        public override string ToString()
        {
            string output = "HP: ";
            output += Current + " / " + Max;
            return output;
        }

    }
}
