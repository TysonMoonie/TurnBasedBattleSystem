using System;

namespace BattleEngine
{
	public class Enemy
	{


		public string enemyName;
		public int enemyLevel, enemyMaxHP, enemyCurrentHP, enemyMaxMP, enemyCurrentMP, enemyDef, enemySpeed;

		public Enemy(string enemy_name, int enemy_level, int enemy_max_hp, int enemy_curr_hp, int enemy_max_mp, int enemy_curr_mp, int enemy_defense, int enemy_speed)
		{
			enemyName = enemy_name;
			enemyLevel = enemy_level;
			enemyMaxHP = enemy_max_hp;
			enemyCurrentHP = enemy_curr_hp;
			enemyMaxMP = enemy_max_mp;
			enemyCurrentMP = enemy_curr_mp;
			enemyDef = enemy_defense;
			enemySpeed = enemy_speed;
		}



		public string getEnemyName()
		{
			return enemyName;
		}
		public int getEnemyLevel()
		{
			return enemyLevel;
		}
		public int getCurrentEnemyHP(){
            return enemyCurrentHP;
        }

        public int getMaxEnemyHP(){
            return enemyMaxHP;
        }

        public int getCurrentEnemyMP(){
            return enemyCurrentMP;
        }

        public int getMaxEnemyMP(){
            return enemyMaxMP;
        }
		public int getEnemyDef()
		{
			return enemyDef;
		}
		public int getEnemySpeed()
		{
			return enemySpeed;
		}



		public void setHP(int HP)
		{
			enemyCurrentHP = HP;
		}
		public void setMP(int MP)
		{
			enemyCurrentMP = MP;
		}
		public void setEnemyName(string name)
		{
			enemyName = name;
		}
		public void setEnemyLevel(int level)
		{
			enemyLevel = level;
		}
		public void setEnemyDef(int defense)
		{
			enemyDef = defense;
		}
		public void setEnemySpeed(int speed)
		{
			enemySpeed = speed;
		}



        public bool TakesDamage(int damage)
        {
            setHP(getCurrentEnemyHP() - damage);
            if (getCurrentEnemyHP() <= 0)
                return true;
            else
                return false;
        }




    }
}