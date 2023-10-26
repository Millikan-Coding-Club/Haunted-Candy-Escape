using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Traps : MonoBehaviour
{
    public Transform Spike;
    public float TimeBeforeStart;
    public float TimeInterval;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", TimeBeforeStart, TimeInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Fire() {
        Transform spike = Instantiate(Spike, transform.position, Spike.transform.rotation);
    }
}
