using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Series_Analyzer_1
{
    internal class Program
    {
        static int[] listToArry(List<int> numbers)
        {
            int lenList = numbers.Count;
            int[] newList = new int[lenList-1];

            for (int i = 0;i< lenList; i++)
            {
                newList[i] = numbers[lenList - i];
            }

            return newList;
        }

        static int findMax(List<int> _numbers)
        {
            int max = _numbers[0];
            foreach(int num in _numbers)
            {
                if (max < num)
                    max = num;
            }
            return max;
        }
        static int findMin(List<int> _numbers)
        {
            int min = _numbers[0];
            foreach (int num in _numbers)
            {
                if (min > num)
                    min = num;
            }
            return min;
        }
        static List<int> arryToList( string[] sriList)
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
        static bool testLenLIst(List<int> lis)
        {
            
            int len = 0;
            foreach (int i in lis)
            {
                len += 1;
            }
            return (len > 2);
        }


        static List<int> numbersReception()
        {
            List<int> _numbers = new List<int>();
            Console.WriteLine("Enter number or 'X' to exit");
            string input = Console.ReadLine();
            while (input != "x" && input != "X")
            {
                int newNum;
                if (int.TryParse(input, out newNum) && newNum > 0)
                {
                    _numbers.Add(newNum);
                }
                Console.WriteLine("Enter number or 'X' to exit");
                input = Console.ReadLine();
            }

            return _numbers;

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
                        while (!testLenLIst(numbers));
                        break;
                    case 2:
                        printList(numbers);
                        break;
                    case 3:
                        printListReversed(numbers);
                        break;
                    case 4:

                        break;
                    case 5:
                        printMax(numbers);
                        break;
                    case 6:
                        printMin(numbers);
                        break;
                    case 7:

                        break;
                    case 8:

                        break;
                    case 9:

                        break;
                }
            }
        }

        static void printList(List<int> numbers)
        {
            foreach(int num in numbers)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

        static void printMax(List<int> _numbers)
        {
            Console.WriteLine(findMax(_numbers));
        }

        static void printMin(List<int> _numbers)
        {
            Console.WriteLine(findMin(_numbers));
        }


        static void printMenu()
        {
            Console.WriteLine("1 to Input a Series. (Replace the current series)\r\n2 to Display the series in the order it was entered.\r\n3 to Display the series in the reversed order it was entered.\r\n4 to Display the series in sorted order (from low to high).\r\n5 to Display the Max value of the series.\r\n6 to Display the Min value of the series.\r\n7 to Display the Average of the series.\r\n8 to Display the Number of elements in the series.\r\n9 to Display the Sum of the series.\r\n10 to Exit.\r\n");
        }

        static void printListReversed(List<int> numbers)
        {
            for (int i = numbers.Count;i >0; i--)
            {
                Console.Write(numbers[i-1] + " ");
            }
            Console.WriteLine("");
        }

        /// ////////      //////////////         //////////////////             ///////////              //////////
        static void Main(string[] args)
        {
            List<int> numbersArr = arryToList(args);      

            while(!testLenLIst(numbersArr))
            {
                numbersArr = numbersReception();
            }

            string input ;
            do
            {
                printMenu();

                input = Console.ReadLine();
                activeFan(input,ref  numbersArr);

            } while (input != "10");

            





        }
    }
}
