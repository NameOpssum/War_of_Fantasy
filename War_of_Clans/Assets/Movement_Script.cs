using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Script : MonoBehaviour
{
    [SerializeField] float Velocity = 6f;
    [SerializeField] float JumpForce = 7f;

    Rigidbody rg;

    bool isGround;

    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Tasti

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        // movimento
        Vector3 velocity = new Vector3(move.x * Velocity, rg.velocity.y, move.z * Velocity);
        rg.velocity = velocity;

        // saltoo
        if(Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rg.velocity = new Vector3(rg.velocity.x, JumpForce, rg.velocity.z);
        }
    }

    private void InCollisione(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }

    private void NonInCollisione(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }
}
