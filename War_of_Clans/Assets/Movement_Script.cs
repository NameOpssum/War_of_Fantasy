using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement_Script : MonoBehaviour
{
    [SerializeField] float Velocity = 6f;
    [SerializeField] float RunVelocity = 12f;

    Rigidbody rg;

    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = (transform.right * x + transform.forward * z).normalized;

        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? RunVelocity : Velocity;

        Vector3 velocity = move * currentSpeed;
        velocity.y = rg.velocity.y;

        rg.velocity = velocity;
    }
}
