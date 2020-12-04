using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankObservable : MonoBehaviour {

	// h ttps://www.habrador.com/tutorials/programming-patterns/3-observer-pattern/
	List<SimObserver> observers = new List<SimObserver>(); 

    public void Start(){
         observers = new List<SimObserver>();
    }

    //Send notifications if something has happened
    public void Notify(string message)
    {
        for (int i = 0; i < observers.Count; i++)
        {
            // Notify all observers even though some may not be interested in what has happened
            // Each observer should check if it is interested in this event
            observers[i].OnNotify(message);
        }
    }

    //Add observer to the list
    public void AddObserver(SimObserver observer)
    {
        observers.Add(observer);
    }
}
