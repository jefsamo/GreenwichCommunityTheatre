using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenwichCommunityTheatre.Application.Services.Implementations.Reservation
{
    public class TicketCodeGenerator
    {
        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public static string GenerateTicketCode(int length = 5)
        {
            StringBuilder result = new(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(Chars[Random.Shared.Next(Chars.Length)]);
            }
            return $"GCT_{result}";
        }
    }
}
