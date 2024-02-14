using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shield : MonoBehaviour
{
    PlayerMovement playerMovement;
    public Material transparentMaterial; // Showing the shield
    public Material fadeMaterial; //not showing the shield
    Material newMaterial;
    private void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {         
        newMaterial = fadeMaterial;
        GetComponent<Renderer>().material = newMaterial;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>())
        {
            playerMovement.ShieldDown();
        }
        if (other.gameObject.GetComponent<Enemy>())
        {
            playerMovement.ShieldDown();
        }
    }
    
}