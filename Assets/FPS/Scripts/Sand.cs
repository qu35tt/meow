using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sand : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        var player = collision.gameObject.GetComponentInParent<PlayerController>();
        if(player != null)
        {
            player.speedChange(0.5f);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        var player = collision.gameObject.GetComponentInParent<PlayerController>();
        if(player != null)
        {
            player.speedChange(2f);
        }
    }
}
