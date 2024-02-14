using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public int score;
    int numShields;
    public static GameManager inst;

    [SerializeField] Text scoreText;
    [SerializeField] Text numShieldsText;

    [SerializeField] PlayerMovement playerMovement;

    public void IncrementScore ()
    {
        score++;
        scoreText.text = "SCORE: " + score;

        // Increase the player's speed
        playerMovement.speed += playerMovement.speedIncreasePerPoint;
    }
    public void DecrementScore()
    {
        score=score -1;
        scoreText.text = "SCORE: " + score;

        // Increase the player's 
    }
    public void IncShield()
    {
        numShields = playerMovement.Shield;
        numShieldsText.text = "SHIELDS: " + numShields;
    }

    private void Awake ()
    {
        inst = this;
    }

    private void Start () {

	}

	private void Update () {
	
	}
}