using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{ 
    [Header("Player Atrributes")]
    public float maxLife;
    public float minLife;
    public float forwardSpeed;
    public float swipeSpeed;
    public ParticleSystem damageParticles;
    public Vector3 InitialPosition;
    public float life;
    Rigidbody _rb;
    Transform transform;
    public List<Vector3> _swipePoints = new List<Vector3>();
    public List<Weapon> weapons;
    
    

    [Header("Scripts")]
    public ManagerUI managerUI;
    public FasterPowerUp fasterPowerUp;
    //[SerializeField]private SetRewardsToGame _setRewardsToGame;
    
    private List<ItemWeapon> _weaponsWon = new List<ItemWeapon>();
    [SerializeField]private ItemWeapon[] _allWeapons;
    void Awake()
    {
        transform = GetComponent<Transform>();
        _rb = GetComponent<Rigidbody>();
        life = maxLife;
    }
    private void Start()
    {
        if (SaveRewardJson.instance.weaponsGained.list.ToList().Count == 2)
        {
            SaveRewardJson.instance.Save();
        }
        //SaveRewardJson.instance.Load();
        _weaponsWon = SaveRewardJson.instance.weaponsGained.list.ToList();
        foreach (var i in _weaponsWon)
        {
            ItemWeapon r = Array.Find(_allWeapons, weapon => weapon.id ==i.id);
            //if (r.weaponData.I == null) return;
            
            weapons.Add(r.weaponData);
        }
        
        
        //if (_setRewardsToGame == null) return;
       // foreach (var weapon in _setRewardsToGame.weaponsInGame)
       // {
          //  weapons.Add(weapon.weaponData);
        //}
    }
}
