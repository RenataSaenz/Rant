using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public static void TurnOff(Food food)
    {
        food.gameObject.SetActive(false);
    }

    public static void TurnOn(Food food)
    {
        food.gameObject.SetActive(true);
    }

}
