using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGame.Library.Models.Move
{
    public class MoveSet
    {
        private List<BaseMove> _moveList;

        public MoveSet()
        {
            _moveList = new List<BaseMove>();

        }

        public bool AddMove(BaseMove m)
        {
            if (_moveList.Count <= 4)
            {
                _moveList.Add(m);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ReplaceMove(BaseMove oldMove, BaseMove newMove)
        {
            throw new NotImplementedException();
        }

        public bool ReplaceMove(int i, BaseMove newMove)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return _moveList.Count(); }
        }

        public BaseMove Get(int i)
        {
            if (i > _moveList.Count || i < 1)
                return new BlankMove();

            return _moveList[i - 1];
        }

        public override string ToString()
        {
            string output = "MoveSet";
            foreach (BaseMove m in _moveList)
            {
                output += "\n  " + m.ToString();
            }

            return output;
        }

    }
}
