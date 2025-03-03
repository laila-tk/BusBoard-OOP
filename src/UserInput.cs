namespace BusBoard
{
    class UserInput
    {
        public static string GetStopCode()
        {
            string stopCode;
            while (true)
            {
                Console.WriteLine("Please enter a StopPointId:");
                stopCode = Console.ReadLine();
                if (string.IsNullOrEmpty(stopCode))
                {
                    Console.WriteLine("StopPoint cant be empty. Please enter a valid ID.");
                }
                else
                {
                    break;
                }
            }
            return stopCode;
        }

    }
}