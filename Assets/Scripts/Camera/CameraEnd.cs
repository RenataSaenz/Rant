using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEnd : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        var damageable = col.collider.GetComponent<IDamageable>();
        if (damageable != null)
        {
           Debug.Log("Camera End");
           EventManager.Trigger("GameOver"); 
        }
    }
}
