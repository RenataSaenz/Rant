using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyGems : MonoBehaviour
{
    [SerializeField]private int _gemsBought;
    
    public void OnClick()
    {
        GemsContoller.SumGems(_gemsBought);
    }
}
