using System;
using System.Collections.Generic;

namespace BattleEngine
{
    public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

    public class Battle
    {

        public BattleState state;

        public List<Player> players;
        public List<Enemy> enemies;

        public Player player_one;
        public Player player_two;
        public Enemy enemy_one;

        public Random RandomNumberGenerator;
        public int RandomValue;
        public int TargetValue;

        public void Start()
        {
            state = BattleState.START;
            SetupBattle();
        }

        void displayCurrentBattleState(Player player_one, Player player_two, Enemy enemy)
        {
            if (player_one == null | player_two == null | enemy == null)
            {
                Console.WriteLine("ERROR. CANNOT DISPLAY VALUES.");
            }
            else
            {
                Console.WriteLine("Player:\t\t\tPlayer:\t\t\tEnemy:");
                Console.WriteLine(player_one.getPlayerName()+"\t\t\t"+ player_two.getPlayerName() + "\t\t\t" + enemy.getEnemyName());
                Console.WriteLine("Current HP: " + player_one.getCurrentPlayerHP() + "\t\tCurrent HP: " + player_two.getCurrentPlayerHP() + "\t\tCurrent HP: " + enemy.getCurrentEnemyHP());
                Console.WriteLine("Current MP: " + player_one.getCurrentPlayerMP() + "\t\tCurrent MP: " + player_two.getCurrentPlayerMP() + "\t\tCurrent MP: " + enemy.getCurrentEnemyMP()+"\n");
            }
        }


        void SetupBattle()
        {
            //                             Name   LV  HP  HP  MP  MP DEF SPEED
            player_one      = new Player("Aerin", 10, 40, 40, 25, 25, 0, 9);
            player_two      = new Player("Luna",  10, 35, 35, 40, 40, 0, 7);
            enemy_one        = new Enemy("Cleigh",12, 80, 80, 30, 30, 0, 3);

            Console.WriteLine("You've encountered " + enemy_one.getEnemyName() + "!\n");

            //One second timer
            System.Threading.Thread.Sleep(1000);

            //If Player is faster than enemy, player goes first.
            if (player_one.getPlayerSpeed() > enemy_one.getEnemySpeed() | player_two.getPlayerSpeed() > enemy_one.getEnemySpeed())
            {
                state = BattleState.PLAYERTURN;
                PlayerTurn(player_one);
            }
            else
            {
                state = BattleState.ENEMYTURN;
                EnemyTurn();
            }
        }

