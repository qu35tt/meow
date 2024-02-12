using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponentInParent<PlayerController>();
        if(player != null )
        {
            Destroy(gameObject);
        }
    }
}
