using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour {

    public GameObject RedButton;
    public GameObject GreenButton;
    public GameObject BlueButton;
    public GameObject YellowButton;
    public GameObject Arduino;
    private Arduino _arduino;

    // Use this for initialization
    void Start()
    {
        _arduino = Arduino.GetComponent<Arduino>();
    }
    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log( gameObject.name + ": I collided with: ");
        //Debug.Log(other.name);

        if(other.gameObject == RedButton)
        {
            other.gameObject.GetComponent<ButtonClick>().animate();
            _arduino.WriteArduino("3");
            //_arduino.WriteArduino("0");

        }

        if (other.gameObject == BlueButton)
        {
            other.gameObject.GetComponent<ButtonClick>().animate();
            _arduino.WriteArduino("2");
           // _arduino.WriteArduino("0");


        }
        if (other.gameObject == YellowButton)
        {
            other.gameObject.GetComponent<ButtonClick>().animate();
            _arduino.WriteArduino("1");
            //_arduino.WriteArduino("0");


        }
        if (other.gameObject == GreenButton)
        {
            other.gameObject.GetComponent<ButtonClick>().animate();
            _arduino.WriteArduino("4");
            //_arduino.WriteArduino("0");


        }
    }
}
