using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour, ICollectable
{
  public void Collect()
  {
    GemsContoller.SumGems(1);
    gameObject.SetActive(false);
    SoundManager.instance.Play(SoundManager.Types.Victory);
  }
}
