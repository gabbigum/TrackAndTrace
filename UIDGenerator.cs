using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Utilities
{
    public class UIDGenerator
    {
        
        private static UIDGenerator instance;
        public int UniqueUserID { get; set; } = 400;
        public int UniqueLocationID { get; set; } = 400;

        private UIDGenerator()
        {

        }

        public static UIDGenerator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UIDGenerator();
                }
                return instance;
            }

        }

        public int nextUniqueUserID()
        {
            return UniqueUserID += 1;
        }

        public int nextUniqueLocationID()
        {
            return UniqueLocationID += 1;
        }
    }
}
