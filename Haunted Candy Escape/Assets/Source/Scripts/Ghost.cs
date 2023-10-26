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

    Rigidbody2D rb;
    Animator anim;
    public AudioSource audioSource;
    public AudioClip DeathClip;
    public AudioClip VictoryClip;

    public float Jump;
    public float Speed;
    public float Scale;
    private float horizontal;
    public GameObject startCanvas;
    public GameObject gameOverCanvas;
    public TextMeshProUGUI gameOverText;

    // Start is called before the first frame update
    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        gameOver = false;
        Time.timeScale = 0f;
        gameOverCanvas.SetActive(false);
        startCanvas.SetActive(true);
        goals = 0;
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
            if (goals >=3) {
                GameOver();
            }
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

        if (collision.gameObject.tag == "Enemy" && !gameOver)
        {
            audioSource.Stop();
            anim.SetBool("Jumping", false);
            GetComponent<Collider2D>().enabled = false;
            audioSource.PlayOneShot(DeathClip, 0.7f);
            rb.velocity = new Vector2(rb.velocity.y, 5);

            GameOver();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        anim.SetBool("Jumping", true);
    }

    public void GameOver() {
        gameOver = true;
        Invoke("GameOverScreen", 2);
    }
    private void GameOverScreen() {
        if (goals == 0) {
            gameOverText.text = "Better Luck Next Time!";
        }
        else if (goals == 1) {
            audioSource.PlayOneShot(VictoryClip, 1f);
            gameOverText.text = "Congratulations, you scored 1 goal!";
        }
        else if (goals == 2) {
            audioSource.PlayOneShot(VictoryClip, 1f);
            gameOverText.text = "Congratulations, you scored 2 goals!";
        }
        else if (goals == 3)
        {
            audioSource.PlayOneShot(VictoryClip, 1f);
            gameOverText.text = "Congratulations, you scored 3 goals!";
        }
        gameOverCanvas.SetActive(true);
    }

    //IEnumerator GameRestartRoutine()
    //{
    //    // Wait for gameRestartRefreshRate
    //    yield return new WaitForSeconds(gameRestartRefreshWaitTime);

    //    // Searches and reloads current game scene
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //}

    public void GameRestart()
    {
        //StartCoroutine(GameRestartRoutine());
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}