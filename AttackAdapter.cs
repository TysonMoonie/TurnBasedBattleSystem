using System;
using System.Collections.Generic;
using System.Text;

namespace BattleEngine
{
    public class AttackAdapter
    {

        public AttackAdapter() {
        
        }

        public static List<Attack> playerAttacks = new List<Attack>();

        public static List<Attack> enemyAttacks = new List<Attack>();

        public static void loadPlayerAttacks() {
            //AttackAdapter.playerAttacks.Add(new Attack("Jump", 2, 0));
            //AttackAdapter.playerAttacks.Add(new Attack("Hammer", 2, 0));
        }

        public static void loadEnemyAttacks()
        {
            //AttackAdapter.enemyAttacks.Add(new Attack("Shell Toss", 2, 0));
            //AttackAdapter.enemyAttacks.Add(new Attack("Charge", 1, 0));
        }


    }
}
