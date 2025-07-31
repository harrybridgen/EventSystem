public class Program {
    static void Main(String[] args) {
        someAbstractEvent myEvent = new someEvent();
        myEvent.trigger(1);
        //should print "triggered someEvent"

        someListenerInterface listener1 = new someListener1();
        myEvent.registerListener(listener1);
        myEvent.trigger(2);
        //should print "triggered someEvent"
        //should print "Hello from listener1. Data is: 2"

        someListenerInterface listener2 = new someListener2();
        myEvent.registerListener(listener2);
        myEvent.trigger(3);
        //should print "triggered someEvent"
        //should print "Hello from listener1. Data is: 3"
        //should print "Hello from listener2. Data is: 3"
    }
}

public abstract class someAbstractEvent {
    private List<someListenerInterface> listeners = new List<someListenerInterface>();
    public List<someListenerInterface> getListeners() {
        return listeners;
    }

    public void registerListener(someListenerInterface theListener) {
        listeners.Add(theListener);
    }

    public virtual void trigger(int data) {
        foreach (var listener in listeners) {
            listener.onEvent(data);
        }
    }
}

public class someEvent : someAbstractEvent {
    public override void trigger(int data) {
        Console.WriteLine("triggered someEvent");
        base.trigger(data);
    }
}


public interface someListenerInterface {
    public void onEvent(int data);
}

public class someListener1 : someListenerInterface {

    public void onEvent(int data) {
        Console.WriteLine("Hello from listener1. Data is: " + data);
    }
}

public class someListener2 : someListenerInterface {

    public void onEvent(int data) {
        Console.WriteLine("Hello from listener2. Data is: " + data);
    }
}
