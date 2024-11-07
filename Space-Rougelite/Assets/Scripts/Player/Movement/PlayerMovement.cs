using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    private float hInput;
    private float vInput;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2 (hInput*speed, vInput*speed);
    }
}
