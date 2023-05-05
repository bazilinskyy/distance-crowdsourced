using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderDataProcessing : MonoBehaviour
{
    private GameObject serialController;
    [SerializeField] public string messagetocut;
    [SerializeField] public float ConvertedStringNorm;

    void Start()
    {
        serialController = GameObject.Find("ArduinoReceiver");
    }
    private void FixedUpdate()
    {
        messagetocut = serialController.GetComponent<receiverArduino>().receivedArduinoData;
        ConvertedStringNorm = SliderParser(messagetocut);
    }


    public float SliderParser(string StringtoConvert)
    {
        float ConvertedString = float.Parse(StringtoConvert);
        return ConvertedString;
    }


}
