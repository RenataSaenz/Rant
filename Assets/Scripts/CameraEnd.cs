using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEnd : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Camera End");
        EventManager.Trigger("GameOver");
        
    }
}
