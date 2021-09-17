using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    #region Variables

    //[System.NonSerialized]
    public float life;

    public float maxLife;
    public float minLife;
    public float dieTimer = 3;

    #endregion

    public void Awake()
    {
        life = maxLife;
    }
    public void Start()
    {
        EventManager.Subscribe("AddLife", AddLife);
        EventManager.Subscribe("SubtractLife", SubtractLife1);
        EventManager.Subscribe("ResetLife", ResetLife);
    }
    public void AddLife(params object[] parameters)
    {
        life += (int)parameters[0];
        if (life > maxLife)
            life = maxLife;
        
    }

    public void ResetLife(params object[] parameters)
    {
        life = maxLife;
    }


    public void SubtractLife1(params object[] parameters)
    {
        life -= (int)parameters[0];
        SoundManager.instance.Play(SoundManager.Types.Damage);
        if (life < minLife)
        {
            Dead();
        } 
    }

    public void Dead()
    {
        EventManager.Trigger("GameOver", dieTimer);
        SoundManager.instance.Play(SoundManager.Types.Dead);
        life = minLife;
    }

    /// <summary>
    /// metodo para devolver los puntos acumulados
    /// </summary>
    /// <returns></returns>
    public float ReturnLife()
    {
        return life;
    }
}
