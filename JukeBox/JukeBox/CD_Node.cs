using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JukeBox
{
    class CD_Node
    {
        private string artist;
        private string album;
        private double duration;
        private int tracks;
        private CD_Node previous;

        public String Artist
        {
            get
            {
                return artist;
            }
            set
            {
                artist = value;
            }
        }

        public String Album
        {
            get
            {
                return album;
            }
            set
            {
                album = value;
            }
        }
        public Double Duration
        {
            get
            {
                return duration;
            }
            set
            {
                duration = value;
            }
        }
        public int Tracks
        {
            get
            {
                return tracks;
            }
            set
            {
                tracks= value;
            }
        }
        public CD_Node Prev
        {
            get
            {
                return previous;
            }
            set
            {
                previous = value;
            }
        }
    }
}
