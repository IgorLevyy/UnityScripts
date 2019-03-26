using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opendoor : MonoBehaviour {


   // public GameObject Lamp1;
    public float smooth = 2.0f;
    public float angleOpened = 110.0f;
   // public float angleClosed = 90.0f;
    public bool open = false;

  //  public bool isActive = false;
    public static GameObject gameObjectForOpen = null;

        

    private Vector3 defaultRot;
    private Vector3 openRot;

  

    // public GameObject[] doorAll;


    // Use this for initialization
    void Start ()
    {
        gameObjectForOpen = gameObject;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Cursor.lockState == CursorLockMode.Locked && Input.GetMouseButtonDown(0) && gameObjectForOpen == gameObject)//&& isActive
        {
            GameObject gameObjectForRotate = GetRootRotateObject(gameObject, 5, "Door"); //GetRootRotateObject(gameObject, 10, "Door");
            float angle;
            if (!open)
            {
                angle = angleOpened;
            }
            else
            {
                angle = -angleOpened;
            }

            gameObjectForRotate.transform.rotation *= Quaternion.Euler(0f, angle, 0f);
           // Quaternion quaternionFrom = gameObjectForRotate.transform.rotation;
           // Quaternion quaternionTo = gameObjectForRotate.transform.rotation * Quaternion.Euler(0f, angle, 0f);
           //// gameObjectForRotate.transform.rotation = Quaternion.Lerp(quaternionFrom, quaternionTo, Time.deltaTime * smooth);
           // gameObjectForRotate.transform.rotation = Quaternion.RotateTowards(quaternionFrom, quaternionTo, Time.deltaTime * smooth);
            //print(string.Format("Rotate: open={0}, nameObject={1}, nameParent={2}", open, gameObject.name, gameObjectForRotate.name));
            open = !open;
          //  isActive = false;
        }
    }


    void OnGUI()
    {
        OperationsWithGameObject.LightObject(gameObject, gameObjectForOpen);

        if (gameObjectForOpen == gameObject)
        {
            
            //if(gameObjectForOpen != null) GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 200, 200, 30), gameObjectForOpen.name);
            //{
            //    GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 180, 200, 30), open.ToString());
            //}

            //if (open)
            //{
            //    GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 300, 30), "Нажмите 'F', чтобы закрыть дверь");             
            //}
            //else
            //{
            //   GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 70, 300, 30), "Нажмите 'F', чтобы открыть дверь");                              
            //}
            
        }
    }

    public GameObject GetRootRotateObject(GameObject gameObject, int maxLevelParent, string namePrefixRootRotateObject = "Door")
    {
        string message;
        if (gameObject.name.Substring(0, 4) == namePrefixRootRotateObject)
        {
            return gameObject;
        }
        else
        {
            if (maxLevelParent == 0)
            {
                message = "No root element '{0}' for GivenLevelRoot";
            }
            else if (gameObject.transform == null)
            {
                message = " gameObject.transform is NULL";
            }
            else if (gameObject.transform.parent == null)
            {
                message = " gameObject.transform.parent is NULL";
            }
            else if (gameObject.transform.parent.gameObject == null)
            {
                message = " gameObject.transform.parent.gameObject is NULL";
            }
            else
            {
                return GetRootRotateObject(gameObject.transform.parent.gameObject, maxLevelParent - 1, namePrefixRootRotateObject);
            }

            Debug.Log(message);
            print(message);
            return null;
        }

    }
}
