using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public bool birdIsAlive = true;
    public LogicScript logic;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive) { 
            myRigidbody.velocity = Vector2.up * flapStrength;   
        }

        if (transform.position.y < -16 || transform.position.y > 15) {
            logic.gameOver();
            birdIsAlive = false;
        }
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        logic.gameOver();
        birdIsAlive = false;
    }
}