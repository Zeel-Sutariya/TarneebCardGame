using Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace Tarneeb_Card_Game
{
    public class AI
    {
        public int AIBid(String gamemode,int currentbid, List<Card> playersCards)
        {
            if(gamemode== "Easy")
            {
                Random random = new Random();
                int bid = random.Next(currentbid, 13);

                Random rndm = new Random();
                int dobid = rndm.Next(0, 1);
                if(dobid==0) {
                    return 0;
                }
                else
                {
                    return bid;
                }

                //Random random = new Random(currentbid,);

            }
            else
            {
                return 0;
            }
        }
    }
    
}
