using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Gacha : MonoBehaviour
{
   //public CharacterType obtainedCharacter;
   public TextMeshProUGUI _diamonds;
   public TextMeshProUGUI _rollCost;
   [SerializeField] private GameObject _freeDiamonds;
   
   public int remainingCurrency;
   
   public int costPerRoll;
   
   public int pityForGuaranteedRare;
   
   private int[] _rarityChance = {3,3,34,100 };

   private int _rollResult;
   
   private int _pityCounter;
   public enum CharacterType
   {
      FiveStarFocus,
      FiveStar,
      FourStar,
      ThreeStar
   }

   private void Start()
   {
      _freeDiamonds.SetActive(false);
      _rollCost.text = costPerRoll.ToString();
   }

   private void Update()
   {
      _diamonds.text = remainingCurrency.ToString();
   }

   public bool Roll(out CharacterType obtainedCharacter)
   {
      if (remainingCurrency >= costPerRoll)
      {
         remainingCurrency -= costPerRoll;
         
         _rollResult = Random.Range(0, 101);

         for (int i = 0; i < _rarityChance.Length; i++)
         {
            if (_rollResult < _rarityChance[i])  //si quiero agregar mayor probabilidad ya sea por fecha especial etc, multiplico el rarityChance[i] * algo. Tengo mayores chances si lo multiplico. Puedo usar una variable y que default sea 1.
            {
               obtainedCharacter = (CharacterType)i;
               
               if (obtainedCharacter != CharacterType.FiveStarFocus)
               {
                  _pityCounter++;
                  
                  if (_pityCounter >= pityForGuaranteedRare)
                  {
                     obtainedCharacter = CharacterType.FiveStarFocus;
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
         
         obtainedCharacter = CharacterType.ThreeStar;
         return false;

      }
      else
      {
         obtainedCharacter = CharacterType.ThreeStar;
         return false;
      }
   }

   public void BTN_Roll()
   {
      CharacterType obtained;
      if (Roll(out obtained))
      {
         Debug.Log("Conseguiste: " + obtained);
      }
      else
      {
         _freeDiamonds.SetActive(true);
         _rollCost.color = Color.red;
      }
   }
   
}
