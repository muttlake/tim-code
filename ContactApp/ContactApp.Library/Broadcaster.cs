

 namespace ContactApp.Library
{
    public class Broadcaster
    {

        public delegate void Notifier();
        public event Notifier EventFire;  //When broadcast happens it kicks off EventFire
                                          //Content of EventFire is of type delegate Notifier
                                          //which is a method that contains nothing

        public event Notifier Event2;

        public void Broadcast()
        {
            var count = 0;
            while (count <= 10)
            {
                if (EventFire != null) // We don't send broadcast if there are no Receivers
                {
                    EventFire();  //just like click or typing event
                    count += 1;
                }
            }
        }


    }
}