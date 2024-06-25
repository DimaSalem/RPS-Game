using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS_Game
{
    public class Player
    {
        public string name { get; set; }
        public int score { get; set; }
        public RPSGame.enChoice move { get; set; }
        public Player(string Name)
        { 
            name= Name;
        }
    }
}
