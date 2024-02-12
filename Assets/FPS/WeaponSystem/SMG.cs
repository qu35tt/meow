using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMG : RangedWeapon
{
    protected override void Start()
    {
        base.Start();
        PlayerInputAction = Input.GetButton;
    }
}
