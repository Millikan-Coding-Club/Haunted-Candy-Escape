using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    public float Jump;
    public float Speed;

    bool isJumping = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && isJumping == false) {
            rb.AddForce(Vector2.up * Jump);
            isJumping = true;
        }
        if ((Input.GetKey(KeyCode.A)
            || Input.GetKey(KeyCode.LeftArrow))) {

            rb.velocity = new Vector2(-Speed, rb.velocity.y);
        }
        if ((Input.GetKey(KeyCode.D)
            || Input.GetKey(KeyCode.RightArrow))) {
            Debug.Log("hi");

            rb.velocity = new Vector2(Speed, rb.velocity.y);
        }
        Debug.Log(rb.velocity);
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            isJumping = false;
        }
    }
}
