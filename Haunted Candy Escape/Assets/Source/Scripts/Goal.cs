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
    
    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Player" && !Completed) {
            Ghost.goals++;

            anim.SetBool("Activated", true);

            Completed = true;
            audioSource.Stop();
            audioSource.PlayOneShot(PortalClip, 6f);
            Invoke("PlayAudio", 3);
        }
    }

    private void PlayAudio() 
    {
        audioSource.Play();
    }
}
