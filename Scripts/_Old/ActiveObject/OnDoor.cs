using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDoor : MonoBehaviour {

    public delegate void StartInventoryEventHandler();
    public delegate void ClickActiveObjectEventHandler(string objectId, string subjectId, string state);

    public static event StartInventoryEventHandler StartInventoryEvent;
    public static event ClickActiveObjectEventHandler ClickActiveObjectEvent;


    public float angleOpened = 110.0f;

    public bool open = false;

    public bool isActiveLite = true;
    public static GameObject chosenGameObject = null;

    private Vector3 defaultRot;
    private Vector3 openRot;

  

    // public GameObject[] doorAll;


    // Use this for initialization
    void Start ()
    {
        chosenGameObject = gameObject;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Cursor.lockState == CursorLockMode.Locked && Input.GetMouseButtonDown(0) && chosenGameObject == gameObject)//&& isActive
        {

            //if(StartInventoryEvent != null)
            //{
            //    StartInventoryEvent();
            //}

            //if (ClickActiveObjectEvent != null)
            //{
            //    ClickActiveObjectEvent(gameObject.name, "11111", open.ToString());
            //}

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
        }
    }


    void OnGUI()
    {
        if (!isActiveLite)
        {
            return;
        }
        OperationsWithGameObject.LightObject(gameObject, chosenGameObject);
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
