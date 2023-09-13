public class Functions
{

        private void printHello()
        {
            Console.WriteLine("Hello!");
        }

        public int printHello(int value)
        {
            int i = 0;
            for (; i < value; i++)
            {
                Console.WriteLine("Hello!");
            }
            return i;
        }

}