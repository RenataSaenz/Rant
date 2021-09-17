using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEnd : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        EventManager.Trigger("GameOver");
    }
}
