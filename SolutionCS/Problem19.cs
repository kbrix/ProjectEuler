using System;

namespace SolutionCS
{
    public class Problem19
    {
        public static int Solution()
        {
            var counter = 0;
            
            for (int month = 1; month <= 12; month++)
            {
                for (int year = 1901; year <= 2000; year++)
                {
                    var date = new DateTime(year, month, 1);
                    if (date.DayOfWeek == DayOfWeek.Sunday)
                    {
                        counter++;
                    }
                }
                
            }

            return counter;
        }
    }
}