using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JukeBox
{
    class SpindleStack
    {
        private CD_Node top;
        private int size;
        private int capacity;

        public SpindleStack()
        {
            top = null;
            size = 0;
            capacity = 10;
        }

        public int getSize
        {
            get
            {
                return size;
            }
        }

        public int getCapacity
        {
            get
            {
                return capacity;
            }
        }

        private bool isEmpty()
        {
            //check to see if anything is in the stack
            if (top == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Push(CD_Node node)
        {
            //gets new node to point at the top 
            node.Prev = top;
            // the top is now the new node
            top = node;
            size++;
        }
        public String list()
        {
            //starts by checking if JukeBox isEmpty
            if (isEmpty())
            {
                return "stack is empty";
            }
            string output = "contents of stack\n";
            CD_Node current = top;
            //goes thorugh stack and displays info
            while (current != null)
            {
                output += "Artist: " + current.Artist +"       " + "Album Name: " + current.Album + "       " + "Duration: " + current.Duration + "       " + "Track: " + current.Tracks + "       " + "\n";

                // moves to next node and repeats above 
                current = current.Prev;
            }
            return output;
        }

        public CD_Node peek()
        {
            return top;
        }

        public CD_Node pop()
        {
            if (isEmpty())
            {
                return null;
            }
            else
            {   
                CD_Node removed = top;
                top = removed.Prev;
                size--;
                return removed;     
            }
           
        }
        public bool contains(String artist)
        {
            if (isEmpty())
            {
                return false;
            }
            else
            {
                string output = "Contents of Jukebox\n";
                CD_Node current = top;

                while (current != null)
                {
                    if (artist == current.Artist)
                    {
                        return true;
                    }
                    current = current.Prev;
                }
            }
            return false;
        }

        public bool search(String artist, int track)
        {
            if (isEmpty())
            {
               return false;
            }
           else
           {
               CD_Node current = top;

                while (current != null)
                {
                    if ((artist == current.Artist) && (track <= current.Tracks)) 
                    {
                        return true;
                    }
                    current = current.Prev;
                }
                return false;
            }
            
        }
        public bool isFull(int capacity)
        {
            if(size < capacity)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
