using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    Weapon CurrentWeapon;

    [SerializeField]
    GameObject ReloadCrosshair;
    [SerializeField]
    UnityEngine.UI.Image reloadImage;

    [SerializeField]
    GameObject NormalCrosshair;

    [SerializeField]
    GameObject grenadePrefab;
    [SerializeField]
    Transform throwPoint;
    public float throwForce = 10f;

    List<Weapon> weapons;

    private void ChangeWeapon(Weapon newWeapon)
    {
        if (CurrentWeapon != null)
        {
            if (CurrentWeapon.GetReloadProgress() > 0)
            {
                CurrentWeapon.ResetReloadProgress();
            }
            CurrentWeapon.IsPossibleToAttackChanged -= OnIsPossibleToAttackChanged;
            CurrentWeapon.gameObject.SetActive(false);
        }

        CurrentWeapon = newWeapon;
        CurrentWeapon.gameObject.SetActive(true);
        CurrentWeapon.IsPossibleToAttackChanged += OnIsPossibleToAttackChanged;
        OnIsPossibleToAttackChanged(CurrentWeapon.GetReloadProgress() > 0);
    }

    private void OnIsPossibleToAttackChanged(bool isPossibleToAttack)
    {
        NormalCrosshair.SetActive(isPossibleToAttack);
        ReloadCrosshair.SetActive(!isPossibleToAttack);
    }

    void Start()
    {
        weapons = GetComponentsInChildren<Weapon>(true).ToList();
        ChangeWeapon(weapons.First());
    }

    void Update()
    {
        if (CurrentWeapon.PlayerInputAction("Fire1"))
        {
            CurrentWeapon.Attack();
        }

        if (!CurrentWeapon.IsPossibleToAttack())
        {
            reloadImage.fillAmount = CurrentWeapon.GetReloadProgress();
        }

        if (CurrentWeapon.PlayerInputAction("Grenade"))
        {
            GameObject grenade = Instantiate(grenadePrefab, throwPoint.position, throwPoint.rotation);
            Rigidbody grenadeRb = grenade.GetComponent<Rigidbody>();
            grenadeRb.AddForce(throwPoint.forward * throwForce, ForceMode.Impulse);
            grenadeRb.AddForce(throwPoint.up * 5, ForceMode.Impulse);
        }

        WeaponSwitch();
    }

    private void WeaponSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeWeapon(weapons.ElementAt(0));
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeWeapon(weapons.ElementAt(1));
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeWeapon(weapons.ElementAt(2));
        }
    }
}