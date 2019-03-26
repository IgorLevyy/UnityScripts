using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetPosition(string message)
    {
        Debug.Log("setposition");
        Debug.Log(message);
        //float[,] testmass1 = new float[3, 3];
        var testmass1 = JsonUtility.FromJson<TestCl>(message);
        Debug.Log(testmass1.title);
        Debug.Log(testmass1.mass[1, 2]);
    }

    public void TestCallBack(string message)
    {
        Application.ExternalCall(message);
       // Application.ExternalCall("ListenOnSR('guid')");
    }
}
