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

    #endregion

    public void Awake()
    {
        life = maxLife;
    }
    public void Start()
    {
        EventManager.Subscribe("AddLife", AddLifeFunc);
        EventManager.Subscribe("SubtractLife", SubtractLifeFunc);
        EventManager.Subscribe("ResetLife", ResetLifeFunc);
    }
    public void AddLifeFunc(params object[] parameters)
    {
        life += (int)parameters[0];
        if (life > maxLife)
            life = maxLife;
        
    }

    public void ResetLifeFunc(params object[] parameters)
    {
        life = maxLife;
    }


    public void SubtractLifeFunc(params object[] parameters)
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
        EventManager.Trigger("GameOver");
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
