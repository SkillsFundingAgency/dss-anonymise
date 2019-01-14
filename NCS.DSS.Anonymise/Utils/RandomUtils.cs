using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCS.DSS.Anonymise.Utils
{
    public class RandomUtils
    {

        private static Random random = new Random();
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public string RandomString()
        {
            return new string(Enumerable.Repeat(chars, random.Next(6))
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public int RandomNumber()
        {
            return random.Next(1, 9);

        }

        public DateTime RandomDate()
        {
            DateTime start = new DateTime(1955, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(random.Next(range));
        }


        public string RandomEmail()
        {
            return RandomString() + "@" + RandomString() + ".com";
        }

        public string RandomMobile()
        {
            return "07" + RandomNumber() + RandomNumber() + RandomNumber() +
                        RandomNumber() + RandomNumber() + RandomNumber() +
                        RandomNumber() + RandomNumber();
        }

        public string RandomPhoneNumber()
        {
            StringBuilder telNo = new StringBuilder(12);
            int number;

            telNo = telNo.Append("0");
            for (int i = 0; i < 4; i++)
            {
                number = random.Next(0, 8);
                telNo = telNo.Append(number.ToString());
            }
            telNo = telNo.Append(" ");
            number = random.Next(0, 743);
            telNo = telNo.Append(String.Format("{0:D3}", number));
            number = random.Next(0, 10000);
            telNo = telNo.Append(String.Format("{0:D4}", number));
            return telNo.ToString();
        }

        public string GetLetter()
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < 1; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString().ToUpper();
        }

        public string GenPostCode()
        {
            return GetLetter() + GetLetter() + RandomNumber() + RandomNumber() +
                " " + RandomNumber() + GetLetter() + GetLetter();
        }


    }
}
