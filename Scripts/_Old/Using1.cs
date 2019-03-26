using UnityEngine;
using System.Collections;

public class Using1 : MonoBehaviour {
	public static bool isActive = false;
    public static GameObject gameObjectForShader;
 
    // Use this for initialization
    void Start () {
       // gameObjectForShader = gameObject;
    }
	
	// Update is called once per frame
	void Update () 
	{
        if(gameObjectForShader != null)
        {
            if (isActive)
            {
                //gameObject.GetComponent<Renderer>().material.shader = Shader.Find("Custom/NewSurfaceShader");
                gameObjectForShader.GetComponent<Renderer>().material.shader = Shader.Find("Custom/NewSurfaceShader");
                //Debug.Log("Test");

                //Debug.Log(gameObject.GetComponent<Renderer>().materials);
                //if (Input.GetKey(KeyCode.F))
                //{
                //    gameObjectForShader.transform.eulerAngles = Vector3.Slerp(gameObjectForShader.transform.eulerAngles, openRot, Time.deltaTime * smooth);
                //}
                //if (Input.GetKey(KeyCode.G))
                //{
                //    gameObjectForShader.transform.eulerAngles = Vector3.Slerp(-gameObjectForShader.transform.eulerAngles, -openRot, Time.deltaTime * smooth);
                //}

            }
            else
            {
                gameObjectForShader.GetComponent<Renderer>().material.shader = Shader.Find("Standard");
                //Debug.Log("Test123321");
            }
        }
		
    }
}
