using System;
using System.Collections.Generic;
using System.Text;

namespace BattleEngine
{
    public class Attack
    {
        public string attackName;
        public int attackPower;
        public int attackCost;


        public Attack(string atk_name, int atk_power, int atk_cost) {
            attackName = atk_name;
            attackPower = atk_power;
            attackCost = atk_cost;
        }

        public void setName(string name) {
            attackName = name;
        }
        public void setPower(int power) {
            attackPower = power;
        }
        public void setCost(int cost) {
            attackCost = cost;
        }
        public string getName() {
            return attackName;
        }
        public int getPower() {
            return attackPower;
        }
        public int getCost() {
            return attackCost;
        }
    }
}
