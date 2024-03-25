using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] float torqueAmount = 5f;
    [SerializeField] float boostSpeed = 25f;
    [SerializeField] float baseSpeed = 10f;
    SurfaceEffector2D se2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        se2d = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        RespondToBoost();
    }

    public void DisableControls()
    {
        
    }

    //Give the player additional speed if they have the uparrow pressed
    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            se2d.speed = boostSpeed;
        }
        else
        {
            se2d.speed = baseSpeed;
        }
    }

    //Rotate the player by the given torque. Applies best while in the air
    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }
}
