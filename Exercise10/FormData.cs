using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Labs
{
    [Serializable]
    public class FormData
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int XPos { get; set; }
        public int YPos { get; set; }
    }
}
