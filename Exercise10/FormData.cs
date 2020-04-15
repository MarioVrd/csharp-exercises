using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Labs
{
    [Serializable()]
    public class FormData : ISerializable
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int XPos { get; set; }
        public int YPos { get; set; }

        public FormData()
        {

        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Width", Width);
            info.AddValue("Height", Height);
            info.AddValue("xPos", XPos);
            info.AddValue("yPos", YPos);
        }

        public FormData(SerializationInfo info, StreamingContext context)
        {
            Width = (int)info.GetValue("Width", typeof(int));
            Height = (int)info.GetValue("Height", typeof(int));
            XPos = (int)info.GetValue("xPos", typeof(int)); 
            YPos = (int)info.GetValue("yPos", typeof(int));
        }
    }
}
