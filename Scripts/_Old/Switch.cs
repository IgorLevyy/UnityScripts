using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {


    public float smooth = 2.0f;
    public float angleOpened = 90.0f;

    public bool open = false;

    public static GameObject chosenGameObject;

        

    private Vector3 defaultRot;
    private Vector3 openRot;


    void Start ()
    {
        chosenGameObject = gameObject;
    }
	

	void Update ()
    {
        
        if (Cursor.lockState == CursorLockMode.Locked  && Input.GetMouseButtonDown(0) && chosenGameObject == gameObject)//&& isActive
        {
            print(string.Format("Rotate:"));
            GameObject gameObjectForRotate = GetKeyRotate(gameObject, "key");//GetRootRotateObject(gameObject, 10, "Switch");
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
            print(string.Format("Rotate: open={0}, nameObject={1}, nameParent={2}", open, gameObject.name, gameObjectForRotate.name));
            open = !open;
        }
    }


    void OnGUI()
    {
        OperationsWithGameObject.LightObject(gameObject, chosenGameObject);
        //OperationsWithGameObject.LightObject(gameObject.transform.parent.gameObject, chosenGameObject.transform.parent.gameObject);
        if (chosenGameObject == gameObject)
        {
            //if(gameObjectForOpen != null) GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 200, 200, 30), gameObjectForOpen.name);
            //{
            //    GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 180, 200, 30), open.ToString());
            //}

            //if (open)
            //{
            //    GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 70, 300, 30), "Нажмите 'F', чтобы выключить: " + gameObject.transform.GetChild(0).gameObject.name);             
            //}
            //else
            //{
            //    GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 70, 300, 30), "Нажмите 'F', чтобы включить: " + gameObject.transform.GetChild(0).gameObject.name);
            //}
            
        }
    }



    public GameObject GetKeyRotate(GameObject gameObject, string namePrefixKey = "key")
    {
        Transform transform = gameObject.transform;
        GameObject gameObjectChild;
        for (int i = 0; i < transform.childCount; i++)
        {
            gameObjectChild = transform.GetChild(i).gameObject;
            if (gameObjectChild.name == "key")
                return gameObjectChild;
        }
        return null;
    }   
 

    public GameObject GetRootRotateObject(GameObject gameObject, int maxLevelParent, string namePrefixRootRotateObject = "Switch")
    {
        string message;

        if (gameObject.name.Length > 5 && gameObject.name.Substring(0, 6) == namePrefixRootRotateObject)
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
