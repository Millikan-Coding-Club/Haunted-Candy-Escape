using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Ghost : MonoBehaviour {
    public static bool gameOver = false;
    public static int goals = 0;
    private float gameRestartRefreshWaitTime = 4.00f;

    Rigidbody2D rb;
    Animator anim;
    public AudioSource audioSource;
    public AudioClip DeathClip;

    public float Jump;
    public float Speed;
    public float Scale;
    private float horizontal;
    private string Contact;
    public GameObject startCanvas;

    // Start is called before the first frame update
    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        gameOver = false;
        Time.timeScale = 0f;
        startCanvas.SetActive(true);
    }

    // Update is called once per frame
    void Update() 
    {
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate() 
    {
        if (!gameOver) {
            if (horizontal > 0) {
                // change direction of ghost
                gameObject.transform.localScale = new Vector3(Scale, Scale, Scale);
            }
            if (horizontal < 0) {
                gameObject.transform.localScale = new Vector3(-Scale, Scale, Scale);
            }
            rb.velocity = new Vector2(horizontal * Speed, rb.velocity.y);

        }
    }

    public void StartGame()
    {
        Time.timeScale = 1.0f;
        startCanvas.SetActive(false);
    }

    private void OnCollisionStay2D(Collision2D collision) {
        foreach (ContactPoint2D contact in collision.contacts) {
            if ((collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Enemy") && Mathf.Round(contact.normal.y) > 0) {
                // The bottom of the collider was hit
                if ((Input.GetKey(KeyCode.Space)
                    || Input.GetKey(KeyCode.W)
                    || Input.GetKey(KeyCode.UpArrow))) {
                    rb.velocity = new Vector2(rb.velocity.x, Jump);
                }
                anim.SetBool("Jumping", false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {

        if (collision.gameObject.tag == "Enemy")
        {
            GameOver();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        anim.SetBool("Jumping", true);
    }

    private void GameOver() {
        audioSource.Stop();
        anim.SetBool("Jumping", false);
        GetComponent<Collider2D>().enabled = false;
        audioSource.PlayOneShot(DeathClip, 0.7f);

        gameOver = true;
        rb.velocity = new Vector2(rb.velocity.y, 5);
        GameRestart();
    }

    IEnumerator GameRestartRoutine()
    {
        // Wait for gameRestartRefreshRate
        yield return new WaitForSeconds(gameRestartRefreshWaitTime);

        // Searches and reloads current game scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void GameRestart()
    {
        StartCoroutine(GameRestartRoutine());
    }
}