

using System;

namespace ContactApp.Library
{
    public class Broadcaster
    {

        public delegate void Notifier();
        public event Notifier EventFire;  //When broadcast happens it kicks off EventFire
                                          //Content of EventFire is of type delegate Notifier
                                          //which is a method that contains nothing

        public delegate bool StartBroadcast();
        public event StartBroadcast StartIt;


        public event Notifier Event2;

        public void Broadcast()
        {
            for(;;)
            {
                Console.WriteLine("Enter BEGIN to begin Broadcast.");
                if("BEGIN" == Console.ReadLine())
                {
                    StartIt();
                    break;
                }
            }

            var count = 0;
            while (count <= 10)
            {
                if (EventFire != null) // We don't send broadcast if there are no Receivers
                    EventFire();  //just like click or typing event
                if (Event2 != null)
                    Event2();
                count += 1;
            }
        }
    }
}