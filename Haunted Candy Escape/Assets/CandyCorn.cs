using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyCorn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0f, 180f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
