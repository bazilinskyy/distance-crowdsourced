using UnityEngine;
using System;
using System.Threading;
using System.IO.Ports;
using System.Collections;
using System.Collections.Generic;

public class receiverArduino : MonoBehaviour {

    
    public const string SERIAL_DEVICE_CONNECTED = "__Connected__";
    public const string SERIAL_DEVICE_DISCONNECTED = "__Disconnected__";
    public GameObject messageListener;
    [Tooltip("Port name with which the SerialPort object will be created.")]
    public string portName = "COM6";
    public int bautRate = 500000;
    public Thread serialThreadArdunio;
    public string receivedArduinoData;
    private bool _threadController = false;
    private SerialPort stream;

    void Start()
    {
        stream = new SerialPort(portName, bautRate);
        OpenConnection();
    }

    void OnDisable()
    {
        stream.Close();
        _threadController = false;
    }



    void OpenConnection()
    {
        if (stream != null)
        {
            if (stream.IsOpen)
            {
                stream.Close();
                print("Closing serial port, because it was already open!");
            }

            try {
                stream.Open();
                stream.ReadTimeout = 3000;
                stream.Handshake = Handshake.None;
                serialThreadArdunio = new Thread (ReadSerial);
                serialThreadArdunio.Start();
                _threadController = true;
                Debug.Log("Start() :: Done.");
            }
            catch (SystemException e)
            {
                Debug.Log("Error opening = " + e.Message);
            }
        }

    }

    void ReadSerial() {
        if ((stream != null) && (stream.IsOpen))
        {
            while (_threadController)
            {
                receivedArduinoData = stream.ReadLine();
            }
        }
    }
}

