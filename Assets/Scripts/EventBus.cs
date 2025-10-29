using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EventBus
{
    Dictionary<Type, Delegate> busSchedule = new Dictionary<Type, Delegate> ();

    public void Raise<T>(T eventObject) where T : IEvent //Takes a generic object where the object inherits type IEvent, knows concrete type at compiler
    {
        if (busSchedule.TryGetValue(typeof(T), out Delegate delegates)) //Checks if an Event that is the same type of eventObject is listed in busSchedule
        {
            Action<T> action = delegates as Action<T>; //Cast it as a Action with generic type, ensures action is the concrete type of <T> (which we know at compiler time)
            action?.Invoke(eventObject); //Invoke it
        }
    }

    public void Subscribe<T>(Action<T> action) where T : IEvent
    {
        if(busSchedule.TryGetValue(typeof(T), out Delegate delegates))
        {
            busSchedule[typeof(T)] = Delegate.Combine(delegates, action);
        }
        else
        {
            busSchedule.Add(typeof(T), action);
        }
    }

    public void Unsubscribe<T>(Action<T> action) where T: IEvent
    {
        if (!busSchedule.TryGetValue(typeof(T), out Delegate delegates))
        {
            Debug.LogWarning("EventBus_Unsubscribe_Trying to remove nonexistant schedule");
            return;
        }

        Delegate newDelegates = Delegate.Remove(delegates, action);
        if(newDelegates != null)
            busSchedule[typeof(T)] = newDelegates;
    }

    public Dictionary<Type, string> GetAllSubscriptions()
    {
        Dictionary<Type, string> delegateSubscriptions = new Dictionary<Type, string>();
        foreach (KeyValuePair<Type, Delegate> type_delegate in busSchedule)
        {
            if (delegateSubscriptions.ContainsKey(type_delegate.Key))
                delegateSubscriptions[type_delegate.Key] += $"\n{type_delegate.Value.Target}.{type_delegate.Value.Method}";
            else
                delegateSubscriptions.Add(type_delegate.Key, $"{type_delegate.Value.Target}.{type_delegate.Value.Method}");
        }
        return delegateSubscriptions;
    }
    public List<string> GetSubscriptionUnderNamespace(string name_space)
    {
        List<string> subscriptionsUnderNamespace = new List<string>();
        foreach(KeyValuePair<Type, Delegate> type_delegate in busSchedule)
        {
            if(type_delegate.Key.Namespace == name_space)
            {
                foreach(Delegate del in type_delegate.Value.GetInvocationList())
                {
                    subscriptionsUnderNamespace.Add($"{del.Target}.{del.Method}");
                }
            }
        }
        return subscriptionsUnderNamespace;
    }
}