using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetEventManager : MonoBehaviour
{
    private void Awake()
    {
        EventManager.Reset();
    }
}

