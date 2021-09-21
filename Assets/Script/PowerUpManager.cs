using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    private void Start()
    {
        EventManager.Subscribe("FasterPowerUp", Faster);
    }
    void Faster(params object[] parameters)
    {
        SoundManager.instance.Play(SoundManager.Types.PowerUp);
    }
}
