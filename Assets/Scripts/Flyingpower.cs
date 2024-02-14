using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Flyingpower : MonoBehaviour
{

    /*public GameObject firstModel;
    public GameObject secondModel;
    private GameObject currentModel;
    */
    private int count=0;
    public float desiredYPosition = 7f;
   
    PlayerMovement playerMovement;
    void Start()
    {
     //   SwitchModel(firstModel);
    }

    // Update is called once per frame
    void Update()
    {

        // Check if the player is holding down the key "1".
        if (Input.GetKey(KeyCode.Space)&& GameManager.inst.score>0)
        {
          //  Start1();
           // ToggleModels();
            //every amount of time it decrese the money
            count +=50;
            if (count>1000)
            {
                GameManager.inst.DecrementScore();
                count = 0;
            }
            
            transform.position = new Vector3(transform.position.x, desiredYPosition, transform.position.z);
            Debug.Log(transform.position.x);
            if (Input.GetKeyDown(KeyCode.A)&& transform.position.x>=-3)
            {
                
                transform.position = new Vector3(transform.position.x-3f, desiredYPosition, transform.position.z);
            }
            if (Input.GetKeyDown(KeyCode.D) && transform.position.x <= 3)
            {
               
                transform.position = new Vector3(transform.position.x + 3f, desiredYPosition, transform.position.z);
            }
        }
    }
    /*void ToggleModels()
    {
        // Check the current model and switch to the other one
        if (currentModel == firstModel)
        {
            SwitchModel(secondModel);
        }
        else
        {
            SwitchModel(firstModel);
        }
    }

    void SwitchModel(GameObject newModel)
    {
        // Disable the current model
        if (currentModel != null)
        {
            currentModel.SetActive(false);
        }

        // Enable the new model
        newModel.SetActive(true);

        // Update the current model reference
        currentModel = newModel;
    }

    */

}
