using System;

namespace TimeZoneOffsetConverter
{
    public static class Program
    {
        public static void Main(string[] args)
        {

            // Some date time to test with.
            //
            // This particular datetime is the PST launch date of the SpaceX Falcon Heavy.
            //
            DateTimeOffset originalTime = DateTimeOffset.Parse("2018-02-06T13:30-05:00");

            for (int i = -14; i <= 14; i++)
            {
                // Get a TimeSpan representing the desired offset from UTC.
                //
                TimeSpan offset = TimeSpan.FromHours(i);

                // Convert the original time into the new offset
                //
                DateTimeOffset offsetTime = originalTime.ToOffset(offset);

                // Print the result in ISO 8601 ordinal time
                //
                Console.Write(offsetTime.ToString("o"));

                // Write a little marker for PST and UTC
                //
                // PST
                //
                if(offset == TimeSpan.FromHours(-8))
                {
                    Console.WriteLine(" <-- PST");
                }
                //
                // EST
                //
                else if (offset == TimeSpan.FromHours(-5))
                {
                    Console.WriteLine(" <-- EST");
                }
                //
                // Local Machine
                //
                else if (offset == TimeZoneInfo.Local.BaseUtcOffset)
                {
                    Console.WriteLine(" <-- YOU");
                }
                //
                // UTC
                //
                else if (offset == TimeSpan.FromHours(0))
                {
                    Console.WriteLine(" <-- UTC");
                }
                //
                // Everything else
                //
                else
                {
                    Console.WriteLine();
                }
            }

            Console.ReadLine();
        }
    }
}
