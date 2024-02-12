using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katapult : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        var player = collision.gameObject.GetComponentInParent<PlayerController>();
        if (player != null)
        {
          player.GetComponent<Rigidbody>().AddForce(Vector3.up * 10, ForceMode.Impulse);   
        }
    }

}
