using System.Collections.Generic;
using UnityEngine;

public class BaseJsonParametrs
{
    public string ObjectName;
}

public class JsonParametersRotateGameObject : BaseJsonParametrs
{
    //public float Angle;
    public Vector3 Angle;
    public bool IsSpecific;
    public bool IsLocal;
}

public class JsonParametersShaderGameObject : BaseJsonParametrs
{
    public string shaderName;
}


public class JsonParametersLightGameObject : BaseJsonParametrs
{
    public bool IsLight;
}

public class JsonParametersPositionGameObject : BaseJsonParametrs
{
    public bool SetNew;
    public Vector3 Position;
}

public class UnityApiScript : MonoBehaviour
{



    //public void SetActiveObjectState(string objectName, string state)
    //{
    //    GameObject gameObject = GameObject.Find(objectName);
    //}

    //public void RotateGameObject(string objectName, float angle)
    //{
    //    GameObject gameObject = GameObject.Find(objectName);
    //    DoScript doScript = gameObject.GetComponent<DoScript>();

    //    doScript.Rotate(gameObject, angle);
    //}

    //public void RotateGameObject(string strJSONparameters)
    //{
    //    JsonParametersRotateGameObject jsonParametersRotateGameObject = JsonUtility.FromJson<JsonParametersRotateGameObject>(strJSONparameters);
    //    GameObject gameObject = GameObject.Find(jsonParametersRotateGameObject.ObjectName);
    //    // DoScript doScript = gameObject.GetComponent<DoScript>();
    //    // doScript.Rotate(gameObject, jsonParametersRotateGameObject.Angle);   

    //    gameObject.transform.rotation *= Quaternion.Euler(0f, jsonParametersRotateGameObject.Angle, 0f);
    //}

    public void RotateGameObject(string strJSONparameters)
    {
        JsonParametersRotateGameObject jsonParametersRotateGameObject = JsonUtility.FromJson<JsonParametersRotateGameObject>(strJSONparameters);
        GameObject gameObject = GameObject.Find(jsonParametersRotateGameObject.ObjectName);
        // DoScript doScript = gameObject.GetComponent<DoScript>();
        // doScript.Rotate(gameObject, jsonParametersRotateGameObject.Angle);   
        if (jsonParametersRotateGameObject.IsSpecific)
        {
            if (jsonParametersRotateGameObject.IsLocal)
            {
                gameObject.transform.localEulerAngles = jsonParametersRotateGameObject.Angle;
            }
            else
            {
                gameObject.transform.rotation *= Quaternion.Euler(jsonParametersRotateGameObject.Angle);
            }
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            gameObject.transform.rotation = Quaternion.Euler(jsonParametersRotateGameObject.Angle);
        }
       
    }

    public void LightGameObject(string strJSONparameters)
    {
        JsonParametersLightGameObject jsonParametersLightGameObject = JsonUtility.FromJson<JsonParametersLightGameObject>(strJSONparameters);
        GameObject gameObject = GameObject.Find(jsonParametersLightGameObject.ObjectName);
        Light light = (Light)gameObject.GetComponent("Light");
        light.enabled = jsonParametersLightGameObject.IsLight;
    }

    public void ChangeShader(string strJSONparameters)
    {
        JsonParametersShaderGameObject jsonParametersShaderGameObject = JsonUtility.FromJson<JsonParametersShaderGameObject>(strJSONparameters);
        GameObject gameObject = GameObject.Find(jsonParametersShaderGameObject.ObjectName);
        Shader shader = Shader.Find(jsonParametersShaderGameObject.shaderName);
        gameObject.GetComponent<Renderer>().material.shader = shader;
    }

    public void ChangePositionObject(string strJSONparameters)
    {
        JsonParametersPositionGameObject jsonParametersPositionGameObject = JsonUtility.FromJson<JsonParametersPositionGameObject>(strJSONparameters);
        GameObject gameObject = GameObject.Find(jsonParametersPositionGameObject.ObjectName);
        if (jsonParametersPositionGameObject.SetNew)
        {
            gameObject.transform.localPosition = jsonParametersPositionGameObject.Position;
        }
        else
        {
            gameObject.transform.localPosition += jsonParametersPositionGameObject.Position;
 
        }
        gameObject.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().enabled = true;



    }


