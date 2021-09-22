using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Pool<T>
{
    private List<T> _uninstantiated = new List<T>();
    private Func<T> _create;
    private Action<T> _turnOff;
    private Action<T> _turnOn;

    public Pool(Func<T> create, Action<T> turnOff, Action<T> turnOn, int amount)
    {
        _create = create;   //guardo el objeto para poder volver a instanciarlo

        _turnOff = turnOff;
        _turnOn = turnOn;

        for (var i = 0; i< amount; i++)
        {   var element = create();
            _uninstantiated.Add(element);
        }
    }
    
    public T Get() {
        T obj;

        if (_uninstantiated.Count > 0)
        {
            obj = _uninstantiated[0];
            _uninstantiated.RemoveAt(0);
        }
        else
        {
            obj = _create();
        }

        _turnOn(obj);
        return obj;
    }
     
    public void ReturnToPool(T obj)
    {
       // _uninstantiated.Add(_turnOff(obj));
        _uninstantiated.Add(obj);
        _turnOff(obj);
    }
}
