using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class ButtonWeapon : MonoBehaviour
{
    public Image button;
    [SerializeField] private WeaponButton[] weaponButton;

    [SerializeField] private Weapon[] _weapons;

    private void Awake()
    {
        button.GetComponent<Image>();
    }
    private void FixedUpdate()
    {
         SetWeaponButton();
    }
    
    
    
    private void SetWeaponButton()
    {
        foreach (var weapon in _weapons)
        {
            if (weapon.gameObject.activeSelf)
            {
                WeaponButton w = Array.Find(weaponButton, wButton => wButton.weaponName == weapon.name);
                
                if (w == null)
                {
                    Debug.LogWarning("Weapon: " + weapon.name + " not found!");
                    return;
                }
                
                button.sprite = w.sprite;
            }
        }
    }
}

[System.Serializable]
public class WeaponButton
{
    public String weaponName;

    public Sprite sprite;
}
