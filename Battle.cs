using System;

namespace BattleEngine
{
    public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

    public class Battle
    {

        public BattleState state;

        public Player playerInstance;
        public Enemy enemyInstance;

        public Random RandomNumberGenerator;
        public int RandomValue;

        public void Start()
        {
            state = BattleState.START;
            SetupBattle();
        }

        void displayCurrentBattleState(Player player, Enemy enemy)
        {
            if (player == null | enemy == null)
            {
                Console.WriteLine("ERROR. CANNOT DISPLAY VALUES.");
            }
            else
            {
                Console.WriteLine("Player:\t\t\tEnemy:");
                Console.WriteLine(player.getPlayerName()+"\t\t\t"+ enemy.getEnemyName());
                Console.WriteLine("Current HP: " + player.getCurrentPlayerHP() + "\t\tCurrent HP: " + enemy.getCurrentEnemyHP());
                Console.WriteLine("Current MP: " + player.getCurrentPlayerMP() + "\t\tCurrent MP: " + enemy.getCurrentEnemyMP()+"\n");
            }
        }


        void SetupBattle()
        {
            //                            Name   LV  HP  HP  MP  MP DEF SPEED
            playerInstance = new Player("Aerin", 10, 40, 40, 25, 25, 0, 5);
            enemyInstance   = new Enemy("Cleigh",12, 50, 50, 20, 20, 0, 3);



            AttackAdapter.loadPlayerAttacks();
            AttackAdapter.loadEnemyAttacks();


            Console.WriteLine("You've encountered " + enemyInstance.getEnemyName() + "!\n");

            //One second timer
            System.Threading.Thread.Sleep(1000);

            //If Player is faster than enemy, player goes first.
            if (playerInstance.getPlayerSpeed() > enemyInstance.getEnemySpeed())
            {
                state = BattleState.PLAYERTURN;
                PlayerTurn();
            }
            else
            {
                state = BattleState.ENEMYTURN;
                EnemyTurn();
            }
        }

        void PlayerTurn()
        {
            displayCurrentBattleState(playerInstance, enemyInstance);



            Console.WriteLine("---------------------\n" + "|   " + playerInstance.getPlayerName() + "'s turn!   |\n" + "---------------------\n");




            //Attack Phase
            Console.WriteLine("Select an action (Bow/Bomb Arrows/Heal/Super Heal):");
            string attackChoice = Console.ReadLine();

            if (attackChoice.Equals("Bow"))
            {
                bool isEnemyDead = enemyInstance.TakesDamage(5);
                Console.WriteLine(playerInstance.getPlayerName() + " attacks " + enemyInstance.getEnemyName() + " with a Bow!\n");
                Console.WriteLine(enemyInstance.getEnemyName() + " took 4 damage!\n");
                if (isEnemyDead == true)
                {
                    state = BattleState.WON;
                    EndBattle();
                }
                else
                {
                    state = BattleState.ENEMYTURN;
                    EnemyTurn();
                }
            }
            else if (attackChoice.Equals("Bomb Arrows") & playerInstance.getCurrentPlayerMP() > 3)
            {
                playerInstance.setMP(playerInstance.getCurrentPlayerMP() - 4);
                bool isEnemyDead = enemyInstance.TakesDamage(9);
                Console.WriteLine(playerInstance.getPlayerName() + " attacks " + enemyInstance.getEnemyName() + " with Bomb Arrows!\n");
                Console.WriteLine(enemyInstance.getEnemyName() + " took 9 damage!\n");
                if (isEnemyDead)
                {
                    state = BattleState.WON;
                    EndBattle();
                }
                else
                {
                    state = BattleState.ENEMYTURN;
                    EnemyTurn();
                }
            }
            else if (attackChoice.Equals("Heal") & playerInstance.getCurrentPlayerMP() > 2)
            {
                playerInstance.setMP(playerInstance.getCurrentPlayerMP() - 3);
                playerInstance.Heal(5);
                bool isEnemyDead = enemyInstance.TakesDamage(0);
                Console.WriteLine(playerInstance.getPlayerName() + " used Heal!\n");
                Console.WriteLine(playerInstance.getPlayerName() + " regained 5 Health!\n");
                if (isEnemyDead)
                {
                    state = BattleState.WON;
                    EndBattle();
                }
                else
                {
                    state = BattleState.ENEMYTURN;
                    EnemyTurn();
                }
            }
            else if (attackChoice.Equals("Super Heal") & playerInstance.getCurrentPlayerMP() > 4)
            {
                playerInstance.setMP(playerInstance.getCurrentPlayerMP() - 5);
                playerInstance.Heal(10);
                bool isEnemyDead = enemyInstance.TakesDamage(0);
                Console.WriteLine(playerInstance.getPlayerName() + " used Super Heal!\n");
                Console.WriteLine(playerInstance.getPlayerName() + " regained 10 Health!\n");
                if (isEnemyDead)
                {
                    state = BattleState.WON;
                    EndBattle();
                }
                else
                {
                    state = BattleState.ENEMYTURN;
                    EnemyTurn();
                }
            }
            else
                Console.WriteLine("Invalid action.");

        }

