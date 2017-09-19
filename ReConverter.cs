using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorSS
{
    static class ReConverter
    {
        public static bool ConvertTrans(int system, string digit, out string result)
        {
            result = "0";

            switch (system)
            {
                case 2:
                    bool work = false;

                    if (Convert.ToInt32(digit) < 0)
                    {
                        work = true;
                        digit = digit.Remove(0, 1);
                    }
                    if (work)
                    {
                        ReverceCode(system, digit, out result);
                        return true;
                    }
                    else
                    {
                        result = S10To2(system, digit);
                        return true;
                    }
                    break;
                case 8:
                    result = S10To2(system, digit);
                    return true;
                    break;
                case 10:
                    result = digit;
                    return true;
                    break;
                case 16:
                    result = S10To2(system, digit);
                    return true;
                    break;
            }
            return false;
        }


        private static void ReverceCode(int system,string digit,out string result)
        {
            string hash  = S10To2(system, digit);

            string reverce = null;

            foreach (char c in hash)
            {
                if (c == '0') reverce += 1; else reverce += 0;
            }

            int start_index = reverce.LastIndexOf("0");

            if (start_index == -1)
            {
                string ret = null;

                foreach (char c in reverce) ret += 0;

                ret = "1" + ret;

                result = ret;
            }
            else
            {
                string ret = null;

                for (int i = start_index; i < reverce.Length; i++)
                {
                    if (reverce[i] == '0') ret += 1; else ret += 0;
                }

                reverce = reverce.Remove(start_index, reverce.Length - start_index);

                result = reverce + ret;
            }
        }
        private static string S16ToInt(string sym)
        {
            switch (sym)
            {
                case "10": return "A";
                case "11": return "B";
                case "12": return "C";
                case "13": return "D";
                case "14": return "E";
                case "15": return "F";
                default: return null;
            }
        }

        private static string S10To2(int system,string digit)
        {
            int hash = Convert.ToInt32(digit);
            string result = null; ;

            while (hash > 0)
            {
                if(system!=16) result = (hash % system).ToString() + result;
                else
                    result = S16ToInt((hash % system).ToString()) + result;
                hash /= system;
            }

            return result;
        }


    }
}
