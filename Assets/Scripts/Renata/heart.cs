using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart : MonoBehaviour
{
    public GameObject heartObj;
    //private int _counter = 1;
    [SerializeField]
    private int _addLife = 20;

    void OnTriggerEnter(Collider trig)
    {
        var damageable = trig.GetComponent<IDamageable>();
        if (damageable != null)
        {
            SoundManager.instance.Play(SoundManager.Types.ExtraLife);
            heartObj.SetActive(false);
            damageable.AddLifeFunc(_addLife);
        }

    }
}
