using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    PlayerMovement playerMovement;

    private void Update()
    {
        float tileWidth = 10f; // replace this with the actual tile width
        float xPosition = Mathf.Sin(Time.time * speed) * tileWidth / 2;
        transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
    }

    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.Die();
        }
        else if (collision.gameObject.GetComponent<Shield>() != null)
        {
            Destroy(gameObject);
        }
    }
}
