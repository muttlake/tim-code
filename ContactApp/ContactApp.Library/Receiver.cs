

using System;
using static ContactApp.Library.Broadcaster;

namespace ContactApp.Library
{
    public class Receiver
    {
        public void Receiving(Broadcaster b)
        {
            b.EventFire += () => {Console.WriteLine("EventFire event happenned");};
            b.EventFire += Listening;
            b.Event2 += () => {Console.WriteLine("Watching Waiting, Anticipating.  Event2");};
        }

        private void Listening()
        {
            Console.WriteLine("I am Listening.");
        }
    }
}