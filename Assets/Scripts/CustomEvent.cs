using System;
using UnityEngine;


public class CustomEvent
{
    public CustomEvent(string name)
    {
        EventName = name;
    }

    public string EventName {get ; private set;}
    public event Action ping;

    public void Invoke()
    {
        ping?.Invoke();
    }
}
