using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Goal : MonoBehaviour {
    public AudioSource audioSource;
    public AudioClip PortalClip;
    public TextMeshProUGUI portalText;

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
            portalText.text = Ghost.goals.ToString();
            anim.SetBool("Activated", true);

            Completed = true;
            audioSource.PlayOneShot(PortalClip, 6f);
        }
    }

    private void PlayAudio() 
    {
        audioSource.Play();
    }
}
