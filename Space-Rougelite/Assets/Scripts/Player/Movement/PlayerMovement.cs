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
        PlayerStats.speed = speed;
    }
    // Update is called once per frame
    void Update()
    {
        speed = PlayerStats.speed * PlayerStats.speedMult;
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        if ((Input.mousePosition.x - Screen.width / 2) <0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            gameObject.transform.rotation = Quaternion.identity;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2 (hInput*speed, vInput*speed);
    }
}
