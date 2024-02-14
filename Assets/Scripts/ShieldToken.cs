using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldToken : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>())
        {
            Destroy(gameObject);
        }
        if (other.gameObject.GetComponent<Shield>())
        {
            Destroy(gameObject);
        }
    }
}
