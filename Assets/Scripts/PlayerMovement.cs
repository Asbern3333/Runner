using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;
    public float speed = 10;
    public int Shield = 0;
    public int life = 1;
    [SerializeField] Rigidbody rb;
    int currentLaneIndex = 1;
    bool isChangingLane = false;

    float horizontalInput;
    float verticalInput;

    float[] lanes = new float[] { -3f, 0f, 3f };
    [SerializeField] float laneChangeSpeed = 10f;
    //[SerializeField] float jumpForce = 500;
    [SerializeField] LayerMask groundMask;
    public float speedIncreasePerPoint = 0.1f;
    
    [SerializeField] GameObject shieldPrefab;


    void Start()
    {
        //Get child shield and set to false
        shieldPrefab = transform.GetChild(0).gameObject;
        shieldPrefab.SetActive(false);
    }


    private void FixedUpdate()
    {
        if (!alive) return;

        Vector3 forwardMove = transform.forward * speed;

        Vector3 targetPosition = new Vector3(lanes[currentLaneIndex], transform.position.y, transform.position.z);
        Vector3 newPosition = Vector3.MoveTowards(transform.position, targetPosition, laneChangeSpeed * Time.fixedDeltaTime);
        rb.MovePosition(newPosition);

        if (Mathf.Abs(rb.velocity.y) < 0.001f)
        { // Only update vertical velocity when player is not jumping
            rb.velocity = new Vector3(rb.velocity.x, 0, forwardMove.z);
        }
        
        Vector3 temp = this.transform.position;
        temp.y = 1;
        this.transform.position = temp;
    }

    private void Update()
    {
        // Handle lane changing input
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (!isChangingLane)
        {
            if (horizontalInput < 0 && currentLaneIndex > 0)
            {
                StartLaneChange(currentLaneIndex - 1);
                isChangingLane = true;
            }
            else if (horizontalInput > 0 && currentLaneIndex < lanes.Length - 1)
            {
                StartLaneChange(currentLaneIndex + 1);
                isChangingLane = true;
            }

        }
        else if (Mathf.Approximately(horizontalInput, 0))
        {
            isChangingLane = false;
        }

        if (transform.position.y < -5)
        {
            Die();
        }

        GameManager.inst.IncShield();
    }
    public void Die()
    {
        alive = false;
        // Restart the game
        Invoke("Restart", 1);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        shieldPrefab.SetActive(false);
    }


    private void StartLaneChange(int newLaneIndex)
    {
        if (newLaneIndex < 0)
            newLaneIndex = lanes.Length - 1;
        else if (newLaneIndex >= lanes.Length)
            newLaneIndex = 0;

        currentLaneIndex = newLaneIndex;
    }

    private void FinishLaneChange()
    {
        isChangingLane = false;
    } 

    public void ShieldUp()
    {
        if (!shieldPrefab.activeSelf)
        {
            shieldPrefab = transform.GetChild(0).gameObject;
            shieldPrefab.SetActive(true);
        }

        if (Shield <= 1)
        {
            Shield++;
        }
        else if (Shield > 1 && Shield < 4)
        {
            if (shieldPrefab.activeSelf)
            {
                Shield++;
            }
        }
        else
        {
            Shield = 3;
        }
    }

    public void ShieldDown()
    {
        shieldPrefab = transform.GetChild(0).gameObject;
        if (Shield > 0)
        {
            Shield--;
            
            if (Shield == 0)
            {
                shieldPrefab.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ShieldToken>()) {
            ShieldUp();
        }
    }  
}