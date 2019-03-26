using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Use1 : MonoBehaviour
{

    public int zoom = 20;
    public int normal = 60;
    public float smooth = 5;
    public GameObject gameObject;
    public GameObject gameObjectPrevPosition;
    public GameObject gameObjectLastPosition;
    public GameObject gameObjectForLight;
    private bool isUsed = false;

    private bool light = false;


   

    void Start()
    {
        //Debug.Log("ZOOM: " + camera.fieldOfView);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isUsed = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isUsed = false;
        }

        if (isUsed == true)
        {
            //gameObject.transform = Mathf.Lerp(0, zoom, Time.deltaTime * smooth);
            //gameObject.transform.position.Set(0,0, 5);
            //Debug.Log("USE");
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, mousePos, .1f);
            //gameObject.transform.position = Vector3.Lerp(gameObjectPrevPosition.transform.position, gameObject.transform.position, Time.deltaTime * smooth);

        }
        else
        {
            // camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, normal, Time.deltaTime * smooth);
           // gameObject.transform.position.Set(0, 0, 0);
            //Debug.Log("NOT_USE");

            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, gameObjectLastPosition.transform.position, Time.deltaTime * smooth);
        }


        //if (Input.GetKeyDown(KeyCode.M))
        //{
        //    if (!light)
        //    {
        //        Shader shader = Shader.Find("Custom/NewSurfaceShader");
        //        gameObjectForLight.GetComponent<Renderer>().material.shader = shader;
        //        light = !light;
        //    }
        //    else
        //    {
        //        Shader shader = Shader.Find("Standard");
        //        gameObjectForLight.GetComponent<Renderer>().material.shader = shader;
        //        light = !light;
        //    }
        //}

       
    }
}
