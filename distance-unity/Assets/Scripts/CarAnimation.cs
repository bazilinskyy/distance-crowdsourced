using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAnimation : MonoBehaviour
{
    public WheelCollider WheelFL, WheelFR;
    public WheelCollider WheelRL, WheelRR;
    public Transform WheelTransformFL, WheelTransformFR;
    public Transform WheelTransformRL, WheelTransformRR;
    private float maxSteerAngle = 45;
    public float motorForce = 700;
    [SerializeField] private float brakeForce;
    private float brakeForceTrial;
    public float targetSpeed;
    private GameObject Waypoints;
    private List<GameObject> waypointlist;
    private GameObject StartpositionObject;
    private Rigidbody carRigid;
    public GameObject targetLocation;
    private float m_horizontalInput;
    private float m_verticalInput;
    private float m_steeringAngle;
    private int colliderTagToBreakAt;


    private GameObject gameController;
    public bool accelerating = true;
    public bool braking = false;
    public bool parking = false;
    private bool manuel = false;
    public string currentDrivingScenario;
    private float timer = 0;
    public float steeringAngle;
    private bool carReset;

    private void Awake()
    {
        Waypoints = GameObject.FindGameObjectWithTag("WayPointsList");
        waypointlist = LoadingWaypoints(Waypoints);
        carRigid = GetComponent<Rigidbody>();
        gameController = GameObject.FindGameObjectWithTag("GameController");

    }



    private void Start()
    {
        SetScenario();
        setCaratStart();
        
    }



    void FixedUpdate()
    {
        GetInput();
        ManualSteer();
        Accelerate();

        AutomatedSteering();
        UpdateWheelPoses();
        CarLateralControler();
    }


    void Update()
    {
        //Debug.Log(carRigid.velocity.magnitude*3.6);
        if (Input.anyKeyDown)
        {
            InputHandler();
        }
       // Debug.Log("Participant Number " + gameController.GetComponent<GameControl>().participantNr + "Chosen Trial Number is " + gameController.GetComponent<GameControl>().trialNr + "which is condition" + currentDrivingScenario);
    }




    private void CarLateralControler()
    {
        if (accelerating == true)
        {
            CarAccelerating();
        }
        if (braking== true && accelerating == false)
        {
            //Debug.Log("bremst");
            CarBraking();
        }
        if (accelerating == false && braking == false && parking == true)
        {
            CarParking(2.0f);
        }
    }


    private void InputHandler()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Manuel Fahren");
            braking = false;
            accelerating = false;
            parking = false;
            manuel = true;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            braking = false;
            accelerating = true;
            parking = false;
            manuel = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gameController.GetComponent<GameControl>().trialNr -= 1;
  
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            gameController.GetComponent<GameControl>().trialNr += 1;
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            carReset = true;
        }
    }

    // SetScenario sets the paramters that set the car parameters for the single Braking scenarios.
    private void SetScenario()
    {
        int _currentScenario = gameController.GetComponent<GameControl>().drivingScenarioOrder[gameController.GetComponent<GameControl>().trialNr - 1];
        //Debug.Log(_currentScenario);
        switch (_currentScenario)
        {
            case 1:
                //Debug.Log("Active Scenario 50kmh_Constant");
                currentDrivingScenario = "50kmh_Constant";
                targetLocation = GetWayPointGameObjectByName("50kmh_Constant");
                targetSpeed = 50.0f / 3.6f;
                brakeForceTrial = 1800f;
                break;
            case 2:
                //Debug.Log("Active Scenario 50kmh_GentleBraking");
                currentDrivingScenario = "50kmh_GentleBraking";
                targetSpeed = 50.0f / 3.6f;
                brakeForceTrial = 763.0f;
                targetLocation = GetWayPointGameObjectByName("reducespeed");
                break;
            case 3:
                //Debug.Log("50kmh_EarlyBraking");
                currentDrivingScenario = "50kmh_EarlyBraking";
                targetSpeed = 50.0f / 3.6f;
                brakeForceTrial = 1600.0f;
                targetLocation = GetWayPointGameObjectByName("reducespeed");
                break;
            case 4:
                //Debug.Log("50kmh_AggressiveBraking");
                currentDrivingScenario = "50kmh_AggressiveBraking";
                targetSpeed = 50.0f / 3.6f;
                brakeForceTrial = 1602.0f;
                targetLocation = GetWayPointGameObjectByName("reducespeed");
                break;
            case 5:
                //Debug.Log("30kmh_Constant");
                currentDrivingScenario = "30kmh_Constant";
                targetSpeed = 30.0f / 3.6f;
                brakeForceTrial = 668.0f;
                targetLocation = GetWayPointGameObjectByName("30kmh_Constant");
                break;
            case 6:
                //Debug.Log("30kmh_GentleBraking");
                currentDrivingScenario = "30kmh_GentleBraking";
                targetSpeed = 30.0f / 3.6f;
                brakeForceTrial = 760.0f;
                targetLocation = GetWayPointGameObjectByName("reducespeed");
                break;
            case 7:
                //Debug.Log("30kmh_EarlyBraking");
                currentDrivingScenario = "30kmh_EarlyBraking";
                targetSpeed = 30.0f / 3.6f;
                brakeForceTrial = 1700.0f;
                targetLocation = GetWayPointGameObjectByName("reducespeed");
                break;
            case 8:
                //Debug.Log("30kmh_AggressivBraking");
                currentDrivingScenario = "30kmh_AggressivBraking";
                targetSpeed = 30.0f / 3.6f;
                brakeForceTrial = 1830.0f;
                targetLocation = GetWayPointGameObjectByName("reducespeed");
                break;
        }
    }

    // Checks the name of the trigger entered by the vehicle and sets the according driving state and the next destination target to steer to.
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "BrakeToStartPosition")
        {
            accelerating = false;
            braking = true;
            parking = true;
            targetSpeed = 0.001f;
            targetLocation = GetWayPointGameObjectByName("CarStartPosition");
        }
        if (other.name == "CarStartPosition")
        {
            if (currentDrivingScenario.Contains("50"))
            { targetSpeed = 50.0f / 3.6f; }
            if (currentDrivingScenario.Contains("30"))
            { targetSpeed = 30.0f / 3.6f; }
            brakeForce = brakeForceTrial;
            targetLocation = GetWayPointGameObjectByName("reducespeed");
            //Debug.Log(targetLocation);
        }

        //50const
        if (other.name == "50kmh_Constant" && currentDrivingScenario == "50kmh_Constant")
        {
            //Debug.Log("I hit the" + other.name);
            accelerating = false;
            braking = true;
            parking = false;
            targetSpeed = 5.0f;
        }

        //50gentle
        if (other.name == "50kmh_GentleBraking" && currentDrivingScenario == "50kmh_GentleBraking")
        {
            //Debug.Log("Or this" + other.name);
            accelerating = false;
            braking = true;
            parking = true;
            targetSpeed = 0.001f;
        }

        //50earlyto20
        if (other.name == "50kmh_EarlyBraking_to20kmh" && currentDrivingScenario == "50kmh_EarlyBraking")
        {
            //Debug.Log(carRigid.velocity.magnitude * 3.6);
            accelerating = false;
            braking = true;
            parking = false;
            targetSpeed = 0.001f;

        }

        //50earlytoStop
        if (other.name == "50kmh_EarlyBraking_toStop" && currentDrivingScenario == "50kmh_EarlyBraking")
        {
            //Debug.Log(carRigid.velocity.magnitude * 3.6);
            accelerating = false;
            braking = false;
            parking = true;
            brakeForce = 200.0f;
            targetSpeed = 0.001f;
        }

        //50aggressiv
        if (other.name == "50kmh_AggressiveBraking" && currentDrivingScenario == "50kmh_AggressiveBraking")
        {
            //Debug.Log("Or those" + other.name);
            accelerating = false;
            braking = true;
            parking = true;
            targetSpeed = 0.001f;
        }

        //30const
        if (other.name == "30kmh_Constant" && currentDrivingScenario == "30kmh_Constant")
        {
            accelerating = false;
            braking = true;
            parking = false;
            targetSpeed = 5.0f;
        }

        //30Gentle
        if (other.name == "30kmh_GentleBraking" && currentDrivingScenario == "30kmh_GentleBraking")
        {
            accelerating = false;
            braking = true;
            parking = true;
            targetSpeed = 0.001f;
        }

        //30Earlyto10
        if (other.name == "30kmh_EarlyBrakingto10" && currentDrivingScenario == "30kmh_EarlyBraking")
        {
            //Debug.Log("At10" + carRigid.velocity.magnitude * 3.6);
            accelerating = false;
            braking = true;
            parking = false;
            targetSpeed = 0.001f;
        }
        //30EarlytoStop
        if (other.name == "30kmh_EarlyBrakingtoStop" && currentDrivingScenario == "30kmh_EarlyBraking")
        { //mit 120kg Reifen
            //Debug.Log("10 to Stop");
            accelerating = false;
            braking = true;
            parking = true;
            brakeForce = 160.0f;
            targetSpeed = 0.001f;
        }


        if (other.name == "30kmh_AggressivBraking" && currentDrivingScenario == "30kmh_AggressivBraking")
        {
            //Debug.Log("Agreesiv30");
            accelerating = false;
            braking = true;
            parking = true;
            targetSpeed = 0.001f;
        }
        //breaking in all scenarios
        if (other.name == "reducespeed" && currentDrivingScenario != "30kmh_Constant" && currentDrivingScenario != "50kmh_Constant")
        {
            //Debug.Log("Found Reducespeed");
            accelerating = true;
            braking = false;
            parking = false;
            targetSpeed = 4.0f;
        }

        if (other.name == "cornerin")
        {
            //Debug.Log("Found Corner In");
            targetLocation = GetWayPointGameObjectByName("cornerout");
            targetSpeed = 4.0f;
            accelerating = false;
            braking = true;
            parking = false;
        }

        if (other.name == "cornerout")
        {
            //Debug.Log("Fährt aus Kurve raus");
            targetLocation = GetWayPointGameObjectByName("reset");
            targetSpeed = 20.0f;
            accelerating = true;
            braking = false;
            parking = false;
        }

        if (other.name == "reset")
        {
            if (carReset)
            {
                SetScenario();
                carReset = false;
                carRigid.velocity = Vector3.zero;
                carRigid.angularVelocity = Vector3.zero;
                CarParking(5.0f);
                setCaratStart();
            }
            else
            {
                gameController.GetComponent<GameControl>().trialNr += 1;
                SetScenario();
                carRigid.velocity = Vector3.zero;
                carRigid.angularVelocity = Vector3.zero;
                CarParking(5.0f);
                setCaratStart();
            }
        }
    }

    private GameObject GetWayPointGameObjectByName(string _name)
    {   // ToDo: Abfangen, dass es einen Tippfehler geben kann und es keine Ergebnis gibt.
        GameObject _desiredWaypointTemp = null;
 
        for (int i = 0; i < waypointlist.Count; i++)
        {
            if (waypointlist[i].name == _name)
            {
                _desiredWaypointTemp = waypointlist[i];
                break;
                
            }
        }
        return _desiredWaypointTemp;
    }


    private void setCaratStart()
    {
        for (int i = 0; i < waypointlist.Count; i++)
        {
            if (waypointlist[i].name == "SpawnPoint")
            {
                StartpositionObject = waypointlist[i];
            }
        }
        Vector3 _startposition = new Vector3(StartpositionObject.transform.position.x, StartpositionObject.transform.position.y, StartpositionObject.transform.position.z);
        Vector3 _startrotation = new Vector3(StartpositionObject.transform.rotation.x, StartpositionObject.transform.rotation.y+30, StartpositionObject.transform.rotation.z);
        transform.position = _startposition;
        transform.eulerAngles = _startrotation;
        targetLocation = GetWayPointGameObjectByName("BrakeToStartPosition");
        brakeForce = 850;
    }


    public List<GameObject> LoadingWaypoints(GameObject Waypoint)
    {
        List<GameObject> list = new List<GameObject>();
        for (int i = 0; i < Waypoint.transform.childCount; i++)
        {
            list.Add(Waypoint.transform.GetChild(i).gameObject);
        }
        return list;
    }


    private void CarAccelerating()
    {
        if (carRigid.velocity.magnitude <= targetSpeed)
        {
            //Debug.Log("FZ beschleunigt");
            WheelFR.motorTorque = motorForce;
            WheelFL.motorTorque = motorForce;
            
        }

        if (carRigid.velocity.magnitude > targetSpeed)
        { 
            WheelFR.motorTorque = 0;
            WheelFL.motorTorque = 0;
            accelerating = false;
            braking = true;
        }
    }

    private void CarBraking()
    {
        if (carRigid.velocity.magnitude >= targetSpeed)
        {  
            WheelFL.brakeTorque = brakeForce;
            WheelFR.brakeTorque = brakeForce;
        }

        if (carRigid.velocity.magnitude < targetSpeed && parking == false)
        {
            WheelFL.brakeTorque = 0;
            WheelFR.brakeTorque = 0;
            braking = false;
            accelerating = true;
        }

        if (carRigid.velocity.magnitude < targetSpeed && parking == true)
        {
     
            braking = false;
            accelerating = false;
        }
    }

    private void CarParking(float _parkingTime)
    {
        
        if (timer <= _parkingTime)
        {
            accelerating = false;
            braking = true;
            parking = true;
            timer += Time.deltaTime;
            //Debug.Log("parking");
        }

        if (timer > _parkingTime)
        {
            braking = false;
            accelerating = true;
            parking = false;
            timer = 0;
            targetSpeed = 50.0f / 3.6f;
            WheelFL.brakeTorque = 0;
            WheelFR.brakeTorque = 0;
    
        }
    }



    private void AutomatedSteering()
    { 
        Vector3 _relativeVector = carRigid.transform.InverseTransformPoint(targetLocation.transform.position);
        //_relativeVector = _relativeVector / _relativeVector.magnitude;
        float newSteer = (_relativeVector.x / _relativeVector.magnitude) * maxSteerAngle;
       
        WheelFL.steerAngle = newSteer;
        WheelFR.steerAngle = newSteer;
    }



    private void UpdateWheelPoses()
    {
        UpdateWheelPose(WheelFL, WheelTransformFL);
        UpdateWheelPose(WheelFR, WheelTransformFR);
        UpdateWheelPose(WheelRL, WheelTransformRL);
        UpdateWheelPose(WheelRR, WheelTransformRR);
    }

    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;
        
        _collider.GetWorldPose(out _pos, out _quat);
        _transform.position = _pos;
        _transform.rotation = _quat;
    }



        public void GetInput()
        {
            m_horizontalInput = Input.GetAxis("Horizontal");
            m_verticalInput = Input.GetAxis("Vertical");
            
            
        }

        private void ManualSteer()
        {
            m_steeringAngle = maxSteerAngle * m_horizontalInput;
            WheelFL.steerAngle = m_steeringAngle;
            WheelFR.steerAngle = m_steeringAngle;
        }

        private void Accelerate()
        {
            WheelFL.motorTorque = m_verticalInput * motorForce;
            WheelFR.motorTorque = m_verticalInput * motorForce;
        }



    }
