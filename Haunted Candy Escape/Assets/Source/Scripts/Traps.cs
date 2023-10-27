using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Traps : MonoBehaviour
{
    public Transform Spike;
    public float InitialFireMin = 1f;
    public float InitialFireMax = 10f;
    public float IntervalFireMin = 2.5f;
    public float IntervalFireMax = 6.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", Random.Range(InitialFireMin, InitialFireMax), Random.Range(IntervalFireMin, IntervalFireMax));
    }

    private void Fire() {
        Transform spike = Instantiate(Spike, transform.position, Spike.transform.rotation);
    }
}
