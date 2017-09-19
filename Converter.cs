using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorSS
{
    static class Converter
    {
        public static bool ConvertTrans(int system,string digit,out string result)
        {
            result = "0";

            switch (system)
            {
                case 2:
                    if (Search(system, digit))
                    {
                        result = STo10(system, digit);
                        return true;
                    }
                    break;
                case 8:
                    if (Search(system, digit))
                    {
                        result = STo10(system, digit);
                        return true;
                    }
                    break;
                case 10:
                    if (Search(system, digit))
                    {
                        result = digit;
                        return true;
                    }
                    break;
                case 16:
                    if (Search(system, digit))
                    {
                        result = STo10(system, digit);
                        return true;
                    }
                    break;
            }
            return false;
        }

        private static bool Search(int system, string digit)
        {
            foreach(char c in digit)
            {
                int pop = 0;
                try
                {
                    pop = Convert.ToInt32(c.ToString());
                }
                catch
                {
                    pop = S16ToInt(c.ToString());
                }

                if (pop > system) return false;
            }

            return true;
        }

        private static int S16ToInt(string sym)
        {
            switch (sym)
            {
                case "A": return 10;
                case "B": return 11;
                case "C": return 12;
                case "D": return 13;
                case "E": return 14;
                case "F": return 15;
                default:  return 0;
            }
        }

        private static string STo10(int system,string digit)
        {
            int count = digit.Length-1;
            int result = 0;

            foreach (char c in digit)
            {
                try
                {
                    result += (int)(Convert.ToInt32(c.ToString()) * Math.Pow(system, count));
                }
                catch
                {
                    result += (int)(S16ToInt(c.ToString()) * Math.Pow(system, count));
                }
                count--;
            }

            return result.ToString();
        }
    }
}
