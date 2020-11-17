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
        public int UniqueID { get; private set; }

        private UIDGenerator()
        {
            UniqueID = 1;
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

        public int nextUniqueID()
        {
            return UniqueID += 1;
        }
    }
}
