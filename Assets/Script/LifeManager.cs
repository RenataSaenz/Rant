using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    #region Variables

    [System.NonSerialized]
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
        EventManager.Subscribe("AddLife", AddLife);
        EventManager.Subscribe("SubtractLife", SubtractLife);
        EventManager.Subscribe("ResetLife", ResetLife);
    }
    public void AddLife(params object[] n1)
    {
        life += (int)n1[0];
        if (life > maxLife)
            life = maxLife;
    }

    public void ResetLife(params object[] parameters)
    {
        life = maxLife;
    }


    public void SubtractLife(params object[] n1)
    {
        life -= (int)n1[0];
        SoundManager.instance.Play(SoundManager.Types.Damage);
        Debug.Log("life");
        if (life < minLife)
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
