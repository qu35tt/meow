using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colt : RangedWeapon
{
    protected override void Start()
    {
        base.Start();
        PlayerInputAction= Input.GetButtonDown;
    }
}
