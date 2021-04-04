using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakiFront
{
    public class PlayersDataList
    {
        public List<string> names { get; set; }
        public int thisPlyIndex { get; set; }
        public int currGameIndex { get; set; }

        private JsonClassStartGame _startGame;

        public PlayersDataList(JsonClassStartGame startGame)
        {
            _startGame = startGame;
            thisPlyIndex = _startGame.getIndexThisPlayer();
            currGameIndex = 0;
            names = setNamesByIndexes();
        }

        private List<string> setNamesByIndexes()
        {
            int len = _startGame.turns.Count + 1;
            string[] namesNew = new string[len];
            int ind = 0;
            for (int i = 0; i < len - 1 && i < _startGame.player_names.Count; i++)
            {
                ind = _startGame.turns[i];
                if (ind < len)
                {
                    namesNew[ind] = _startGame.player_names[i];
                }
            }
            return (new List<string>(namesNew));

        }

    }
}
