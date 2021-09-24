using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public GameObject heartObj;

    [SerializeField]
    private ParticleSystem _slowParticles;
    //private int _counter = 1;
    [SerializeField]
    private int _addLife = 10;

    void OnTriggerEnter(Collider trig)
    {
        //Check to see if the Collider's name is "Chest"
        if (trig.tag == "Player")
        {
            SoundManager.instance.Play(SoundManager.Types.ExtraLife);
            heartObj.SetActive(false);
            Instantiate(_slowParticles, transform.position, transform.rotation);
            EventManager.Trigger("AddLife", _addLife);
        }
    }
}
