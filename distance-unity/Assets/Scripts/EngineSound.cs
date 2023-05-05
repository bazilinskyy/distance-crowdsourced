using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSound : MonoBehaviour
{
    float modifier = 1;
    public AudioClip[] clipArray;
    public AudioSource engineSoundSource;
    private Rigidbody carRigid;
    private CarAnimation carAnimation;
    private float carSpeedMax = 50.0f / 3.6f;
    private float audioStart;
    private float audioClipLength;
    private float timeSoundAnimation=0f;
    public AnimationCurve curveToLookUpSoundVolume;

    // Start is called before the first frame update

    void Start()
    {
        carRigid = GetComponent<Rigidbody>();
        carAnimation = GetComponent<CarAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        //DefineState();
        if (audioStart + audioClipLength < Time.time)
        {
            if (carAnimation.currentDrivingScenario.Contains("50"))
            {
                UpdateGears50();
            }
            if (carAnimation.currentDrivingScenario.Contains("30"))
            {
                UpdateGears30();
            }
        }

        if (carAnimation.currentDrivingScenario.Contains("50"))
        {
            pitchAudio50();
        }
        if (carAnimation.currentDrivingScenario.Contains("30"))
        {
            pitchAudio30();
        }
    }

    private void pitchAudio50()
    {

        if (carRigid.velocity.magnitude > 30 / 3.6)
        {
            //Debug.Log("50pitch: " + engineSoundSource.pitch);
            engineSoundSource.pitch = 0.3f + carRigid.velocity.magnitude / (80.0f / 3.6f);
        }
        if (carRigid.velocity.magnitude <= 48 / 3.6 && carAnimation.parking)
        {
   
            engineSoundSource.pitch = 0.8f;
            engineSoundSource.volume = 0.3f;
        }


        if (carRigid.velocity.magnitude < 30 / 3.6 && carAnimation.accelerating)
        {
            engineSoundSource.pitch = 0.75f + carRigid.velocity.magnitude / (30.0f / 3.6f);
            if (timeSoundAnimation < 2f)
            {
                engineSoundSource.volume = curveToLookUpSoundVolume.Evaluate(Time.deltaTime / 2);
                timeSoundAnimation += Time.deltaTime;
            }

        }
    }

    private void pitchAudio30()
    {

        if (carRigid.velocity.magnitude > 28 / 3.6)
        {
            
            engineSoundSource.pitch = carRigid.velocity.magnitude / (100.0f / 3.6f);
        }
        if (carRigid.velocity.magnitude <= 28 / 3.6 && carAnimation.parking)
        {
            //Debug.Log("parkt");
            engineSoundSource.pitch = 0.6f;
            engineSoundSource.volume = 0.2f;
        }


        if (carRigid.velocity.magnitude < 30 / 3.6 && carAnimation.accelerating)
        {
            engineSoundSource.pitch = 0.5f + carRigid.velocity.magnitude / (50.0f / 3.6f);
            //Debug.Log("30pitch: " + engineSoundSource.pitch);
            if (timeSoundAnimation < 2f)
            {
                engineSoundSource.volume = curveToLookUpSoundVolume.Evaluate(Time.deltaTime / 2);
                timeSoundAnimation += Time.deltaTime;
            }

        }
    }


    void UpdateGears50()
    {


        if (carRigid.velocity.magnitude > 30 / 3.6 && engineSoundSource.clip != clipArray[1])
        {
            engineSoundSource.clip = clipArray[1];
            audioClipLength = engineSoundSource.clip.length;
            GetComponent<AudioSource>().Play();
            audioStart = Time.time;
        }


        if (carRigid.velocity.magnitude <= 30 / 3.6 && carAnimation.parking && engineSoundSource.clip != clipArray[0])
        {
    
            engineSoundSource.clip = clipArray[0];
            audioClipLength = engineSoundSource.clip.length;
            GetComponent<AudioSource>().Play();
            audioStart = Time.time;
        }

        if (carRigid.velocity.magnitude < 10 / 3.6 && carAnimation.accelerating && engineSoundSource.clip != clipArray[1])
        {
        
            engineSoundSource.clip = clipArray[1];
            audioClipLength = engineSoundSource.clip.length;
            GetComponent<AudioSource>().Play();
            audioStart = Time.time;
        }
    }
        void UpdateGears30()
        {

            if (carRigid.velocity.magnitude > 10 / 3.6 && engineSoundSource.clip != clipArray[1])
            {
                engineSoundSource.clip = clipArray[1];
                audioClipLength = engineSoundSource.clip.length;
                GetComponent<AudioSource>().Play();
                audioStart = Time.time;
            }


            if (carRigid.velocity.magnitude <= 28 / 3.6 && carAnimation.parking && engineSoundSource.clip != clipArray[0])
            {

                engineSoundSource.clip = clipArray[0];
                audioClipLength = engineSoundSource.clip.length;
                GetComponent<AudioSource>().Play();
                audioStart = Time.time;
            }

            if (carRigid.velocity.magnitude < 10 / 3.6 && carAnimation.accelerating && engineSoundSource.clip != clipArray[1])
            {
                engineSoundSource.clip = clipArray[1];
                audioClipLength = engineSoundSource.clip.length;
                GetComponent<AudioSource>().Play();
                audioStart = Time.time;
            }

        }

}

