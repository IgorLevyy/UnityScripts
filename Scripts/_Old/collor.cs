using UnityEngine;
using System.Collections;

public class collor : MonoBehaviour {
    //Color color;
	
	void OnMouseEnter()
	{
        //color = GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().materials[0].shader = Shader.Find("Toon/Basic Outline");
        //GetComponent<Renderer>().material.color = Color.green;
		
	}
	void OnMouseExit()
	{
		//GetComponent<Renderer>().material.color = color;
        GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");

    }
}
	
	