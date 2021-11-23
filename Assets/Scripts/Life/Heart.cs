using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public GameObject heartObj;

    [SerializeField]
    private ParticleSystem _particles;
    [SerializeField]
    private int _addLife = 10;

    void OnTriggerEnter(Collider trig)
    {
        var damageable = trig.GetComponent<IDamageable>();
        if (damageable != null)
        {
            SoundManager.instance.Play(SoundManager.Types.ExtraLife);
            heartObj.SetActive(false);
            Instantiate(_particles, transform.position, transform.rotation);
            damageable.AddLifeFunc(_addLife);
        }
    }
}
