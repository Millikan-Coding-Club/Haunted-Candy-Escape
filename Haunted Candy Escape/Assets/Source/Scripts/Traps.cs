using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Traps : MonoBehaviour
{
    public Transform Spike;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", Random.Range(1f, 10f), Random.Range(2.5f, 6f));
    }

    private void Fire() {
        Transform spike = Instantiate(Spike, transform.position, Spike.transform.rotation);
    }
}
