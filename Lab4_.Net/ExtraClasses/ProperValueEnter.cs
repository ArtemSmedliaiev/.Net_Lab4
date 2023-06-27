namespace Lab4_.Net.ExtraClasses
{
    public class ProperValueEnter
    {
        public int IntValueEnter(string message)
        {
            while (true)
            {
                Console.WriteLine(message);
                int value;
                string str = Console.ReadLine();

                try
                {
                    value = Convert.ToInt32(str);
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nФормат введених даних не є int. Спробуйте знов");
                    continue;
                }

                return value;
            }
        }

        public string StringValueEnter(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
    }
}
