using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{

    //public int zoom = 20;
    //public int normal = 60;
    // public float smooth = 5;


    //private bool isZoomed = false;
    //
    //
    //private bool isZoomedUp = false;
    //private bool isZoomedDown = false;


    public Camera camera;

    private float zom;

    private int zoomed = 5;



    // Use this for initialization
    void Start()
    {
        //Debug.Log("ZOOM: " + camera.fieldOfView);
    }

    // Update is called once per frame
    void Update()
    {
        zom = Input.GetAxis("Mouse ScrollWheel");

        if (zom > 0)
        {
            cameraUp();
        }

        if (zom < 0)
        {
            cameraDown();
        }


        //if (Input.GetMouseButtonDown(1))
        //{
        //    isZoomed = true;
        //}
        //else if (Input.GetMouseButtonUp(1))
        //{
        //    isZoomed = false;
        //}

        //if (isZoomed == true)
        //{
        //    camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, zoom, Time.deltaTime * smooth);
        //
        //}
        //else
        //{
        //    camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, normal, Time.deltaTime * smooth);
        //}

        //if (isZoomedUp == true)
        //{
        //    camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, zoom1, Time.deltaTime * smooth);
        //    zoom1 += 5;
        //
        //}
        //if (isZoomedDown == true)
        //{
        //
        //    camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, zoom1, Time.deltaTime * smooth);
        //    if (zoom1 > normal)
        //    {
        //        zoom1 -= 5;
        //    }
        //
        //}

        // Debug.Log("ZOOM: " + camera.fieldOfView);
    }

    void cameraUp()
    {
        if (camera.fieldOfView > 5)
        {
            camera.fieldOfView -= zoomed;
        }

        //Debug.Log("ZOOM: " + camera.fieldOfView);
    }
    void cameraDown()
    {
        if (camera.fieldOfView < 60)
        {
            camera.fieldOfView += zoomed;
        }

        // Debug.Log("ZOOM: " + camera.fieldOfView);

    }
}