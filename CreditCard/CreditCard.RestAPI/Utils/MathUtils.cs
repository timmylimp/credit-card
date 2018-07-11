using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditCard.RestAPI.Utils
{
    public class MathUtils
    {
        public static bool IsPrimeNumber(int number)
        {
            if (number == 1)
                return false;

            int sqrt = (int) Math.Sqrt(number);
            for (int i = 2; i <= sqrt; i++)
                if (number % i == 0)
                    return false;

            return true;
        }
    }
}