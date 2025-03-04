namespace BusBoard
{
    class UserInput
    {
        public static string GetPostCode()
        {
            string postCode;
            while (true)
            {
                Console.WriteLine("Please enter a PostCode");
                postCode = Console.ReadLine();
                if (string.IsNullOrEmpty(postCode))
                {
                    Console.WriteLine("StopPoint cant be empty. Please enter a valid ID.");
                }
                else
                {
                    break;
                }
            }
            return postCode;
        }

    }
}