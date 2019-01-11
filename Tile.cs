using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CQMEditor
{
    public class Tile
    {
        private string name = string.Empty;
        private string filename = string.Empty;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Filename
        {
            get
            {
                return filename;
            }
            set
            {
                filename = value;
            }
        }
        public Tile()
        {
        }
        public Tile(string theName, string theFilename)
        {
            Name = theName;
            Filename = theFilename;
        }
    }
}
