using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OperationsWithGameObject:MonoBehaviour
{
    public static GameObject GetRootRotateObject(GameObject gameObject, int maxLevelParent, string namePrefixRootRotateObject = "Door")
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
                return GetRootRotateObject(gameObject.transform.parent.gameObject, -1, namePrefixRootRotateObject);
            }

            Debug.Log(message);
            print(message);
            return null;
        }

    }

    public static void LightObject (GameObject gameObject, GameObject choseNameGameObject)
    {
        if(gameObject != choseNameGameObject)
        {
            //gameObject.GetComponent<Renderer>().material.shader = Shader.Find("Custom/NewSurfaceShader");
            //gameObject.GetComponent<Renderer>().material.shader = Shader.Find("Basic Outline");
            //Shader shader = Shader.Find("Custom/NewSurfaceShader");
            Shader shader = Shader.Find("Standard");
            gameObject.GetComponent<Renderer>().material.shader = shader;
        }
        else
        {
            Shader shader = Shader.Find("Custom/NewSurfaceShader");// Outlined/Silhouetted Diffuse");
            //Shader shader = gameObject.GetComponent<Renderer>().material.shader = Shader.Find("Basic Outline");
            //shader = Shader.Find("Standard");
            gameObject.GetComponent<Renderer>().material.shader = shader;
            //gameObject.GetComponent<Renderer>().material.shader = Shader.Find("Custom/contur"); //"Custom/NewSurfaceShader");
        }              
    }
}
