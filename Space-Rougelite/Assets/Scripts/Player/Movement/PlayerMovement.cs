using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    private float hInput;
    private float vInput;

    public Animator animator;

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
        if (!PauseMenu.isPaused)
        {
            speed = PlayerStats.speed * PlayerStats.speedMult;
            hInput = Input.GetAxisRaw("Horizontal");
            vInput = Input.GetAxisRaw("Vertical");
            if ((Input.mousePosition.x - Screen.width / 2) < 0)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {

                gameObject.transform.rotation = Quaternion.identity;
            }
        }
    }

    void FixedUpdate()
    {
        if (!PauseMenu.isPaused)
        {
            rb.velocity = new Vector2(hInput, vInput).normalized * speed;
            if (hInput >= 0.01 || vInput >= 0.01 || hInput <= -0.01f || vInput <= -0.01f)
            {
                animator.SetFloat("speed", 0.1f);
            }
            else
            {
                animator.SetFloat("speed", 0.0f);
            }
        }
        
    }
}