    public void DestroyGameObject(string strJSONparameters)
    {
        BaseJsonParametrs jsonParametersHighGameObject = JsonUtility.FromJson<BaseJsonParametrs>(strJSONparameters);
        GameObject gameObject = GameObject.Find(jsonParametersHighGameObject.ObjectName);
        Destroy(gameObject);
    }

    public void CreateDialog(string strJsonDialog)
    {
        DialogData jsonDialog = JsonUtility.FromJson<DialogData>(strJsonDialog);
        DialogScript dialogScript = null;
        dialogScript = gameObject.GetComponent<DialogScript>();
        if(dialogScript == null)
        {
            dialogScript = gameObject.AddComponent<DialogScript>();
        }

        //dialogScript = gameObject.AddComponent<DialogScript>();
        dialogScript.CreateDialog(jsonDialog);
    }

    public void HighGameObject(string strJSONparameters)
    {
        BaseJsonParametrs jsonParametersHighGameObject = JsonUtility.FromJson<BaseJsonParametrs>(strJSONparameters);
        GameObject gameObject = GameObject.Find(jsonParametersHighGameObject.ObjectName);
        //gameObject.SetActive(false);
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<MeshCollider>().enabled = false;
    }

    public void UnHighGameObject(string strJSONparameters)
    {
        BaseJsonParametrs jsonParametersHighGameObject = JsonUtility.FromJson<BaseJsonParametrs>(strJSONparameters);
        GameObject gameObject = GameObject.Find(jsonParametersHighGameObject.ObjectName);
        gameObject.GetComponent<Renderer>().enabled = true;
        gameObject.GetComponent<MeshCollider>().enabled = true;
    }

    public void GetInventory(string[] gameObjects)
    {
        foreach (var gameObject in gameObjects)
        {

            GameObject gameObjectTarget = GameObject.Find(gameObject);
            Debug.Log(gameObjectTarget);

            Item item = GameObject.Find(gameObjectTarget.name).GetComponent<Item>();
            Debug.Log(item);
            Inventory inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
            Debug.Log(inventory);
            inventory.items.Insert(0, item);
        }

    }
    public void GetInventory(string gameObjectString)
    {
        //Debug.Log(gameObjectString);
        //string[] gameObjects = gameObjectString.Split(new char[] { '|' });
        //Debug.Log(gameObject);
        //foreach (var gameObject in gameObjects)
        //{
        //    GameObject gameObjectTarget = GameObject.Find(gameObject);
        //    Debug.Log(gameObjectTarget);
        //    Item item = GameObject.Find(gameObjectTarget.name).GetComponent<Item>();
        //    Debug.Log(item);
        //    Inventory inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        //    Debug.Log(inventory);
        //    inventory.items.Insert(0, item);
        //}
        Debug.Log(gameObjectString);
        string[] gameObjects = gameObjectString.Split(new char[] { '|' });
        Debug.Log(gameObject);
        foreach (var gameObject in gameObjects)
        {
            GameObject gameObjectTarget = GameObject.Find(gameObject);
            Debug.Log(gameObjectTarget);

            gameObjectTarget.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Renderer>().enabled = true;
            gameObjectTarget.transform.GetChild(0).GetChild(0).gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }
    public void AddItemInInventory(string gameObjectString)
    {
        Debug.Log(gameObjectString.ToString() + "1");
        //string[] gameObjects = gameObjectString.Split(new char[] { '|' });
        //Debug.Log(gameObject);
        //foreach (var gameObject in gameObjects)
        //{
        //    GameObject gameObjectTarget = GameObject.Find(gameObject);
        //    Debug.Log(gameObjectTarget);
        //    Item item = GameObject.Find(gameObjectTarget.name).GetComponent<Item>();
        //    Debug.Log(item);
        //    Inventory inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        //    Debug.Log(inventory);
        //    inventory.items.Insert(0, item);
        //}
        GameObject gameObjectTarget = GameObject.Find(gameObjectString + "1");
        Debug.Log(gameObjectTarget);
    }

    public void UseInventory(string gameObjectString)
    {

    }
}