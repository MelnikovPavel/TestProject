using System;

namespace ApiTests.Helpers
{
    public class GenerateData
    {
        public static string GeneratePhoneNumber(int amountOfNumbers)
        {
            Random random = new Random();
            string phoneNumber = "";
            for (int i = 1; i < amountOfNumbers; i++)
            {
                phoneNumber += random.Next(0, 9).ToString();
            }
            return phoneNumber;
        }
    }
}
