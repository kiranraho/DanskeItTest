using System;

namespace CodilityTest.Extension
{
    public static class GenarateCustomer
    {
        public static string Gender()
        {
            string[] authors = { "Male","Female"};

            // Create a Random object  
            Random rand = new Random();
            // Generate a random index less than the size of the array.  
            int index = rand.Next(authors.Length);
            return authors[index];
        }

        public static int Age()
        {
            Random r = new Random();
            int genRand = r.Next(25, 60);
            return genRand;
        }

        public static int Date()
        {
            Random r = new Random();
            int genRand = r.Next(1, 30);
            return genRand;
        }
        public static int Month()
        {
            Random r = new Random();
            int genRand = r.Next(1, 12);
            return genRand;
        }

        public static int Year(int age)
        {
            var year = DateTimeOffset.Now.AddYears(-(age)).Year;
            return year;
        }

        public static string Code()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
             
            return new String(stringChars);
        }
    }
}
