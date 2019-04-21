﻿ using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorqueMove : MonoBehaviour
{
    public float torquespeed = 50f;
    [SerializeField] float m_movementSpeed = 100f;
    [SerializeField] float m_jumpSpeed = 10f;

    Rigidbody2D playerone;


    // Use this for initialization
    void Start ()
    {
        playerone = gameObject.GetComponent<Rigidbody2D>();

        if (playerone == null)
        {

            Debug.Log("No RigidBody found in PhysicalMovementController");
        }
    }

    // Because Add Torque uses Physics -> Fixed Update instead update
    /*void FixedUpdate ()
    {
        //AddTorque is used like Rigidbody.AddTorque(vector,ForceMode)

        playerone.AddTorque(torquespeed, ForceMode2D.Force);

    }*/

    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");


        Vector2 movementForce = new Vector2();

        movementForce.x = horizontalMovement * m_movementSpeed * Time.deltaTime;
        movementForce.y = verticalMovement * m_movementSpeed * Time.deltaTime;

        //Movement Force is not a float -> Cannot convert? Error gone, why dunno xD
        playerone.AddTorque(movementForce.x, ForceMode2D.Force);
        playerone.AddTorque(movementForce.y, ForceMode2D.Force);

        if (Input.GetButton("Jump"))
        {
            playerone.AddForce(Vector2.up, ForceMode2D.Impulse);

           // movementForce.y = m_jumpSpeed * Time.deltaTime;
        }
    }
}