using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {
    public AudioSource audioSource;
    public AudioClip PortalClip;

    Animator anim;

    private bool Completed = false;

    // Start is called before the first frame update
    void Start() 
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() 
    {

    }
    
    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Player" && !Completed) {
            Ghost.goals++;

            anim.SetBool("Activated", true);

            Completed = true;
            audioSource.Stop();
            audioSource.PlayOneShot(PortalClip, 1f);
            Invoke("PlayAudio", 3);
        }
    }

    private void PlayAudio() 
    {
        audioSource.Play();
    }
}
