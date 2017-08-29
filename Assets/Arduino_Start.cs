using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arduino_Start : MonoBehaviour {
    private System.ComponentModel.IContainer components = null;

    private System.IO.Ports.SerialPort serialPort1;

    // Use this for initialization
    void Start () {
        this.components = new System.ComponentModel.Container();

        this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
        this.serialPort1.PortName = "COM3";
    }

    // Update is called once per frame
    void Update () {
		
	}
}
