using System;
using System.Collections.Generic;
using UnityEngine;

public static class EventBus
{
    public static List<CustomEvent> events = new List<CustomEvent>(); //all events get added here the minute they come into existence
    
    //util
    public static CustomEvent RequestEvent(string eventName)
    {
        foreach (var item in events)
        {
            if(item.name == eventName) return item;
        }
        return null;
    }
    
    public static CustomEvent RequestEvent(string eventName, bool createIfNone)
    {
        foreach (var item in events)
        {
            if(item.name == eventName) return item;
        }
        CustomEvent newEvent = new CustomEvent(eventName);
        return newEvent;
    }
}
