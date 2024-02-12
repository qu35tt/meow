using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, IDamagable
{
    [SerializeField]
    private int MaxHP;
    private int hp;

    public int Hp { 
        get { return hp; }
        set { hp = value; }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int dmg)
    {
        Hp -= dmg;
        if (hp <= 0)
            Die();
    }

    void Start()
    {
        Hp = MaxHP;
    }
}
