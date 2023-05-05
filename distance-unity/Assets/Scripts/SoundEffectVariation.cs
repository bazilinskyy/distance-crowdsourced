using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectVariation : MonoBehaviour
{

    public AudioClip[] clipArray;
    public AudioSource effectSource;
    public float pitchMin, pitchMax, volumeMin, volumeMax;
    private int clipIndex;
    private float minTime = 20;
    private float maxTime = 45;
    private float currentTime;
    private float playTime;

    // Start is called before the first frame update
    void Start()
    {
        SetRandomTime();
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {

        //Counts up
        currentTime += Time.deltaTime;
        //Check if its the right time to spawn the object
        if (currentTime >= playTime)
        {
            PlayRoundRobin(); ;
            SetRandomTime();
            currentTime = 0;
        }

        //PlayRandom2();
    }

    void PlayRoundRobin()
    {
        effectSource.pitch = Random.Range(pitchMin, pitchMax);
        effectSource.volume = Random.Range(volumeMin, volumeMax);

        if (clipIndex < clipArray.Length)
        {
            effectSource.PlayOneShot(clipArray[clipIndex]);
            clipIndex++;
        }

        else
        {
            clipIndex = 0;
            effectSource.PlayOneShot(clipArray[clipIndex]);
            clipIndex++;
        }
    }

    void PlayRandom()
    {
        effectSource.pitch = Random.Range(pitchMin, pitchMax);
        effectSource.volume = Random.Range(volumeMin, volumeMax);
        clipIndex = Random.Range(0, clipArray.Length);
        effectSource.PlayOneShot(clipArray[clipIndex]);
    }

    int RepeatCheck(int previousIndex, int range)
    {
        int index = Random.Range(0, range);

        while (index == previousIndex)
        {
            index = Random.Range(0, range);
        }
        return index;
    }

    void PlayRandom2()
    {
        clipIndex = RepeatCheck(clipIndex, clipArray.Length);
        effectSource.PlayOneShot(clipArray[clipIndex]);
    }

    void SetRandomTime()
    {
        playTime = Random.Range(minTime, maxTime);
    }


}

