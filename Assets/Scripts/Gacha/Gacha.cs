using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Gacha : MonoBehaviour
{
   //public GunType obtainedGun;
   public TextMeshProUGUI _diamonds;
   public TextMeshProUGUI _rollCost;
   [SerializeField] private GameObject _freeDiamonds;
   
   public int costPerRoll;
   
   public int pityForGuaranteedRare;
   
   private int[] _rarityChance = {3,3,34,100 };

   private int _rollResult;
   
   private int _pityCounter;


   [SerializeField] private ItemWeapon[] rewards;
   
   [SerializeField] private Image _chest;
   [SerializeField] private GameObject _rewardGameObject;
   
   private List<ItemWeapon> _weaponsWon = new List<ItemWeapon>();
   
   private void Start()
   {
      _rewardGameObject.SetActive(false);
      _freeDiamonds.SetActive(false);
      _rollCost.text = costPerRoll.ToString();

      // SaveRewardJson.instance.weaponsGained.list.Add(new ItemWeapon{id = 5});
      // SaveRewardJson.instance.weaponsGained.list.Add(new ItemWeapon{id = 6});
      // SaveRewardJson.instance.Save();
   }

   private void Update()
   {
      _diamonds.text = GemsContoller.totalGems.ToString();
   }

   public bool Roll(out RewardType obtainedGun)
   {
      if (GemsContoller.totalGems >= costPerRoll)
      {
         GemsContoller.SumGems(-costPerRoll);
         
         _rollResult = Random.Range(0, 101);

         for (int i = 0; i < _rarityChance.Length; i++)
         {
            if (_rollResult < _rarityChance[i])  //si quiero agregar mayor probabilidad ya sea por fecha especial etc, multiplico el rarityChance[i] * algo. Tengo mayores chances si lo multiplico. Puedo usar una variable y que default sea 1.
            {
               obtainedGun = (RewardType)i;
               
               if (obtainedGun != RewardType.FiveStarFocus)
               {
                  _pityCounter++;
                  
                  if (_pityCounter >= pityForGuaranteedRare)
                  {
                     obtainedGun =  RewardType.FiveStarFocus;
                     _pityCounter = 0;
                  }
               }
               else
                  _pityCounter = 0;

               return true;
            }
            else 
               _rollResult -= _rarityChance[i];
         }
         
         obtainedGun =  RewardType.ThreeStar;
         return false;

      }
      else
      {
         obtainedGun = RewardType.ThreeStar;
         return false;
      }
   }
   public void BTN_Roll()
   {
      _rewardGameObject.SetActive(false);
      RewardType obtained;
      if (Roll(out obtained))
      {
         _rewardGameObject.SetActive(true);
         SetReward(obtained);
         //AddRewardToGame(obtained);
         Debug.Log("Conseguiste: " + obtained);
      }
      else
      {
         _freeDiamonds.SetActive(true);
         _rollCost.color = Color.red;
      }
   }
   
   private void SetReward( RewardType obtained)
   {
      ItemWeapon r = Array.Find(rewards, reward => reward.rewardType == obtained);
      _chest.sprite = r.image;
      
      int IDGained = r.id;
      Debug.Log(IDGained.ToString());
      AddReward(IDGained);
      
      //SaveRewardJson.instance.weaponsGained.list.Add(new ItemWeapon{id = IDGained});
      //SaveRewardJson.instance.Save();
   }

   void AddReward(int IDGained)
   {
      //SaveRewardJson.instance.Load();
      
      _weaponsWon = SaveRewardJson.instance.weaponsGained.list.OrderByDescending(i => i.id).ToList();
      
      foreach (var i in _weaponsWon)
      {
         if (IDGained == i.id) return;
      }
      
      SaveRewardJson.instance.weaponsGained.list.Add(new ItemWeapon{id = IDGained});
      SaveRewardJson.instance.Save();
   }
   

  /* void SetSavedReward(Weapons.Types weapon)
   {
      if (ICanAddRewardToList(weapon))
      {
         string rewardsWon = PlayerPrefs.GetString("Rewards");
         
         if(rewardsWon == "")
            PlayerPrefs.SetString("Rewards", (int)weapon + "");
         else
            PlayerPrefs.SetString("Rewards", rewardsWon +  "/" + (int)weapon);  //solo rewards obtenidas
         
         
      }
   }

   bool ICanAddRewardToList(Weapons.Types weapon)
   {
      if (PlayerPrefs.GetString("Rewards") == "") return true;
      
      string[] rewardsWon = PlayerPrefs.GetString("Rewards").Split('/');

      for (int i = 0; i < rewardsWon.Length; i++)
      {
         if ((int) weapon == Convert.ToInt32(rewardsWon[i]))
            return false;
      }

      return true;
   }*/
}

public enum RewardType
{
   FiveStarFocus,
   FiveStar,
   FourStar,
   ThreeStar
}
