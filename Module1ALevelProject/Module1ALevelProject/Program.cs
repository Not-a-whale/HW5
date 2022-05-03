using System;

namespace Module1ALevelProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int numberOfElements = GetInput();
            int[] arrayFromUserInput = new int[numberOfElements];
            char[] evenArr;
            char[] oddArr;
            char[] alphabet = { 'A', 'b', 'c', 'D', 'E', 'f', 'g', 'H', 'I', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            FillArrays(arrayFromUserInput, alphabet, out evenArr, out oddArr);
            PrintInfoAboutArrays(evenArr, oddArr);
        }

        public static int GetInput()
        {
            Console.WriteLine("Please input an integer to analize");
            string input = Console.ReadLine();
            bool isInt = true;
            foreach (char c in input)
            {
                if (!char.IsNumber(c))
                {
                    isInt = false;
                    break;
                }
            }

            if (isInt)
            {
                return int.Parse(input);
            }
                else
            {
                Console.WriteLine("You've entered not an integer");
                GetInput();
            }

            return 0;
        }

        public static void FillArrays(int[] arrayFromUserInput, char[] alphabet, out char[] evenArr, out char[] oddArr)
        {
            // filling with numbers
            int[] evenArray = new int[0];
            int[] oddArray = new int[0];

            char[] evenCharArray = new char[0];
            char[] oddCharArray = new char[0];

            for (int i = 0; i < arrayFromUserInput.Length; i++)
            {
                Random rnd = new Random();
                int rndNum = rnd.Next(1, 26);
                if (rndNum % 2 == 0)
                {
                    ArrayPush(ref evenArray, rndNum);
                }
                else
                {
                    ArrayPush(ref oddArray, rndNum);
                }
            }

            for (int j = 0; j < evenArray.Length; j++)
            {
                ArrayPush(ref evenCharArray, alphabet[((int)evenArray[j]) - 1]);
            }

            for (int k = 0; k < oddArray.Length; k++)
            {
                ArrayPush(ref oddCharArray, alphabet[((int)oddArray[k]) - 1]);
            }

            evenArr = evenCharArray;
            oddArr = oddCharArray;
        }

        public static void PrintInfoAboutArrays(char[] evenArr, char[] oddArr)
        {
            if (evenArr.Length > oddArr.Length)
            {
                Console.WriteLine("The array of even numbers turned out to be bigger");
            }
            else
            {
                Console.WriteLine("The array of odd numbers is clearly bigger");
            }

            Console.WriteLine("The letters in an even array are: ");
            Console.WriteLine(string.Join(" ", evenArr));

            Console.WriteLine("The letters in an odd array are: ");
            Console.WriteLine(string.Join(" ", oddArr));
        }

        public static void ArrayPush<T>(ref T[] arr, object value)
        {
            Array.Resize(ref arr, arr.Length + 1);
            arr.SetValue(value, arr.Length - 1);
        }
    }
}
