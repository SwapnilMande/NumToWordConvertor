using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace NumberToWordConvertor
{
    public class Program
    {
        static long input;
        static long temp;
        static long index = 0;
        static long[] buffer = new long[10];
        static StringBuilder sb = new StringBuilder();

        static void ones(long value)//to print numbers in ones
        {
            switch (value)
            {
                case 1: sb.Append(" One"); break;
                case 2: sb.Append(" Two"); break;
                case 3: sb.Append(" Three"); break;
                case 4: sb.Append(" Four"); break;
                case 5: sb.Append(" Five"); break;
                case 6: sb.Append(" Six"); break;
                case 7: sb.Append(" Seven"); break;
                case 8: sb.Append(" Eight"); break;
                case 9: sb.Append(" Nine"); break;
                default: break;
            }
        }

        static void teens(long value)//to print numbers which are in teens
        {
            switch (value)
            {
                case 0: sb.Append("Ten"); break;
                case 1: sb.Append(" Eleven"); break;
                case 2: sb.Append(" Twelve"); break;
                case 3: sb.Append(" Thirteen"); break;
                case 4: sb.Append(" Fourteen"); break;
                case 5: sb.Append(" Fifteen"); break;
                case 6: sb.Append(" Sixteen"); break;
                case 7: sb.Append(" Seventeen"); break;
                case 8: sb.Append(" Eighteen"); break;
                case 9: sb.Append(" Nineteen"); break;
            }
        }


        static void tens(long value)//to print tens values
        {
            switch (value)
            {
                case 2: sb.Append(" Twenty"); break;
                case 3: sb.Append(" Thirty"); break;
                case 4: sb.Append(" Forty"); break;
                case 5: sb.Append(" Fifty"); break;
                case 6: sb.Append(" Sixty"); break;

                case 7: sb.Append(" Seventy"); break;
                case 8: sb.Append(" Eighty"); break;
                case 9: sb.Append(" Ninty"); break;
                default: break;
            }
        }


        static void Main(string[] args)
        {

            Console.WriteLine("Enter a number to convert it into words");
            input = Convert.ToInt64(Console.ReadLine());//input from the user
            Program program = new Program();
            program.ProcessNumberforConversion(input);
            Console.ReadLine();
        }

        public string ProcessNumberforConversion(long input)
        {
            try
            {
                do
                {
                    buffer[index] = input % 10;
                    input /= 10;
                    index++;
                } while (input != 0);
                string finalstring = NumberToWordGenerator();
                Console.WriteLine(finalstring);
                return finalstring;
            }
            catch (ArithmeticException ex)
            {
                throw ex;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private static string NumberToWordGenerator()
        {
            try
            {
                for (temp = index - 1; temp >= 0; temp--)
                {
                    if (temp == 7)//check for the values in crore.
                    {
                        ones(buffer[temp]);
                        sb.Append(" Crore");
                    }
                    if (temp == 5)//check for the values in lakhs
                    {
                        if (buffer[temp + 1] == 1)
                        {
                            teens(buffer[temp]);
                            sb.Append(" Lakhs");
                        }
                        else
                        {
                            tens(buffer[temp + 1]);
                            ones(buffer[temp]);
                            if (!((buffer[temp + 1] == 0) && (buffer[temp] == 0)))
                            {
                                sb.Append(" Lakhs");
                            }
                        }
                    }
                    else if (temp == 3)//check for the numbers in thousands
                    {
                        if (buffer[temp + 1] == 1)
                        {
                            teens(buffer[temp]);
                            sb.Append(" Thousand");
                        }
                        else
                        {
                            tens(buffer[temp + 1]);
                            ones(buffer[temp]);
                            if (!((buffer[temp + 1] == 0) && (buffer[temp] == 0)))
                            {
                                sb.Append(" Thousand");
                            }
                        }
                    }
                    else if (temp == 2)//check for the numbers in hundreds
                    {
                        if (buffer[temp] != 0)
                        {
                            ones(buffer[temp]);
                            sb.Append(" Hundred");
                        }
                    }
                    else if (temp == 0)//chcek for the numbers in tens and ones
                    {
                        if (buffer[temp + 1] == 1)
                            teens(buffer[temp]);
                        else
                        {
                            tens(buffer[temp + 1]);
                            ones(buffer[temp]);
                        }
                    }
                }
                return sb.ToString();
            }
            catch (ArithmeticException ex) {
                throw ex;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
