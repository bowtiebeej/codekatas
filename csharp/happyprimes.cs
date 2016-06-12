using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Howdy Y'all! Let's play with Happy Prime Numbers");
        for (int i = 0; i < 500; i++)
        {
            bool prime = HappyPrimeFinder.IsPrime(i);
            if (prime)
            {
                bool happy = HappyPrimeFinder.IsHappy(i);
                if (happy)
                {
                    Console.WriteLine("{0} Is a Happy Prime", i);
                }
            }
        }
    }

    public static class HappyPrimeFinder
    {
        public static bool IsPrime(int num)
        {
            if ((num & 1) == 0)
            {
                if (num == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            for (int i = 3; (i*i) <= num; i += 2)
            {
                if ((num % i) == 0)
                {
                    return false;
                }
            }
            return num != 1;
        }

        public static bool IsHappy(int primes)
        {
            int intermediate = 0;
            bool happiness;
            char[] numberChar = primes.ToString().ToCharArray();
            int[] numberArray = new int[numberChar.Length];

            int count = 0;
            foreach (char c in numberChar)
            {
                double temp = Char.GetNumericValue(c);
                numberArray[count] = Convert.ToInt32(temp);
                count++;
            }

            foreach (int n in numberArray)
            {
                intermediate += n * n;
            }

            while (intermediate != 1 && intermediate != 4)
            {
                char[] intNumberChar = intermediate.ToString().ToCharArray();
                int[] intNumberArray = new int[intNumberChar.Length];

                count = 0;
                foreach (char c in intNumberChar)
                {
                    double tempInt = Char.GetNumericValue(c);
                    intNumberArray[count] = Convert.ToInt32(tempInt);
                    count++;
                }
                intermediate = 0;
                foreach (int n in intNumberArray)
                {
                    intermediate += n * n;
                }
            }
            switch (intermediate)
            {
                case 1:
                    happiness = true;
                    break;
                default:
                    happiness = false;
                    break;
            }
            return happiness;
        }
    }
}