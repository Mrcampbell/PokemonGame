using PokemonGame.Library.Models.Move;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGame.Library.Models
{
    public partial class Battle
    {
        private class AttackResult
        {
            private BasePokemon _attacker;
            private BasePokemon _defender;
            private BaseMove _move;
            private int _sameTypeAttacKBonus; // if the attacker and the move share the same Element Type (STAB)
            private Element.Effect _moveTypeAdvantageAgainstDefenderOne; // how the move's Element Type matches up with the defender's Element Type
            private Element.Effect _moveTypeAdvantageAgainstDefenderTwo; // how the move's Element Type matches up with the defender's Element Type
            private int _damageToAttacker;
            private int _damageToDefender;

            private double _damageComponentA;
            private double _damageComponentB;
            private double _damageComponentC;

            private int _targets = 1; // not used yet...
            private int _weather = 1; // not used yet...
            private int _badge = 1; // not used yet...
            private int _other = 1; // not used yet...
            private float _elementalAdvantageEffectOne;
            private float _elementalAdvantageEffectTwo;
            private double _critical;
            private float _randomDouble;

            public int DamageToAttacker { get { return _damageToAttacker; } }
            public int DamageToDefender { get { return _damageToDefender; } }
            public float ElementalAdvantageModifier { get { return _elementalAdvantageEffectOne * _elementalAdvantageEffectTwo; } }

            public AttackResult(BasePokemon attacker, BasePokemon defender, BaseMove move)
            {
                // TODO: I'm not sure we need to store these..
                _attacker = attacker;
                _defender = defender;
                _move = move;

                _sameTypeAttacKBonus = (attacker.ElementOne == move.Type || attacker.ElementTwo == move.Type) ? 2 : 1;
                _moveTypeAdvantageAgainstDefenderOne = Element.GetTypeAdvantageFromTwoElementCompare(move.Type, defender.ElementOne);
                _moveTypeAdvantageAgainstDefenderTwo = Element.GetTypeAdvantageFromTwoElementCompare(move.Type, defender.ElementTwo);
                _calculateDamageToDefender(attacker, defender, move);
            }

            private float _getFloatingPointModifierFromTypeAdvantage(Element.Effect effect)
            {
                switch (effect)
                {
                    case Element.Effect.STRONG: return 2;
                    case Element.Effect.NORMAL: return 1;
                    case Element.Effect.WEAK: return 0.5f;
                    case Element.Effect.NONE: return 0;
                    default: throw new NotImplementedException("Unknown Elemental Effect");
                }
            }

            private void _calculateDamageToDefender(BasePokemon attacker, BasePokemon defender, BaseMove move)
            {
                Random rand = new Random();

                _damageComponentA = ((2 * attacker.Level / 5) + 2);
                _damageComponentB = move.Power * (attacker.Stat.Attack / defender.Stat.Defense);
                _damageComponentC = ((_damageComponentA * _damageComponentB) / 50) + 2;

                // TODO: Add implementation for moves that are more inclined to be critical
                _critical = (rand.Next(0, 93) > 93) ? 2 : 1;
                _randomDouble = rand.Next(85, 100);


                double modifier = (_damageComponentC * _critical * _randomDouble * _targets * _weather * _badge * _other) / 100;
                _elementalAdvantageEffectOne = _getFloatingPointModifierFromTypeAdvantage(_moveTypeAdvantageAgainstDefenderOne);
                _elementalAdvantageEffectTwo = _getFloatingPointModifierFromTypeAdvantage(_moveTypeAdvantageAgainstDefenderTwo);

                _damageToDefender = (int) (modifier * _elementalAdvantageEffectOne * _elementalAdvantageEffectTwo * _sameTypeAttacKBonus);

            }

            public override string ToString()
            {
                string output = "Attack Result:";
                output += "\n  STAB: " + _sameTypeAttacKBonus;
                output += "\n  Adv1: " + _moveTypeAdvantageAgainstDefenderOne.ToString();
                output += "\n  Adv2: " + _moveTypeAdvantageAgainstDefenderTwo.ToString();
                output += "\n  Critical:   " + _critical;
                output += "\n  Random Int: " + _randomDouble;
                output += "\n  Damage Component A: " + _damageComponentA;
                output += "\n  Damage Component B: " + _damageComponentB;
                output += "\n  Damage Component C: " + _damageComponentC;
                output += "\n  Damage to Attacker: " + _damageToAttacker;
                output += "\n  Damage to Defender: " + _damageToDefender;

                return output;
            }
        }
    }
}
