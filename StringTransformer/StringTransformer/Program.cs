using System;

namespace StringTransformer
{
    class Program
    {
        static void Main(string[] args)
        {

            // 1) Get an input from the user

            string processingString = GetInput();

            string[] processingArray = processingString.Split(' ');

            string devoidOfNUmbersString = parseStringWithConditions(processingArray);

            Console.WriteLine(devoidOfNUmbersString);
            
        }

        static string GetInput()
        {
            Console.WriteLine("Please write something to us. \n");
            string processingString = Console.ReadLine();
            if(processingString.Length == 0)
            {
                Console.WriteLine("Please write something! \n");
                GetInput();
            } else
            {
                return processingString;
            }

            return "";
        }

        static string parseStringWithConditions(string[] wordsArr)
        {
            string[] filteredArray = new string[wordsArr.Length];
            string[] reversedOrParsedArray = new string[0];

            for(var i = 0; i < wordsArr.Length; i++)
            {
                var word = wordsArr[i];
                char[] wordArr = word.ToCharArray();
                char[] wordWithoutNumbersArr = new char[0];
                char p = 'p';
                char n = 'n';
                char replaceFirst = 'S';
                char replaceLast = 'O';
                string stringWithoutNumbers;
                foreach(char character in wordArr)
                {
                    // 2) Delete all the numbers 
                    if (!Char.IsNumber(character))
                    {
                        ArrayPush(ref wordWithoutNumbersArr, character);
                    }
                }

                // 3) Exchange letters into some other letter 
                char first = Char.ToLower(wordWithoutNumbersArr[0]);
                char last = Char.ToLower(wordWithoutNumbersArr[wordWithoutNumbersArr.Length - 1]);

                if (first == p)
                {
                    wordWithoutNumbersArr[0] = replaceFirst;
                }

                if(last == n)
                {
                    wordWithoutNumbersArr[0] = replaceLast;
                }

                // 4) Turn every first character into uppercase 
                wordWithoutNumbersArr[0] = Char.ToUpper(wordWithoutNumbersArr[0]);

                // 5) Exchange letters in an every odd word. 
                if (i % 2 != 0)
                {
                    Array.Reverse(wordWithoutNumbersArr);
                }

                stringWithoutNumbers = new string(wordWithoutNumbersArr);
                ArrayPush(ref reversedOrParsedArray, stringWithoutNumbers);
            }

            return String.Join(" ", reversedOrParsedArray);
        }

        public static void ArrayPush<T>(ref T[] table, object value)
        {
            Array.Resize(ref table, table.Length + 1); 
            table.SetValue(value, table.Length - 1); 
        }
    }
}
