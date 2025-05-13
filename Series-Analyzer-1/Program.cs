using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace Series_Analyzer_1
{
    internal class Program
    {
        static List<int> copyList(List<int> _list)
        {
            List<int> newList = new List<int>();
            foreach (int num in _list)
                newList.Add(num);
            return newList;
        }

        static List<int> arrayToList(string[] sriList)
        {
            List<int> numbers = new List<int>();
            foreach (string sri in sriList)
            {
                int strInt;
                if (int.TryParse(sri, out strInt) && strInt > 0)
                {
                    numbers.Add(strInt);
                }
            }
            return numbers;
        }

        static bool validLenLIst(List<int> lis)
        {
            return (lenOfList(lis) > 2);
        }

        static List<int> numbersReception()
        {
            List<int> _numbers = new List<int>();
            string input;
            do
            {
                Console.WriteLine("Enter number, Or 'X' to exit");
                input = Console.ReadLine();
                int newNum;

                if (int.TryParse(input, out newNum) && newNum > 0)
                {
                    _numbers.Add(newNum);
                }
                
            } while (input != "x" && input != "X");
            return _numbers;
        }

        static int findMax(List<int> _numbers)
        {
            int max = _numbers[0];
            foreach (int num in _numbers)
            {
                if (max < num)
                    max = num;
            }
            return max;
        }

        static int findMin(List<int> _numbers)
        {
            int min = -1;
            if (lenOfList(_numbers) > 0)
            {
                min = _numbers[0];
                if (lenOfList(_numbers) > 1)
                {
                    foreach (int num in _numbers)
                    {
                        if (min > num)
                            min = num;
                    }
                }
            }

            return min;
        }

        static int findAverage(List<int> _numbers)
        {
            return sumList(_numbers)/lenOfList(_numbers);
        }

        static int sumList(List<int> _numbers)
        {
            int sum = 0;
            foreach (int num in _numbers)
                sum += num;
            return sum;
        }

        static int lenOfList(List<int> _list)
        {
            int len = 0;
            foreach (int num in _list)
                len += 1;
            return len;
        }

        static void activeFan(string input ,ref List<int> numbers ) 
        {
            int choich ;

            if ((int.TryParse(input,out choich)) && choich < 10 && choich > 0)
            {
                switch (choich)
                {
                    case 1:
                        do
                        {
                            numbers = numbersReception();
                        }
                        while (!validLenLIst(numbers));
                        break;
                    case 2:
                        printList(numbers);
                        break;
                    case 3:
                        printListReversed(numbers);
                        break;
                    case 4:
                        printSorted(numbers);
                        break;
                    case 5:
                        printer( findMax, numbers);
                        break;
                    case 6:
                        printer(findMax , numbers);
                        break;
                    case 7:
                        printer(findAverage,numbers);
                        break;
                    case 8:
                        printer(lenOfList, numbers);
                        break;
                    case 9:
                        printer(sumList, numbers);
                        break;
                }
            }
        }

        static void printer( Func <List<int> , int > func, List<int> _numbers )
        {
            Console.WriteLine(func(_numbers)); 
        }

        static void printList(List<int> numbers)
        {
            foreach(int num in numbers)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

        static void printMenu()
        {
            Console.WriteLine(" 1  to Input a Series. (Replace the current series)" +
                "\n 2  to Display the series in the order it was entered." +
                "\n 3  to Display the series in the reversed order it was entered." +
                "\n 4  to Display the series in sorted order (from low to high)." +
                "\n 5  to Display the Max value of the series.\n 6  to Display the Min value of the series." +
                "\n 7  to Display the Average of the series.\n 8  to Display the Number of elements in the series." +
                "\n 9  to Display the Sum of the series.\n 10 to Exit.\n");
        }

        static void printListReversed(List<int> numbers)
        {
            for (int i = numbers.Count;i >0; i--)
            {
                Console.Write(numbers[i-1] + " ");
            }
            Console.WriteLine("");
        }

        static void printSorted(List<int> _numbers)
        {
            List<int> newList = copyList(_numbers);
            while (lenOfList(newList) > 0)
            {
                int min = findMin(newList);
                Console.Write(min + " ");
                newList.Remove(min);
            }
            Console.WriteLine("");

        }


        //  **  \\\      |||\\      //|||       ///\\\       |||     |||\\  |||
        //  **** \\\     |||\\\    ///|||      ///__\\\      |||     |||\\\ |||
        //  **** ///     ||| \\\  /// |||     ///----\\\     |||     ||| \\\|||
        //  **  ///      |||  \\\///  |||    ///      \\\    |||     |||  \\|||
        static void Main(string[] args)
        {
            List<int> numbersArr = arrayToList(args);      

            while(!validLenLIst(numbersArr))
            {
                numbersArr = numbersReception();
            }

            string input ;
            do
            {
                printMenu();
                input = Console.ReadLine();
                Console.WriteLine();
                activeFan(input,ref numbersArr);

            } while (input != "10");


        }
    }
}