        void PlayerTurn(Player player)
        {
            displayCurrentBattleState(player_one, player_two, enemy_one);

            string attackChoice = "";

            Console.WriteLine("---------------------\n" + "|   " + player.getPlayerName() + "'s turn!   |\n" + "---------------------\n");


            if (player.getPlayerName().Equals("Aerin"))
            {
                while (!attackChoice.Equals("Bomb Arrows") |
                       !attackChoice.Equals("Bow") |
                       !attackChoice.Equals("Heal") |
                       !attackChoice.Equals("Super Heal"))
                {

                    //Attack Phase
                    Console.WriteLine("Select an action (Bow/Bomb Arrows/Heal/Super Heal):");
                    attackChoice = Console.ReadLine();


                    if (attackChoice.Equals("Bow"))
                    {
                        bool isEnemyDead = enemy_one.TakesDamage(4);
                        Console.WriteLine(player.getPlayerName() + " attacks " + enemy_one.getEnemyName() + " with a Bow!\n");
                        Console.WriteLine(enemy_one.getEnemyName() + " took 4 damage!\n");
                        if (isEnemyDead == true)
                        {
                            state = BattleState.WON;
                            EndBattle();
                            break;
                        }
                        else
                        {
                            state = BattleState.PLAYERTURN;
                            PlayerTurn(player_two);
                            break;
                        }
                    }
                    else if (attackChoice.Equals("Bomb Arrows") & player.getCurrentPlayerMP() > 3)
                    {
                        player.setMP(player.getCurrentPlayerMP() - 4);
                        bool isEnemyDead = enemy_one.TakesDamage(9);
                        Console.WriteLine(player.getPlayerName() + " attacks " + enemy_one.getEnemyName() + " with Bomb Arrows!\n");
                        Console.WriteLine(enemy_one.getEnemyName() + " took 9 damage!\n");
                        if (isEnemyDead)
                        {
                            state = BattleState.WON;
                            EndBattle();
                            break;
                        }
                        else
                        {
                            state = BattleState.PLAYERTURN;
                            PlayerTurn(player_two);
                            break;
                        }
                    }
                    else if (attackChoice.Equals("Heal") & player.getCurrentPlayerMP() > 2)
                    {
                        player.setMP(player.getCurrentPlayerMP() - 3);
                        player.Heal(5);
                        bool isEnemyDead = enemy_one.TakesDamage(0);
                        Console.WriteLine(player.getPlayerName() + " used Heal!\n");
                        Console.WriteLine(player.getPlayerName() + " regained 5 Health!\n");
                        if (isEnemyDead)
                        {
                            state = BattleState.WON;
                            EndBattle();
                            break;
                        }
                        else
                        {
                            state = BattleState.PLAYERTURN;
                            PlayerTurn(player_two);
                            break;
                        }
                    }
                    else if (attackChoice.Equals("Super Heal") & player_one.getCurrentPlayerMP() > 4)
                    {
                        player_one.setMP(player_one.getCurrentPlayerMP() - 5);
                        player_one.Heal(10);
                        bool isEnemyDead = enemy_one.TakesDamage(0);
                        Console.WriteLine(player_one.getPlayerName() + " used Super Heal!\n");
                        Console.WriteLine(player_one.getPlayerName() + " regained 10 Health!\n");
                        if (isEnemyDead)
                        {
                            state = BattleState.WON;
                            EndBattle();
                            break;
                        }
                        else
                        {
                            state = BattleState.PLAYERTURN;
                            PlayerTurn(player_two);
                            break;
                        }
                    }
                    else if (!attackChoice.Equals("Bomb Arrows") | !attackChoice.Equals("Bow") | !attackChoice.Equals("Heal") | !attackChoice.Equals("Super Heal"))
                    {
                        Console.WriteLine("Invalid Action.\n");
                        continue;
                    }
                }
            }
            if (player.getPlayerName().Equals("Luna"))
            {
                while (!attackChoice.Equals("Dagger") |
                       !attackChoice.Equals("Mirror Beam") |
                       !attackChoice.Equals("Heal") |
                       !attackChoice.Equals("Super Heal"))
                {

                    //Attack Phase
                    Console.WriteLine("Select an action (Dagger/Mirror Beam/Heal/Super Heal):");
                    attackChoice = Console.ReadLine();


                    if (attackChoice.Equals("Dagger"))
                    {
                        bool isEnemyDead = enemy_one.TakesDamage(2);
                        Console.WriteLine(player.getPlayerName() + " attacks " + enemy_one.getEnemyName() + " with a Dagger!\n");
                        Console.WriteLine(enemy_one.getEnemyName() + " took 2 damage!\n");
                        if (isEnemyDead == true)
                        {
                            state = BattleState.WON;
                            EndBattle();
                            break;
                        }
                        else
                        {
                            state = BattleState.ENEMYTURN;
                            EnemyTurn();
                            break;
                        }
                    }
                    else if (attackChoice.Equals("Mirror Beam") & player.getCurrentPlayerMP() > 5)
                    {
                        player.setMP(player.getCurrentPlayerMP() - 6);
                        bool isEnemyDead = enemy_one.TakesDamage(10);
                        Console.WriteLine(player.getPlayerName() + " attacks " + enemy_one.getEnemyName() + " with Mirror Beam!\n");
                        Console.WriteLine(enemy_one.getEnemyName() + " took 10 damage!\n");
                        if (isEnemyDead)
                        {
                            state = BattleState.WON;
                            EndBattle();
                            break;
                        }
                        else
                        {
                            state = BattleState.ENEMYTURN;
                            EnemyTurn();
                            break;
                        }
                    }
                    else if (attackChoice.Equals("Heal") & player.getCurrentPlayerMP() > 2)
                    {
                        player.setMP(player.getCurrentPlayerMP() - 3);
                        player.Heal(5);
                        bool isEnemyDead = enemy_one.TakesDamage(0);
                        Console.WriteLine(player.getPlayerName() + " used Heal!\n");
                        Console.WriteLine(player.getPlayerName() + " regained 5 Health!\n");
                        if (isEnemyDead)
                        {
                            state = BattleState.WON;
                            EndBattle();
                            break;
                        }
                        else
                        {
                            state = BattleState.ENEMYTURN;
                            EnemyTurn();
                            break;
                        }
                    }
                    else if (attackChoice.Equals("Super Heal") & player_one.getCurrentPlayerMP() > 4)
                    {
                        player_one.setMP(player_one.getCurrentPlayerMP() - 5);
                        player_one.Heal(10);
                        bool isEnemyDead = enemy_one.TakesDamage(0);
                        Console.WriteLine(player_one.getPlayerName() + " used Super Heal!\n");
                        Console.WriteLine(player_one.getPlayerName() + " regained 10 Health!\n");
                        if (isEnemyDead)
                        {
                            state = BattleState.WON;
                            EndBattle();
                            break;
                        }
                        else
                        {
                            state = BattleState.ENEMYTURN;
                            EnemyTurn();
                            break;
                        }
                    }
                    else if (!attackChoice.Equals("Dagger") | !attackChoice.Equals("Mirror Beam") | !attackChoice.Equals("Heal") | !attackChoice.Equals("Super Heal"))
                    {
                        Console.WriteLine("Invalid Action.\n");
                        continue;
                    }
                }
            }


        }

