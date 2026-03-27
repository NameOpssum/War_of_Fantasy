using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement_Script : MonoBehaviour
{
    [SerializeField] float Velocity = 6f;

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
    }
}
