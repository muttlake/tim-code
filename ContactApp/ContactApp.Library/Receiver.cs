

using System;
using static ContactApp.Library.Broadcaster;

namespace ContactApp.Library
{
    public class Receiver
    {
        public void Receiving(Broadcaster b)
        {
            b.StartIt += () => {return true;};
            string message = MessageRequest();
            b.EventFire += () => {Console.WriteLine(message);};
            //b.EventFire += Listening;
            //b.Event2 += () => {Console.WriteLine("Watching Waiting, Anticipating.  Event2");};
        }

        private void Listening()
        {
            Console.WriteLine("I am Listening.");
        }

        private string MessageRequest()
        {
            Console.WriteLine("What Message do you want displayed when receiving event?");
            return Console.ReadLine();
        }
    }
}