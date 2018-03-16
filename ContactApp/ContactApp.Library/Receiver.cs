

using static ContactApp.Library.Broadcaster;

namespace ContactApp.Library
{
    public class Receiver
    {
        //Broadcaster is actually making things happen, Receiver is listening
        public void Receiving(Broadcaster b)
        {
            b.EventFire += () => {System.Console.WriteLine("I am listening...");};  // You are listening to b.EventFire specifically
            b.EventFire += Listening;  // You are listening to b.EventFire specifically, += add one listener per event
            b.EventFire -= Listening;  // Removes you from that event
            b.Event2 += () => {};
        }

        private void Listening()  //delegate almost like referene
        {
            System.Console.WriteLine("I am listening...");
        }
    }
}