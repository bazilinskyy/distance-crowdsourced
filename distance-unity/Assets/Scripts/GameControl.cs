using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public int participantNr = 1;
    public int trialNr = 1;
    [SerializeField] public List<int> drivingScenarioOrder = new List<int>();
   

    // Start is called before the first frame update
    void Awake()
    {
        //Debug.Log("Check if order of scenarios is the same as in the RW Study!");
        
        ScenarioControler(participantNr);
    }

    void Update()
    {
         }

    //Sets the randomization group according to Daves List "Trial Order"
    public void ScenarioControler(int participantNr)
    {
        switch (participantNr)
        {   // ToDo: Add further randomization groups
            case 999:
                drivingScenarioOrder.Add(1);
                drivingScenarioOrder.Add(1);
                drivingScenarioOrder.Add(1);
                drivingScenarioOrder.Add(1);
                break;
            case 1:
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(1);

                drivingScenarioOrder.Add(7);
                drivingScenarioOrder.Add(3);
                drivingScenarioOrder.Add(6);
                drivingScenarioOrder.Add(1);
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(8);
                drivingScenarioOrder.Add(4);
                drivingScenarioOrder.Add(5);
                break;
            case 2:
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(1);

                drivingScenarioOrder.Add(3);
                drivingScenarioOrder.Add(5);
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(6);
                drivingScenarioOrder.Add(8);
                drivingScenarioOrder.Add(4);
                drivingScenarioOrder.Add(7);
                drivingScenarioOrder.Add(1);
                break;
            case 3:
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(1);

                drivingScenarioOrder.Add(5);
                drivingScenarioOrder.Add(1);
                drivingScenarioOrder.Add(8);
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(4);
                drivingScenarioOrder.Add(7);
                drivingScenarioOrder.Add(3);
                drivingScenarioOrder.Add(6);
                break;
            case 4:
                //drivingScenarioOrder.Add(2);
                //drivingScenarioOrder.Add(1);

                //drivingScenarioOrder.Add(1);
                //drivingScenarioOrder.Add(6);
                //drivingScenarioOrder.Add(4);
                drivingScenarioOrder.Add(8);
                drivingScenarioOrder.Add(7);
                drivingScenarioOrder.Add(3);
                drivingScenarioOrder.Add(5);
                drivingScenarioOrder.Add(2);
                break;
            case 5:
                //drivingScenarioOrder.Add(2);
                //drivingScenarioOrder.Add(1);

                //drivingScenarioOrder.Add(6);
                //drivingScenarioOrder.Add(2);
                //drivingScenarioOrder.Add(7);
                //drivingScenarioOrder.Add(4);
                //drivingScenarioOrder.Add(3);
                //drivingScenarioOrder.Add(5);
                //drivingScenarioOrder.Add(1);
                drivingScenarioOrder.Add(8);
                break;
            case 6:
                //drivingScenarioOrder.Add(4);

                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(1);

                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(8);
                drivingScenarioOrder.Add(3);
                drivingScenarioOrder.Add(7);
                drivingScenarioOrder.Add(5);
                drivingScenarioOrder.Add(1);
                drivingScenarioOrder.Add(6);
                drivingScenarioOrder.Add(4);
                break;
            case 7:
                //drivingScenarioOrder.Add(2);
                //drivingScenarioOrder.Add(1);

                //drivingScenarioOrder.Add(8);
                drivingScenarioOrder.Add(4);
                drivingScenarioOrder.Add(5);
                drivingScenarioOrder.Add(3);
                drivingScenarioOrder.Add(1);
                drivingScenarioOrder.Add(6);
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(7);
                break;
            case 8:
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(1);

                drivingScenarioOrder.Add(4);
                drivingScenarioOrder.Add(7);
                drivingScenarioOrder.Add(1);
                drivingScenarioOrder.Add(5);
                drivingScenarioOrder.Add(6);
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(8);
                drivingScenarioOrder.Add(3);
                break;
            case 9:
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(1);

                drivingScenarioOrder.Add(7);
                drivingScenarioOrder.Add(3);
                drivingScenarioOrder.Add(6);
                drivingScenarioOrder.Add(1);
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(8);
                drivingScenarioOrder.Add(4);
                drivingScenarioOrder.Add(5);
                break;
            case 10:
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(1);

                drivingScenarioOrder.Add(3);
                drivingScenarioOrder.Add(5);
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(6);
                drivingScenarioOrder.Add(8);
                drivingScenarioOrder.Add(4);
                drivingScenarioOrder.Add(7);
                drivingScenarioOrder.Add(1);
                break;
            case 11:
                //drivingScenarioOrder.Add(2);
                //drivingScenarioOrder.Add(1);

                //drivingScenarioOrder.Add(5);
                drivingScenarioOrder.Add(1);
                drivingScenarioOrder.Add(8);
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(4);
                drivingScenarioOrder.Add(7);
                drivingScenarioOrder.Add(3);
                drivingScenarioOrder.Add(6);
                break;
            case 12:
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(1);

                drivingScenarioOrder.Add(1);
                drivingScenarioOrder.Add(6);
                drivingScenarioOrder.Add(4);
                drivingScenarioOrder.Add(8);
                drivingScenarioOrder.Add(7);
                drivingScenarioOrder.Add(3);
                drivingScenarioOrder.Add(5);
                drivingScenarioOrder.Add(2);
                break;
            case 13:
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(1);

                drivingScenarioOrder.Add(6);
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(7);
                drivingScenarioOrder.Add(4);
                drivingScenarioOrder.Add(3);
                drivingScenarioOrder.Add(5);
                drivingScenarioOrder.Add(1);
                drivingScenarioOrder.Add(8);
                break;
            case 14:
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(1);

                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(8);
                drivingScenarioOrder.Add(3);
                drivingScenarioOrder.Add(7);
                drivingScenarioOrder.Add(5);
                drivingScenarioOrder.Add(1);
                drivingScenarioOrder.Add(6);
                drivingScenarioOrder.Add(4);
                break;
            case 15:
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(1);

                drivingScenarioOrder.Add(8);
                drivingScenarioOrder.Add(4);
                drivingScenarioOrder.Add(5);
                drivingScenarioOrder.Add(3);
                drivingScenarioOrder.Add(1);
                drivingScenarioOrder.Add(6);
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(7);
                break;
            case 16:
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(1);

                drivingScenarioOrder.Add(4);
                drivingScenarioOrder.Add(7);
                drivingScenarioOrder.Add(1);
                drivingScenarioOrder.Add(5);
                drivingScenarioOrder.Add(6);
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(8);
                drivingScenarioOrder.Add(3);
                break;
            case 17:
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(1);

                drivingScenarioOrder.Add(7);
                drivingScenarioOrder.Add(3);
                drivingScenarioOrder.Add(6);
                drivingScenarioOrder.Add(1);
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(8);
                drivingScenarioOrder.Add(4);
                drivingScenarioOrder.Add(5);
                break;
            case 18:
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(1);

                drivingScenarioOrder.Add(3);
                drivingScenarioOrder.Add(5);
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(6);
                drivingScenarioOrder.Add(8);
                drivingScenarioOrder.Add(4);
                drivingScenarioOrder.Add(7);
                drivingScenarioOrder.Add(1);
                break;
            case 19:
                //drivingScenarioOrder.Add(2);
                //drivingScenarioOrder.Add(1);

                //drivingScenarioOrder.Add(5);
                //drivingScenarioOrder.Add(1);
                drivingScenarioOrder.Add(8);
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(4);
                drivingScenarioOrder.Add(7);
                drivingScenarioOrder.Add(3);
                drivingScenarioOrder.Add(6);
                break;
            case 20:
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(1);

                drivingScenarioOrder.Add(1);
                drivingScenarioOrder.Add(6);
                drivingScenarioOrder.Add(4);
                drivingScenarioOrder.Add(8);
                drivingScenarioOrder.Add(7);
                drivingScenarioOrder.Add(3);
                drivingScenarioOrder.Add(5);
                drivingScenarioOrder.Add(2);
                break;
            case 21:
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(1);

                drivingScenarioOrder.Add(6);
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(7);
                drivingScenarioOrder.Add(4);
                drivingScenarioOrder.Add(3);
                drivingScenarioOrder.Add(5);
                drivingScenarioOrder.Add(1);
                drivingScenarioOrder.Add(8);
                break;
            case 22:
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(1);

                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(8);
                drivingScenarioOrder.Add(3);
                drivingScenarioOrder.Add(7);
                drivingScenarioOrder.Add(5);
                drivingScenarioOrder.Add(1);
                drivingScenarioOrder.Add(6);
                drivingScenarioOrder.Add(4);
                break;
            case 23:
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(1);

                drivingScenarioOrder.Add(8);
                drivingScenarioOrder.Add(4);
                drivingScenarioOrder.Add(5);
                drivingScenarioOrder.Add(3);
                drivingScenarioOrder.Add(1);
                drivingScenarioOrder.Add(6);
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(7);
                break;
            case 24:
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(1);

                drivingScenarioOrder.Add(4);
                drivingScenarioOrder.Add(7);
                drivingScenarioOrder.Add(1);
                drivingScenarioOrder.Add(5);
                drivingScenarioOrder.Add(6);
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(8);
                drivingScenarioOrder.Add(3);
                break;
            case 25:
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(1);

                drivingScenarioOrder.Add(7);
                drivingScenarioOrder.Add(3);
                drivingScenarioOrder.Add(6);
                drivingScenarioOrder.Add(1);
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(8);
                drivingScenarioOrder.Add(4);
                drivingScenarioOrder.Add(5);
                break;
            case 26:
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(1);

                drivingScenarioOrder.Add(3);
                drivingScenarioOrder.Add(5);
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(6);
                drivingScenarioOrder.Add(8);
                drivingScenarioOrder.Add(4);
                drivingScenarioOrder.Add(7);
                drivingScenarioOrder.Add(1);
                break;
            case 27:
                //drivingScenarioOrder.Add(2);
                //drivingScenarioOrder.Add(1);

                //drivingScenarioOrder.Add(5);
                drivingScenarioOrder.Add(1);
                drivingScenarioOrder.Add(8);
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(4);
                drivingScenarioOrder.Add(7);
                drivingScenarioOrder.Add(3);
                drivingScenarioOrder.Add(6);
                break;
            case 28:
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(1);

                drivingScenarioOrder.Add(1);
                drivingScenarioOrder.Add(6);
                drivingScenarioOrder.Add(4);
                drivingScenarioOrder.Add(8);
                drivingScenarioOrder.Add(7);
                drivingScenarioOrder.Add(3);
                drivingScenarioOrder.Add(5);
                drivingScenarioOrder.Add(2);
                break;
            case 29:
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(1);

                drivingScenarioOrder.Add(6);
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(7);
                drivingScenarioOrder.Add(4);
                drivingScenarioOrder.Add(3);
                drivingScenarioOrder.Add(5);
                drivingScenarioOrder.Add(1);
                drivingScenarioOrder.Add(8);
                break;
            case 30:
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(1);

                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(8);
                drivingScenarioOrder.Add(3);
                drivingScenarioOrder.Add(7);
                drivingScenarioOrder.Add(5);
                drivingScenarioOrder.Add(1);
                drivingScenarioOrder.Add(6);
                drivingScenarioOrder.Add(4);
                break;
            case 31:
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(1);

                drivingScenarioOrder.Add(7);
                drivingScenarioOrder.Add(3);
                drivingScenarioOrder.Add(6);
                drivingScenarioOrder.Add(1);
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(8);
                drivingScenarioOrder.Add(4);
                drivingScenarioOrder.Add(5);
                break;
            case 32:
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(1);

                drivingScenarioOrder.Add(3);
                drivingScenarioOrder.Add(5);
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(6);
                drivingScenarioOrder.Add(8);
                drivingScenarioOrder.Add(4);
                drivingScenarioOrder.Add(7);
                drivingScenarioOrder.Add(1);
                break;
            case 33:
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(1);

                drivingScenarioOrder.Add(8);
                drivingScenarioOrder.Add(4);
                drivingScenarioOrder.Add(5);
                drivingScenarioOrder.Add(3);
                drivingScenarioOrder.Add(1);
                drivingScenarioOrder.Add(6);
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(7);
                break;
            case 34:
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(1);

                drivingScenarioOrder.Add(4);
                drivingScenarioOrder.Add(7);
                drivingScenarioOrder.Add(1);
                drivingScenarioOrder.Add(5);
                drivingScenarioOrder.Add(6);
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(8);
                drivingScenarioOrder.Add(3);
                break;
            case 35:
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(1);

                drivingScenarioOrder.Add(7);
                drivingScenarioOrder.Add(3);
                drivingScenarioOrder.Add(6);
                drivingScenarioOrder.Add(1);
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(8);
                drivingScenarioOrder.Add(4);
                drivingScenarioOrder.Add(5);
                break;
            case 36:
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(1);

                drivingScenarioOrder.Add(3);
                drivingScenarioOrder.Add(5);
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(6);
                drivingScenarioOrder.Add(8);
                drivingScenarioOrder.Add(4);
                drivingScenarioOrder.Add(7);
                drivingScenarioOrder.Add(1);
                break;
            case 37:
                //drivingScenarioOrder.Add(2);
                //drivingScenarioOrder.Add(1);

                //drivingScenarioOrder.Add(5);
                //drivingScenarioOrder.Add(1);
                drivingScenarioOrder.Add(8);
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(4);
                drivingScenarioOrder.Add(7);
                drivingScenarioOrder.Add(3);
                drivingScenarioOrder.Add(6);
                break;
            case 38:
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(1);

                drivingScenarioOrder.Add(1);
                drivingScenarioOrder.Add(6);
                drivingScenarioOrder.Add(4);
                drivingScenarioOrder.Add(8);
                drivingScenarioOrder.Add(7);
                drivingScenarioOrder.Add(3);
                drivingScenarioOrder.Add(5);
                drivingScenarioOrder.Add(2);
                break;
            case 39:
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(1);

                drivingScenarioOrder.Add(6);
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(7);
                drivingScenarioOrder.Add(4);
                drivingScenarioOrder.Add(3);
                drivingScenarioOrder.Add(5);
                drivingScenarioOrder.Add(1);
                drivingScenarioOrder.Add(8);
                break;
            case 40:
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(1);

                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(8);
                drivingScenarioOrder.Add(3);
                drivingScenarioOrder.Add(7);
                drivingScenarioOrder.Add(5);
                drivingScenarioOrder.Add(1);
                drivingScenarioOrder.Add(6);
                drivingScenarioOrder.Add(4);
                break;  

            default:
                //The same order of driving events for the first participant
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(1);

                drivingScenarioOrder.Add(7);
                drivingScenarioOrder.Add(3);
                drivingScenarioOrder.Add(6);
                drivingScenarioOrder.Add(1);
                drivingScenarioOrder.Add(2);
                drivingScenarioOrder.Add(8);
                drivingScenarioOrder.Add(4);
                drivingScenarioOrder.Add(5);
                break;
        }

    }

}
