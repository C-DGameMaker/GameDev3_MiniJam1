using System;
using UnityEngine;

[CreateAssetMenu(fileName = "CustomEvent", menuName = "Custom_Events/Event")]
public class CustomEvent : ScriptableObject
{
    public CustomEvent(string name)
    {
        EventName = name;
    }

    public string EventName {get ; private set;}
    public event Action ping;

    void Awake()
    {
        EventBus.events.Add(this); //adds itself to the event bus
    }
}
