using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particles;

    private void Start()
    {
        particles.Stop();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 50f);

        particles.Play();
        foreach (Collider hitCollider in colliders)
        {
            var obj = hitCollider.GetComponent<IDamagable>();
            if (obj != null)
            {
                obj.TakeDamage(100);
            }
        }
    }
}