        void EnemyTurn()
        {
            displayCurrentBattleState(playerInstance, enemyInstance);

            RandomNumberGenerator = new Random();



            Console.WriteLine("---------------------\n" + "|   " + enemyInstance.getEnemyName() + "'s turn!   |\n" + "---------------------\n");

            //One Second Timer
            System.Threading.Thread.Sleep(1000);

            //Attack
            RandomValue = RandomNumberGenerator.Next(2);

            if (RandomValue == 0 & enemyInstance.getCurrentEnemyMP() > 1)
            {
                enemyInstance.setMP(enemyInstance.getCurrentEnemyMP() - 2);
                bool isPlayerDead = playerInstance.TakesDamage(6);
                Console.WriteLine(enemyInstance.getEnemyName() + " attacks "+playerInstance.getPlayerName()+" with Heavy Smash!\n");
                Console.WriteLine(playerInstance.getPlayerName() + " took 6 damage!\n");
                if (isPlayerDead)
                {
                    state = BattleState.LOST;
                    EndBattle();
                }
                else
                {
                    state = BattleState.PLAYERTURN;
                    PlayerTurn();
                }
            }
            else if (RandomValue == 1 & enemyInstance.getCurrentEnemyMP()>5)
            {
                enemyInstance.setMP(enemyInstance.getCurrentEnemyMP()-6);
                bool isPlayerDead = playerInstance.TakesDamage(12);
                Console.WriteLine(enemyInstance.getEnemyName() + " attacks " + playerInstance.getPlayerName() + " with Magmatic Fusion!\n");
                Console.WriteLine(playerInstance.getPlayerName() + " took 12 damage!\n");
                if (isPlayerDead)
                {
                    state = BattleState.LOST;
                    EndBattle();
                }
                else
                {
                    state = BattleState.PLAYERTURN;
                    PlayerTurn();
                }
            }
            else
            {
                bool isPlayerDead = playerInstance.TakesDamage(4);
                Console.WriteLine(enemyInstance.getEnemyName() + " attacks " + playerInstance.getPlayerName() + " with Punch!\n");
                Console.WriteLine(playerInstance.getPlayerName() + " took 4 damage!");
                if (isPlayerDead)
                {
                    state = BattleState.LOST;
                    EndBattle();
                }
                else
                {
                    state = BattleState.PLAYERTURN;
                    PlayerTurn();
                }
            }


        }


        //Check win condition



        public void EndBattle()
        {
            if (state == BattleState.WON)
            {
                Console.WriteLine(enemyInstance.getEnemyName() + " has been defeated!\n");
                Console.WriteLine("You gained 420xp\n\n");
            }
            else if (state == BattleState.LOST)
            {
                Console.WriteLine("G A M E   O V E R\n\n");
            }
        }
    }
}

