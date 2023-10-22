using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Acid : MonoBehaviour
{
    public float First = 1.0f;
    public float Rate = 0.2f;
    public float Time = 0.2f;
    // Start is called before the first frame update
    void Start() {
        // name, time, invoke
        InvokeRepeating("MoveUp", First, Time);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }
    private void MoveUp() {
        gameObject.transform.position = new Vector2(0, gameObject.transform.position.y + Rate);
    }
}
