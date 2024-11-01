using UnityEngine;
using UnityEngine.Events;

public abstract class AbstractObserver : MonoBehaviour
{
    public event UnityAction Event;

    public void Invoke() => Event.Invoke(); 
}