        void EnemyTurn()
        {
            displayCurrentBattleState(player_one, player_two, enemy_one);

            RandomNumberGenerator = new Random();



            Console.WriteLine("---------------------\n" + "|   " + enemy_one.getEnemyName() + "'s turn!  |\n" + "---------------------\n");

            //One Second Timer
            System.Threading.Thread.Sleep(1000);

            Player target;

            //Attack
            RandomValue = RandomNumberGenerator.Next(2);
            TargetValue = RandomNumberGenerator.Next(2);

            if (RandomValue == 0 & enemy_one.getCurrentEnemyMP() > 1)
            {
                if (TargetValue == 0)
                    target = player_one;
                else
                    target = player_two;

                enemy_one.setMP(enemy_one.getCurrentEnemyMP() - 2);
                bool isPlayerDead = target.TakesDamage(6);
                Console.WriteLine(enemy_one.getEnemyName() + " attacks "+player_one.getPlayerName()+" with Heavy Smash!\n");
                Console.WriteLine(target.getPlayerName() + " took 6 damage!\n");
                if (isPlayerDead)
                {
                    state = BattleState.LOST;
                    EndBattle();
                }
                else
                {
                    state = BattleState.PLAYERTURN;
                    PlayerTurn(player_one);
                }
            }
            else if (RandomValue == 1 & enemy_one.getCurrentEnemyMP()>5)
            {
                
                enemy_one.setMP(enemy_one.getCurrentEnemyMP()-6);
                bool isPlayerOneDead = player_one.TakesDamage(12);
                bool isPlayerTwoDead = player_one.TakesDamage(12);
                Console.WriteLine(enemy_one.getEnemyName() + " attacks " + player_one.getPlayerName() + " with Magmatic Fusion!\n");
                Console.WriteLine(player_one.getPlayerName() + " and " + player_two.getPlayerName() + " took 12 damage!\n");
                if (isPlayerOneDead | isPlayerTwoDead)
                {
                    state = BattleState.LOST;
                    EndBattle();
                }
                else
                {
                    state = BattleState.PLAYERTURN;
                    PlayerTurn(player_one);
                }
            }
            else
            {
                if (TargetValue == 0)
                    target = player_one;
                else
                    target = player_two;

                bool isPlayerDead = target.TakesDamage(4);
                Console.WriteLine(enemy_one.getEnemyName() + " attacks " + player_one.getPlayerName() + " with Punch!\n");
                Console.WriteLine(target.getPlayerName() + " took 4 damage!");
                if (isPlayerDead)
                {
                    state = BattleState.LOST;
                    EndBattle();
                }
                else
                {
                    state = BattleState.PLAYERTURN;
                    PlayerTurn(player_one);
                }
            }


        }


        //Check win condition



        public void EndBattle()
        {
            if (state == BattleState.WON)
            {
                Console.WriteLine(enemy_one.getEnemyName() + " has been defeated!\n");
                Console.WriteLine("You gained 420xp\n\n");
            }
            else if (state == BattleState.LOST)
            {
                Console.WriteLine("\n\nG A M E   O V E R\n\n");
            }
        }
    }
}

