using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRewardsToGame : MonoBehaviour
{//esto en player
   public ItemWeapon[] weapons;  // siempre array con todas sus weapons
   public List<ItemWeapon> weaponsInGame;

   private void Start()
   {
      if (PlayerPrefs.GetString("Rewards") == "") return;
      
      string[] rewardsWon = PlayerPrefs.GetString("Rewards").Split('/');
      
      var numberReward = Convert.ToInt32(rewardsWon);
      
      for (int i = 0; i < rewardsWon.Length; i++)
      {
         
         ItemWeapon r = Array.Find(weapons, reward => reward.rewardType.ToString() == rewardsWon[i]);  //busco dentro de mi array de weapons la weapon con el mismo nombre guarda en player prefs
         weaponsInGame.Add(r);
      }
   }
}
