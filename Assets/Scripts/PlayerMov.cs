using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    //https://github.com/Suedz01/Roll-a-Ball.git
    //Values
    public int speed;
    public int jumpForce;

    //Conditions
    private bool isGrounded;
    //Settings
    private Rigidbody rig;
    private Vector3 direction;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector3 (Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        direction.Normalize();
        
        
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
            isGrounded = true;
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 8)
            isGrounded = false;
    }
}