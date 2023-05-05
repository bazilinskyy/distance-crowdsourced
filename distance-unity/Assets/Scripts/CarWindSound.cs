using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarWindSound : MonoBehaviour
{
    public AudioSource windSoundSource;
    public Rigidbody carRigid;

    private void Awake()
    {
        carRigid = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        adaptingWindsoundtoSpeed();
    }

    private void adaptingWindsoundtoSpeed()
    {
        windSoundSource.volume = carRigid.velocity.magnitude * carRigid.velocity.magnitude / 110;
     
    }
}
