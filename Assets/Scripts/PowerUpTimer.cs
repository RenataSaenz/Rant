using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpTimer : MonoBehaviour
{
    public float time = 1f;
    private void Start()
    {
        EventManager.Subscribe("FastPowerUp", Timer);
    }
    public void Timer(params object[] n1)
    {
        //var time = (float)n1[0];
        var powerUpValue = (float)n1[0];

        StartCoroutine(WaitForTime(time, powerUpValue));
    }
    IEnumerator WaitForTime(float time, float powerUpValue)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("Ends timer");
        EventManager.Trigger("EndPowerUp", -powerUpValue);
    }
}
