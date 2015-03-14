using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lifedungeon
{
    public class RNG
    {
        private static RNG instance;
        public int seed { get; set; }
        public Random rnd;

        private RNG(){}

        public static RNG Instance
        {
            get
            {
                if( instance == null ){
                    instance = new RNG();   
                }
                return instance;
            }
        }

        public Random getRNG( int seed )
        {
            rnd =  new Random(seed);
            return rnd;
        }

        public Random getRNG()
        {
            if( rnd == null )
            {
                int s = 0;
                if (seed != 0)
                {
                    s = seed;
                }
                rnd = new Random( s );
            }
            return rnd;
        }

        public int diceRoll( int sides )
        {
            return getRNG().Next( 1, sides );
        }
    }

}

