using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    public class CurlyBracketsEvents
    {
        // Invalid events.
        public event EventHandler InvalidEvent1
        {
            add { x += value; }

            remove
            {
            }
        }

        public event EventHandler InvalidEvent2
        {
            add
            {
                x += value;
            }

            remove { }
        }

        public event EventHandler InvalidEvent3
        {
            add {
                x += value; }

            remove {
                x -= value; }
        }

        public event EventHandler InvalidEvent4
        {
            add {
                x += value;
            }

            remove {
                x -= value;
            }
        }

        public event EventHandler InvalidEvent5
        {
            add
            {
                x += value; }

            remove
            {
                x -= value; }
        }

        public event EventHandler InvalidEvent6
        {
            add
            { x += value;
            }

            remove
            { x -= value;
            }
        }

        public event EventHandler InvalidEvent7
        {
            add
            { x += value; }

            remove 
            { x -= value; }
        }

        public event EventHandler InvalidEvent8 { add { x += value; } }

        public event EventHandler InvalidEvent9
        {
            add { x += value; } }

        public event EventHandler InvalidEvent10 {
            add { x += value; } }

        public event EventHandler InvalidEvent11 {
            add { x += value; }
        }

        public event EventHandler InvalidEvent12
        { add { x += value; }
        }

        public event EventHandler InvalidEvent13
        { add { x += value; } }

        // Valid events.
        public event EventHandler ValidEvent1
        {
            add { x += value; }
            remove { x -= value; }
        }
       
        public event EventHandler ValidEvent2
        {
            add
            {
                x += value;
            }

            remove
            {
                x -= value;
            }
        }

        // The following event is allowed to be all on a single line.
        public event EventHandler ValidEvent3 = (sender, e) => { };

        // Test that we can also handle multiple event declarations within a single event.
        public event EventHandler Event1;
        public event EventHandler Event2 = (sender, e) => { };
        public event EventHandler Event3, Event4;
        public event EventHandler Event5 = null, Event6;
        public event EventHandler Event7, Event8 = null;
        public event EventHandler Event9 = null, Event10 = null;
        public event EventHandler Event11 = (sender, e) => { }, Event12 = (sender, e) => { };

    }
}