using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New UIEventer", menuName = "UIEventer/Create new UIEventer", order = 51)]
public class UIEventer : ScriptableObject
{
    private Dictionary<string, Action<float>> _events = new Dictionary<string, Action<float>>();

    public void RegisterEvent(string name, Action<float> valueChanged)
    {
        if (!_events.ContainsKey(name))
        {
            _events[name] = valueChanged;
        }
        else
        {
            _events[name] += valueChanged;
        }
    }

    public void UnregisterEvent(string name, Action<float> valueChanged)
    {
        if (_events.ContainsKey(name))
        {
            _events[name] -= valueChanged;
        }
    }

    public void InvokeEvent(string name, float value) 
    { 
        if (_events.ContainsKey(name))
        {
            _events[name]?.Invoke(value);
        }
    }
}