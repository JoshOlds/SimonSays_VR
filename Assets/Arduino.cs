using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arduino : MonoBehaviour {
    private System.ComponentModel.IContainer components = null;

    private System.IO.Ports.SerialPort serialPort1;

    public GameObject RedButton;
    public GameObject GreenButton;
    public GameObject BlueButton;
    public GameObject YellowButton;

    public GameObject ArmControllerObject;
    private armController ArmController;

    // Use this for initialization
    void Start () {
        ArmController = ArmControllerObject.GetComponent<armController>();

        this.components = new System.ComponentModel.Container();

        this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
        this.serialPort1.PortName = "COM5";
        this.serialPort1.ReadTimeout = 1;
        this.serialPort1.BaudRate = 1000000;
        serialPort1.Open();
        Debug.Log("started port");

    }


    // Update is called once per frame
    void Update () {
        string data = ReadArduino();
        if(data != "")
        {
            processData(data);
        }
    }

    public void WriteArduino(string data)
    {
        if (serialPort1.IsOpen)
        {
            try
            {
                serialPort1.Write(data);
            }
            catch
            {
                Debug.Log("There was an error. Please make sure that the correct port was selected, and the device, plugged in.");
            }
        }
    }

    public string ReadArduino()
     {
        string data = "";

         //   if (serialPort1.IsOpen)
          //  {
                try
                {
                    if(serialPort1.BytesToRead > 16)
                    {
                        data = serialPort1.ReadLine();
                    }       
                    
                }
                catch
                {
                    
                }
          //  }
        return data;
    }

    public void processData(string data)
    {
        if(data[0].Equals('B'))
        {
            if(data[1].Equals('1'))
                YellowButton.GetComponent<ButtonClick>().animate();
            if (data[1].Equals('2'))
                BlueButton.GetComponent<ButtonClick>().animate();
            if (data[1].Equals('3'))
                RedButton.GetComponent<ButtonClick>().animate();
            if (data[1].Equals('4'))
                GreenButton.GetComponent<ButtonClick>().animate();
        }

        if(data.Contains("A,"))
        {
            Debug.Log(data);
            string[] stringList = data.Split(',');
            int pos1 = int.Parse( stringList[1]);
            int pos2 = int.Parse(stringList[2]);
            int pos3 = int.Parse(stringList[3]);
            int pos4 = int.Parse(stringList[4]);
            ArmController.BaseAngle = ((pos1 * 0.29f) - 500) * -1;
            ArmController.ShoulderAngle = (pos2 * 0.29f) - 500;
            ArmController.ElbowAngle = (pos3 * 0.29f) - 500;
            ArmController.WristAngle = (pos4 * 0.29f) - 500;
        }





    }
}
