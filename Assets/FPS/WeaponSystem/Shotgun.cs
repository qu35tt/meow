using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : RangedWeapon
{
    [SerializeField]
    protected int bulletCount = 5;

    [SerializeField]
    protected float spread = 0.2f;

    protected override void Shoot()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            var bullet = Instantiate(BulletPrefab, BulletSpawn.position, BulletSpawn.rotation);
            bullet.transform.Rotate(Random.Range(-spread, spread), Random.Range(-spread, spread), Random.Range(-spread, spread));
            bullet.AddForce(bullet.transform.forward * 100, ForceMode.Impulse);
            Destroy(bullet.gameObject, 4f);
        }
    }

    protected override void Start()
    {
        base.Start();
        PlayerInputAction = Input.GetButtonDown;
    }
}
