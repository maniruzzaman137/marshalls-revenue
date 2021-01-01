using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace MarshallsRevenue
{
    class Program
    {
        static void Main(string[] args)
        {
            int month = ReturnMonth();
            WriteLine("Enter a number of interior murals from 0 to 30");
            int numMuralIn = ReturnNumberOfMurals();
            WriteLine("Enter a number of exterior murals from 0 to 30");
            int numMuralEx = ReturnNumberOfMurals();
            CalcRevenue(month, numMuralIn, numMuralEx);
            string[,] NameAndCodeArrayIn = ReturnNameAndCodeArray(numMuralIn);
            string[,] NameAndCodeArrayEx = ReturnNameAndCodeArray(numMuralEx);
            CountCodes(NameAndCodeArrayIn, NameAndCodeArrayEx);
            DisplayJobs(NameAndCodeArrayIn, NameAndCodeArrayEx);
        }
        private static int ReturnMonth()
        {
            WriteLine("Enter a number from 1 to 12 for a month");
            int month = Convert.ToInt32(ReadLine());
            while (!(month >= 1 && month <= 12))
            {
                WriteLine("Reennter a number from 1 to 12 for a month");
                month = Convert.ToInt32(ReadLine());
            }
            return month;
        }
        private static int ReturnNumberOfMurals()
        {           
            int numMural = Convert.ToInt32(ReadLine());
            while (!(numMural >= 0 && numMural <= 30))
            {
                WriteLine("Enter again a number of murals from 0 to 30");
                numMural = Convert.ToInt32(ReadLine());
            }
            return numMural;
        }
        private static void CalcRevenue(int month, int numInterior, int numExterior)
        {


            if (month == 7 || month == 8)
            {
                WriteLine("Interior mural price: ${0}, exterior mural price: ${1} and expected total revenue: ${2}", 450, 750, numInterior * 450 + numExterior * 750);

            }

            else if (month == 3 || month == 6 || month == 11)
            {
                WriteLine("Interior mural price: ${0}, exterior mural price: ${1} and expected total revenue: ${2}", 500, 750, numInterior * 500 + numExterior * 750);
            }
            else if (month == 4 || month == 5 || month == 9 || month == 10)
            {
                WriteLine("Interior mural price: ${0}, exterior mural price: ${1} and expected total revenue: ${2}",500, 699, numInterior * 500 + numExterior * 699);
            }
            else if (month == 1 || month == 2 || month == 12)
            {
                numExterior = 0;
                WriteLine("Interior mural price: ${0}, order for exterior mural closed, and expected total revenue: ${1}", 500, numInterior * 500);
            }
        }
        private static string [,] ReturnNameAndCodeArray(int numMural)
        {
            string[,] NameAndCodeArray = new string[numMural, 2];
            for (int i=0; i<numMural; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (j == 0)
                    {
                        WriteLine("Enter a name for a customer");
                        NameAndCodeArray[i, j] = ReadLine();
                    }
                    else if (j==1)
                    {
                        WriteLine("Enter a code from L S A C and O for mural style");
                        
                        string code = ReadLine();
                        while (!(code == "L" || code == "S" || code == "A" || code == "C" || code == "O"))
                        {
                            WriteLine("Invalid code. Please reenter");
                            code = ReadLine();
                        }
                        NameAndCodeArray[i, j] = code;     
                    }
                }
            }
            return NameAndCodeArray;
        }
        private static void CountCodes(string[,] NameAndCodeArrayIn, string[,] NameAndCodeArrayEx)
        {
            int countL = 0;
            int countS = 0;
            int countA = 0;
            int countC = 0;
            int countO = 0;
            for (int i = 0; i < NameAndCodeArrayIn.GetLength(0); i++)
            {
                if (NameAndCodeArrayIn[i,1] == "L")
                {
                    countL += 1;
                }
                else if (NameAndCodeArrayIn[i, 1] == "S")
                {
                    countS += 1;
                }
                else if (NameAndCodeArrayIn[i, 1] == "A")
                {
                    countA += 1;
                }
                else if (NameAndCodeArrayIn[i, 1] == "O")
                {
                    countO += 1;
                }
                else
                {
                    countC += 1;
                }
            }

            for (int j = 0; j < NameAndCodeArrayEx.GetLength(0); j++)
            {
                if (NameAndCodeArrayEx[j, 1] == "L")
                {
                    countL += 1;
                }
                else if (NameAndCodeArrayEx[j, 1] == "S")
                {
                    countS += 1;
                }
                else if (NameAndCodeArrayEx[j, 1] == "A")
                {
                    countA += 1;
                }
                else if (NameAndCodeArrayEx[j, 1] == "O")
                {
                    countO += 1;
                }
                else
                {
                    countC += 1;
                }
            }
            WriteLine("Number of landscape = {0}, seaside = {1}, abstract = {2}, children = {3}, and other = {4}", countL, countS, countA, countC, countO);

        }
        private static void DisplayJobs(string [,] NameAndCodeArrayIn, string [,] NameAndCodeArrayEx)
        {
            WriteLine("Enter a code");
            string code = ReadLine();
            while (code != "X")
            {


                for (int i = 0; i < NameAndCodeArrayIn.GetLength(0); i++)
                {
                    if (NameAndCodeArrayIn[i,1] == code)
                    {
                        WriteLine("{0} orders interior mural", NameAndCodeArrayIn[i, 0]);
                    }
                }

                for (int j = 0; j < NameAndCodeArrayEx.GetLength(0); j++)
                {
                    if (NameAndCodeArrayEx[j, 1] == code)
                    {
                        WriteLine("{0} orders exterior mural", NameAndCodeArrayEx[j, 0]);
                    }
                }
                WriteLine("Enter a code");
                code = ReadLine();
            }
        }

    }
}
