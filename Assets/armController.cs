using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armController : MonoBehaviour {

    public GameObject Base;
    public GameObject Shoulder;
    public GameObject Elbow;
    public GameObject Wrist;
    public GameObject Gripper;

    private Vector3 _baseHome;
    private Vector3 _shoulderHome;
    private Vector3 _elbowHome;
    private Vector3 _wristHome;
    private Vector3 _gripperHome;

    [Range( -180.0f, 180.0f)]
    public float BaseAngle;
    [Range(-180.0f, 180.0f)]
    public float ShoulderAngle;
    [Range(-180.0f, 180.0f)]
    public float ElbowAngle;
    [Range(-180.0f, 180.0f)]
    public float WristAngle;

    // Use this for initialization
    void Start () {
        _baseHome = Base.transform.localRotation.eulerAngles;
        _shoulderHome = Shoulder.transform.localRotation.eulerAngles;
        _elbowHome = Elbow.transform.localRotation.eulerAngles;
        _wristHome = Wrist.transform.localRotation.eulerAngles;
        _gripperHome = Gripper.transform.localRotation.eulerAngles;
    }
	
	// Update is called once per frame
	void Update () {
        updateArmAngles();
	}

    public void updateArmAngles()
    {
        Base.transform.localRotation = Quaternion.Euler(new Vector3(0, BaseAngle, 0) + _baseHome);
        Shoulder.transform.localRotation = Quaternion.Euler(new Vector3(0, ShoulderAngle, 0) + _shoulderHome);
        Elbow.transform.localRotation = Quaternion.Euler(new Vector3(0, ElbowAngle, 0) + _elbowHome);
        Wrist.transform.localRotation = Quaternion.Euler(new Vector3(0, WristAngle, 0) + _wristHome);
    }
}
