using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public float yOffset;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Ghost.gameOver) {
            transform.position = new Vector3(transform.position.x, player.transform.position.y + yOffset, -10);
        }
    }
}
