using System.Security.Cryptography;
using System.Text;

namespace HotelBooker.Services.Utility
{
    public class BookingUtility
    {
        public static string GenerateUniqueReference()
        {
            int length = 6;
            char[] chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();

            using (var rnGen = RandomNumberGenerator.Create())
            {
                var bytes = new byte[length];
                rnGen.GetBytes(bytes);

                var result = new StringBuilder(length);
                foreach (var byteValue in bytes)
                {
                    result.Append(chars[byteValue % chars.Length]);
                }

                return result.ToString();
            }
        }
    }
}
