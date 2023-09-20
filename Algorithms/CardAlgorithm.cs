using System.Xml;

namespace Algorithms
{
    public static class CardAlgorithm
    {
        public static int FindCardLocation(int[] cards, int query)
        {
            // initialisiere variable index mit wert 0
            int index = -1;
            // schleife bis index gleich länge der cards liste
            for (int i = index + 1; i < cards.Length - 1;)
            {
                // wenn zahl von cards an index gleich query:
                // wahr: gebe index zurück
                if (cards[i] == query)
                {
                    return i;
                    break;
                }
                else
                {
                    // inkrement index um 1
                    i++;
                }

            }
            return index;
        }

        /*
         * Pseudo Code
         * 
         * INPUT: array cards, query
         * OUTPUT: index
         * 
         * SET index TO 0
         * SET left TO 0
         * SET right TO cards.length - 1
         * 
         * IF right EQUALS -1
         * RETURN -1
         * 
         * WHILE left SMALLER THAN right
         * 
         * SET index TO (left + right) / 2;
         * 
         *      IF query SMALLER EQUALS cards AT index
         * 
         *          IF query EQUALS cards AT index
         *          SET right TO index - 1
         *          ELSE
         *          SET right TO index
         *          
         *      ELSE
         *      SET left TO index
         * 
         * REPEAT WHILE
         * 
         * IF cards[index] EQUALS query
         * RETURN index
         * ELSE
         * RETURN -1
         * 
         */

        public static int FindCardLocationBinarySearch(int[] cards, int query)
        {
            int index = 0, left = 0, right = cards.Length - 1;
            int[] hits = new int[right];
            if (right == -1)
                return -1;

            while (left < right)
            {
                index = (left + right) / 2;

                if (query == cards[index])
                {
                    return index;
                }
                else if (query < cards[index])
                {
                    right = index - 1;
                }
                else
                {
                    left = index + 1;
                }
            }
            if(query != cards[index])
            return -1;

            return index;
        }

        public static int BinaryFindCardLocation(int[] cards, int query)
        {
            // Setze Variable left auf Wert 0
            int left = 0;
            // Setze Variable right auf Wert Länge von cards minus 1
            int right = cards.Length - 1;

            // Wenn Länge von cards gleich 0
            if (cards.Length == 0)
            {
                //   Wahr: Gebe -1 zurück
                return -1;
            }
            // Schleife solange left kleiner als right:
            while (left < right)
            {
                //   Setze Variable middle auf den Wert (left + right) / 2
                int middle = (left + right) / 2;
                //   Wenn middle gleich query:
                if (cards[middle] == query)
                {
                    //     Wahr: Gebe middle zurück
                    return middle;
                }
                //   Wenn query kleiner cards an middle:
                else if (query < cards[middle])
                {
                    //     Wahr: Setze right auf den Wert von middle - 1
                    right = middle - 1;
                }
                else
                {
                    //     Falsch: Setze left auf den Wert von middle + 1
                    left = middle + 1;
                }
            }
            return -1;
        }


    }



}