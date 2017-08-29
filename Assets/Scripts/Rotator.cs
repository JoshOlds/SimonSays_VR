using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    public Transform tf;

    public Vector3 rotation;

    // Use this for initialization
    void Start () {
        tf = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {

        tf.Rotate(rotation);
	}
}
