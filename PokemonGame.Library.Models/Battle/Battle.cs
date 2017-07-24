using PokemonGame.Library.Models.Move;
using PokemonGame.Library.Models.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGame.Library.Models
{
    public partial class Battle
    {
        private BasePokemon _ally;
        private BasePokemon _enemy;
        private Type _battleType;
        public bool _isStillGoing;
        private IUserInterface ui;
        private bool _battleEndedBecauseAllyFainted;
        private bool _battleEndedBecauseEnemyFainted;
        private bool _battleEndedBecauseWeRanAway;
        private bool _battleEndedBecauseWeEnemyAway;


        public Battle(BasePokemon ally, BasePokemon enemy, Type battleType)
        {
            _ally = ally;
            _enemy = enemy;
            _battleType = battleType;
            _isStillGoing = true;
            ui = new UIConsole();

            _battleEndedBecauseAllyFainted = false;
            _battleEndedBecauseEnemyFainted = false;
            _battleEndedBecauseWeRanAway = false;
            _battleEndedBecauseWeEnemyAway = false;

            _runBattle();
        }

        private void _runBattle()
        {
            int mainBattleChoice;
            int moveChoice;
            int bagChoice;
            int pokemonChoice;
            
            _setup();

            // Battle Loop
            while (_isStillGoing == true)
            {
                // start by displaying current battle stats and prompt for main action group
                ui.DisplayBattleStats(_ally, _enemy);

                mainBattleChoice = _mainBattleMenu();
                BaseMove allyMove;
                BaseMove enemyMove;

                // The user attacks
                if (mainBattleChoice == 1)
                {
                    // get the attack number and then calculate the AttackResult
                    moveChoice = _attackMenu();
                    allyMove = _ally.Moves.Get(moveChoice);
                    enemyMove = _getRandomMoveFromEnemy(_enemy);

                    AttackResult attackOnEnemy = new AttackResult(_ally, _enemy, allyMove);
                    AttackResult attackOnAlly = new AttackResult(_enemy, _ally, enemyMove);

                    bool allyAttacksFirst = _getAllyAttacksFirst(_ally, _enemy, _ally.Moves.Get(moveChoice));

                    if (allyAttacksFirst)
                    {
                        _displayResultsFromAltercation(_ally.Name, allyMove.Name, attackOnEnemy);
                        _enemy.HP.SubtractPoints(attackOnEnemy.DamageToDefender);

                        if (_enemy.HP.IsFainted())
                        {
                            // even if our ally faints, the enemy fainting is the cause of the battle ending.
                            _battleEndedBecauseEnemyFainted = true;
                        }
                        else
                        {
                            _displayResultsFromAltercation(_enemy.Name, enemyMove.Name, attackOnAlly);
                            _ally.HP.SubtractPoints(attackOnAlly.DamageToDefender);

                            if (_ally.HP.IsFainted())
                            {
                                _battleEndedBecauseAllyFainted = true;
                            }
                        }
                    }
                    else
                    {
                        _displayResultsFromAltercation(_enemy.Name, enemyMove.Name, attackOnAlly);
                        _ally.HP.SubtractPoints(attackOnAlly.DamageToDefender);

                        if (_ally.HP.IsFainted())
                        {
                            _battleEndedBecauseAllyFainted = true;
                        }
                        else
                        {
                            _displayResultsFromAltercation(_ally.Name, allyMove.Name, attackOnEnemy);
                            _enemy.HP.SubtractPoints(attackOnEnemy.DamageToDefender);

                            if (_enemy.HP.IsFainted())
                            {
                                _battleEndedBecauseEnemyFainted = true;
                            }
                        }
                    }

                    if (_battleEndedBecauseAllyFainted)
                    {
                        ui.DisplayAlertWithoutOptions("Ally fainted");
                        ui.DisplayAlertWithoutOptions("(prompt to replace ally in field)");
                        // TODO: Prompt to replace ally if others exist
                        _isStillGoing = false;
                    }
                    if (_battleEndedBecauseEnemyFainted)
                    {
                        ui.DisplayAlertWithoutOptions("Enemy fainted");
                        _isStillGoing = false;
                        // TODO: Prompt to replace enemy if trainer has others
                    }
                    if (_battleEndedBecauseWeRanAway)
                    {
                        ui.DisplayAlertWithoutOptions("Ran away Safely");
                        _isStillGoing = false;

                    }
                    if (_battleEndedBecauseWeEnemyAway)
                    {
                        ui.DisplayAlertWithoutOptions("Enemy Ran Away");
                        _isStillGoing = false;

                    }
                }
                if (mainBattleChoice == 4)
                {
                    _battleEndedBecauseWeEnemyAway = true;
                    _isStillGoing = false;
                }
            } // end of battle loop

            
        }


        private void _displayResultsFromAltercation(string attackerName, string moveName, AttackResult result)
        {
            ui.DisplayBattleMessageWithNoOptions($"{attackerName} used {moveName}");
            ui.GetAdvance();

            if (result.ElementalAdvantageModifier > 2)
                ui.DisplayBattleMessageWithNoOptions("It was Super Effective!");
            else if (result.ElementalAdvantageModifier < 1)
                ui.DisplayBattleMessageWithNoOptions("It was Not Very Effective");
            else if (result.ElementalAdvantageModifier == 0)
                ui.DisplayBattleMessageWithNoOptions("It had no Effect...");
        }

        // TODO: Implement Move Priority and other factors such as Status and stuff.
        private bool _getAllyAttacksFirst(BasePokemon ally, BasePokemon enemy, BaseMove baseMove)
        {
            if (ally.Stat.Speed > enemy.Stat.Speed)
                return true;
            else
                return false;
        }

        // here we do any flashing, dialog and display the enemy before starting battle
        private void _setup()
        {
            if (_battleType == Type.WILD)
            {
                ui.DisplayBattleMessageWithNoOptions(String.Format("A Wild {0} Appeared!", _enemy.Name));
            }
            else
            { throw new NotImplementedException("Only Wild Battles Supported For Now"); }

            ui.GetAdvance();
        }

        private int _mainBattleMenu()
        {
            return ui.DisplayBattleMessageForInt("Choose an Action", "Attack", "Bag", "Pokemon", "Run");
        }

        private int _attackMenu()
        {
            if (_ally.Moves.Count == 1)
                return ui.DisplayBattleMessageForInt("Attack:", 
                    _ally.Moves.Get(1).Name, "", "", "");
            else if (_ally.Moves.Count == 2)
                return ui.DisplayBattleMessageForInt("Attack:", 
                    _ally.Moves.Get(1).Name,
                    _ally.Moves.Get(2).Name, "", "");
            else if (_ally.Moves.Count == 3)
                return ui.DisplayBattleMessageForInt("Attack:",
                    _ally.Moves.Get(1).Name,
                    _ally.Moves.Get(2).Name,
                    _ally.Moves.Get(3).Name, "");
            else 
                return ui.DisplayBattleMessageForInt("Attack:",
                    _ally.Moves.Get(1).Name,
                    _ally.Moves.Get(2).Name, 
                    _ally.Moves.Get(3).Name, 
                    _ally.Moves.Get(4).Name);
        }

        private BaseMove _getRandomMoveFromEnemy(BasePokemon enemy)
        {
            if (enemy.Moves.Count == 1)
                return enemy.Moves.Get(1);
            else
            {
                Random rand = new Random();
                return enemy.Moves.Get(rand.Next(1, enemy.Moves.Count + 1));
            }
        }

        public enum Type { WILD, TRAINER, SAFARI_ZONE };
    }
}
