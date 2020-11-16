using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAndTrace
{
    class UIDGenerator
    {
        private static readonly Random random = new Random();
        public static String generateID(int size)
        {
            StringBuilder builder = new StringBuilder(size);

            // offset is a single Unicode character  
            char offset = 'A';
            const int lettersOffset = 26; // A...Z or a..z: length=26  

            for (int i = 0; i < size; i++)
            {
                char randomChar = (char)random.Next(offset, offset + lettersOffset);
                builder.Append(randomChar);
            }

            return builder.ToString();
        }
    }
}
