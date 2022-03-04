using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ItemWeapon 
{
        public Weapons.Types gunType;

        public Sprite image;

        public RewardType rewardType;

        public Weapon weaponData;

        public int id;

        //   public int price;

}


[System.Serializable]
public class WeaponsWon
{
        public List<ItemWeapon> list;
        public string ToJson()
        {
                return JsonUtility.ToJson(this);
        }
        public static UserDetails FromJson(string jsonData)
        {
                return JsonUtility.FromJson<UserDetails>(jsonData);
        }
}
