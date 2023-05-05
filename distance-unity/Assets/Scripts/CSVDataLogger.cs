using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;


public class CSVDataLogger : MonoBehaviour
{

    private List<string[]> rowDataList = new List<string[]>();
    [SerializeField] private string ParticipantID = "Participant_TEST";
    private static string LogfileDirectory = "log2csv_logfiles";
    public static string LogfileNameBase = "_log_file.csv";
    private static string LogfileDateTime = "yyyy-MM-dd_HH-mm-ss";

    private float PlayerPosX;
    private float PlayerPosY;
    private float PlayerPosZ;

    private float VehiclePosX;
    private float VehiclePosY;
    private float VehiclePosZ;

    private float VehicleSpeed;

    private string participantNr;
    private string trialNr;
    string receivedDataFromSlider;

    private GameObject gameController;
    private FileStream fs = null;
    private string delimiter = ",";

    public GameObject PlayerObject;
    public GameObject VehicleObject;
    private Rigidbody car_rigidbody;
    private SliderDataProcessing SliderDataReceiver;
    private string LastTrialNr;

    // logfile reference of the current session
    private string logFile;

    // bool representing whether the logging system should be used or not (set in the Unity Inspector)
    public bool activeLogging = true;

    // Use this for initialization
    private void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    private void Start()
    {
        SliderDataReceiver = GameObject.Find("Slider").GetComponent<SliderDataProcessing>();
        //Debug.Log("SliderDataReceiver : " + SliderDataReceiver);

        participantNr = gameController.GetComponent<GameControl>().participantNr.ToString();
        trialNr = Convert.ToString(gameController.GetComponent<GameControl>().trialNr);
        LastTrialNr = trialNr;
        if (activeLogging)
        {
            // check if directory exists (and create it if not)
            if (!Directory.Exists(LogfileDirectory))
            {
                Directory.CreateDirectory(LogfileDirectory);
            }
            // create file for this session using time prefix based on standard UTC time
            logFile = LogfileDirectory
                + "/"
                + System.DateTime.UtcNow.AddMinutes(120).ToString(LogfileDateTime)
                //+ System.DateTime.UtcNow.AddHours(2.0).ToString(LOGFILE_NAME_TIME_FORMAT)	// manually adjust time zone, e.g. + 2 UTC hours for summer time in location Stockholm/Sweden
                + LogfileNameBase;
            File.Create(logFile);
            //fs = new FileStream(logFile, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            if (File.Exists(logFile))
            {
                Debug.Log("[LoggingSystem] LogFile created at " + logFile);
                string[] rowDataTemp = new string[14];
                rowDataTemp[0] = "TimeStamp";
                rowDataTemp[1] = "Participant";
                rowDataTemp[2] = "CarPositionX";
                rowDataTemp[3] = "CarPositionY";
                rowDataTemp[4] = "CarPositionZ";
                rowDataTemp[5] = "ParticipantPosX";
                rowDataTemp[6] = "ParticipantPosY";
                rowDataTemp[7] = "ParticipantPosZ";
                rowDataTemp[8] = "ParticipantRotX";
                rowDataTemp[9] = "ParticipantRotY";
                rowDataTemp[10] = "ParticipantRotZ";
                rowDataTemp[11] = "SliderPosition";
                rowDataTemp[12] = "CarSpeed";
                rowDataTemp[13] = "Trial";
                rowDataList.Add(rowDataTemp);
            }
            else Debug.LogError("[LoggingSystem] Error creating LogFile");
        }

    }

    private void FixedUpdate()
    {
        if (LastTrialNr != trialNr)
        {
            using (fs = new FileStream(logFile, FileMode.Append, FileAccess.Write))
            {
                WriteMessageToLog(rowDataList);
                rowDataList.Clear();
            }
            //fs.Dispose();
            LastTrialNr = trialNr;
        }

        else
        {
            GetDataToLog();
        }
    }

    private void GetDataToLog()
    {   
        receivedDataFromSlider = SliderDataReceiver.messagetocut;
        trialNr = Convert.ToString(gameController.GetComponent<GameControl>().trialNr);
        string[] rowDataTemp = new string[14];
        rowDataTemp[0] = DateTime.UtcNow.ToString("HH:mm:ss.fff");
        rowDataTemp[1] = participantNr;
        rowDataTemp[2] = VehicleObject.transform.position.x.ToString();
        rowDataTemp[3] = VehicleObject.transform.position.y.ToString();
        rowDataTemp[4] = VehicleObject.transform.position.z.ToString();
        rowDataTemp[5] = PlayerObject.transform.position.x.ToString();
        rowDataTemp[6] = PlayerObject.transform.position.y.ToString();
        rowDataTemp[7] = PlayerObject.transform.position.z.ToString();
        rowDataTemp[8] = PlayerObject.transform.rotation.x.ToString();
        rowDataTemp[9] = PlayerObject.transform.rotation.y.ToString();
        rowDataTemp[10] = PlayerObject.transform.rotation.z.ToString();
        rowDataTemp[11] = receivedDataFromSlider;
        rowDataTemp[12] = Convert.ToString(VehicleObject.GetComponent<Rigidbody>().velocity.magnitude * 3.6);
        rowDataTemp[13] = trialNr;
        rowDataList.Add(rowDataTemp);
    }


    private StringBuilder FormatStringByStringBuilder(string[] DataStringArrayToString)
    {
        StringBuilder sb = new StringBuilder();
        //foreach (string listitem in DataStringArrayToString)
        sb.Append(string.Join(delimiter, DataStringArrayToString));
        return sb;
    }


    private void WriteMessageToLog(List<string[]> rowDataList2)
    {
        if (activeLogging)
        {
            using (StreamWriter writer = new StreamWriter(fs))
            {
                for (int i = 0; i < rowDataList2.Count; i++)
                {
                    string[] DataStringArrayToWrite = rowDataList2[i];
                    StringBuilder sb = FormatStringByStringBuilder(DataStringArrayToWrite);
                    //Debug.Log("sb: " + sb);                
                        writer.WriteLine(sb);
                }
                writer.Close();
            }  
           
        }
    }


  

    private void OnApplicationQuit()
    {
        fs.Dispose();
    }
}
