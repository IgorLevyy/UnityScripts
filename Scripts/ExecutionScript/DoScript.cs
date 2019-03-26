using EProjectNS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoScript : MonoBehaviour {

    public float angleOpened = 110.0f;

    public bool isActivated = false;

    void Start()
    {
    }

    public void Rotate(GameObject gameObject, float angle)
    {
        //GameObject gameObjectForRotate = GetRootRotateObject(gameObject, 5, "Door"); //GetRootRotateObject(gameObject, 10, "Door");
        // gameObjectForRotate.transform.rotation *= Quaternion.Euler(0f, angle, 0f);


        gameObject.transform.rotation *= Quaternion.Euler(0f, angle, 0f);
        // Quaternion quaternionFrom = gameObjectForRotate.transform.rotation;
        // Quaternion quaternionTo = gameObjectForRotate.transform.rotation * Quaternion.Euler(0f, angle, 0f);
        //// gameObjectForRotate.transform.rotation = Quaternion.Lerp(quaternionFrom, quaternionTo, Time.deltaTime * smooth);
        // gameObjectForRotate.transform.rotation = Quaternion.RotateTowards(quaternionFrom, quaternionTo, Time.deltaTime * smooth);
        //print(string.Format("Rotate: open={0}, nameObject={1}, nameParent={2}", open, gameObject.name, gameObjectForRotate.name));
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
