namespace BattleEngine
{

    public class Player{

        public string playerName;
        public int playerLevel, playerMaxHP, playerCurrentHP, playerMaxMP, playerCurrentMP, playerDef, playerSpeed;

        public Player(string player_name, int player_level, int player_max_hp, int player_curr_hp, int player_max_mp, int player_curr_mp, int player_defense, int player_speed){
            playerName = player_name;
            playerLevel = player_level;
            playerMaxHP = player_max_hp;
			playerCurrentHP = player_curr_hp;
            playerMaxMP = player_max_mp;
			playerCurrentMP = player_curr_mp;
            playerDef = player_defense;
            playerSpeed = player_speed;
        }
        
        public string getPlayerName()
		{
			return playerName;
		}
		public int getPlayerLevel()
		{
			return playerLevel;
		}
		public int getCurrentPlayerHP(){
            return playerCurrentHP;
        }
        public int getMaxPlayerHP(){
            return playerMaxHP;
        }
        public int getCurrentPlayerMP(){
            return playerCurrentMP;
        }
        public int getMaxPlayerMP(){
            return playerMaxMP;
        }
		public int getPlayerDef()
		{
			return playerDef;
		}
		public int getPlayerSpeed()
		{
			return playerSpeed;
		}



		public void setHP(int HP)
		{
			playerCurrentHP = HP;
		}
		public void setMP(int MP)
		{
			playerCurrentMP = MP;
		}
		public void setPlayerName(string name)
		{
			playerName = name;
		}
		public void setPlayerLevel(int level)
		{
			playerLevel = level;
		}
		public void setPlayerDef(int defense)
		{
			playerDef = defense;
		}
		public void setPlayerSpeed(int speed)
		{
			playerSpeed = speed;
		}

        public bool TakesDamage(int damage) {
            setHP(getCurrentPlayerHP() - damage);
            if (getCurrentPlayerHP() <= 0)
                return true;
            else
                return false;
        }

		public void Heal(int amount) {
			setHP(getCurrentPlayerHP() + amount);
		}

        
    }

}