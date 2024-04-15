using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingSpike : MonoBehaviour
{
    public float swingForce = 100f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.AddTorque(swingForce);
    }

}
