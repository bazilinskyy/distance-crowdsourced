using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider_mover : MonoBehaviour
{
  
    private Vector3 tempPosKnob;
    private Vector3 maxValueEmptyPos;
    private Vector3 minValueEmptyPos;
    //public GameObject minValueEmpty;
    public GameObject maxValueEmpty;
    public GameObject minValueEmpty;
    [SerializeField] private float KnobPosition;
    [SerializeField] private float KnobPositionFloat;
    private Vector3 tempTransform;
    [SerializeField] private int currentKnobPosNorm = 0;
    [SerializeField] private SliderDataProcessing SliderDataHandler;
    [SerializeField] private float MoveableDistance;
    [SerializeField] private float ScaleforKnobTransform;
    [SerializeField] private float InterpolatedNormKnobPosition;




    //private int sliderPosNorm = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        //SliderDataHandler = GameObject.Find("Slider").GetComponent<SliderDataProcessing>();
    }
    void Start()
    {
        minValueEmptyPos = minValueEmpty.transform.localPosition;
        maxValueEmptyPos = maxValueEmpty.transform.localPosition;
        transform.localPosition = minValueEmptyPos;
        tempPosKnob = transform.localPosition;
        MoveableDistance = maxValueEmptyPos.y - minValueEmptyPos.y;
        ScaleforKnobTransform = MoveableDistance/ 255;
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        //currentKnobPosNorm = 200; //GetComponentInParent<SliderDataProcessing>().ConvertedStringNorm;
        KnobPositionFloat = SliderDataHandler.ConvertedStringNorm;
        InterpolatedNormKnobPosition = calculateKnobPosition(KnobPositionFloat);
        setKnobPosition(InterpolatedNormKnobPosition);
    }


    // Calculating the latest Sliderknob position.
    private float calculateKnobPosition(float currentKnobPosNorm)
    {
        
        float currentKnobPos = ScaleforKnobTransform * currentKnobPosNorm;
        return currentKnobPos;
    }

    // Moving the Sliderknob to its new position
    void setKnobPosition(float currentKnobPos)
    {
        tempTransform = transform.localPosition;
        tempPosKnob.y = minValueEmptyPos.y + currentKnobPos;
        //float speed = Time.deltaTime * 0.8f;

        //transform.localPosition = tempPosKnob;
        transform.localPosition = Vector3.Lerp(tempTransform, tempPosKnob, 0.8f);
    }



}

