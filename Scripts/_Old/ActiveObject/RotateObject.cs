using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class TestCl
{
    public string title;
    public string date;
    public float[,] mass;
}
public class RotateObject : MonoBehaviour
{
    public GameObject cubik;

    public float speeds = 600;
    private float X, Y, Z;
    private bool RotateObj = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit_1;
            Ray _ray;
            _ray = Camera.allCameras[0].ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(_ray, out hit_1))
            {
                //Debug.Log(hit_1.collider.tag);
                //if (hit_1.distance <= 1f)
                {
                    if (hit_1.collider.tag == "RotationObject") // Проверяем то ,что вернулось
                    {
                        RotateObj = true;
                    }
                }
            }
        }

        if (RotateObj)
        {
            X += Input.GetAxis("Mouse X") * speeds * Time.deltaTime;
            Y += Input.GetAxis("Mouse Y") * speeds * Time.deltaTime;
            //Z += (float)System.Math.Sin(Input.GetAxis("Mouse X")) * speeds * Time.deltaTime;

            transform.rotation = Quaternion.Euler(Y - 90, X, 0);
        }

        if (RotateObj && Input.GetMouseButtonUp(1))
        {
            RotateObj = false;
            
            //int[] array1 = new int[] { 1, 3, 5, 7, 9 };
            //string json = JsonUtility.ToJson(array1);
            //Debug.Log(json);
            //float[,] testmass1 = new float[3, 3];
        }
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
    }
}
