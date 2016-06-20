using System;

namespace TimeConversion
{
    class Program
    {
        //Given a time in AM/PM format, convert it to military (24-hour) time.
        static void Main(string[] args)
        {
            string time = Console.ReadLine();
            if (time != null)
            {
                var isAM = time.IndexOf('A');
                var trimmedTime = time.Substring(0, isAM != -1 ? isAM : time.IndexOf('P')).Split(':');
                
                var hr = Convert.ToInt32(trimmedTime[0]);
                
                if (isAM == -1 && hr != 12)
                {
                    hr += 12;
                }else if (isAM > -1 && hr == 12)
                {
                    hr = 0;
                }

                Console.WriteLine($"{hr.ToString("D2")}:{trimmedTime[1]}:{trimmedTime[2]}");
               
            }
        }
    }
}
