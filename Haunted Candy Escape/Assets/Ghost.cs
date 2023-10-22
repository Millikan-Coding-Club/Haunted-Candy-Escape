using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    
    public float Jump;
    public float Speed;
    public float Scale;
    private float horizontal;
    private string Contact;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //if ((Input.GetKey(KeyCode.A)
        //    || Input.GetKey(KeyCode.LeftArrow)) && Mathf.Round(rb.velocity.y) == 0) {
        //    gameObject.transform.localScale = new Vector3(-Scale, Scale, Scale);

        //    rb.velocity = new Vector2(-Speed, rb.velocity.y);
        //}
        //if ((Input.GetKey(KeyCode.D)
        //    || Input.GetKey(KeyCode.RightArrow)) && Mathf.Round(rb.velocity.y) == 0) {

        //    gameObject.transform.localScale = new Vector3(Scale, Scale, Scale);


        //    rb.velocity = new Vector2(Speed, rb.velocity.y);
        //}
        horizontal = Input.GetAxisRaw("Horizontal");

    }
    private void FixedUpdate()
    {
        if (horizontal>0) {
            // change direction of ghost
            gameObject.transform.localScale = new Vector3(Scale, Scale, Scale);
        }
        if (horizontal < 0) {
            gameObject.transform.localScale = new Vector3(-Scale, Scale, Scale);
        }

        rb.velocity = new Vector2(horizontal * Speed, rb.velocity.y);
    }
   
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log(collision.contacts.Length);
        foreach (ContactPoint2D contact in collision.contacts) {

            if (collision.gameObject.tag == "Ground" && Mathf.Round(contact.normal.y) > 0) {
                // The bottom of the collider was hit
                if ((Input.GetKey(KeyCode.Space)
                    || Input.GetKey(KeyCode.W)
                    || Input.GetKey(KeyCode.UpArrow))) {
                    rb.velocity = new Vector2(rb.velocity.x, Jump);
                }
            }
        }
    }
}
