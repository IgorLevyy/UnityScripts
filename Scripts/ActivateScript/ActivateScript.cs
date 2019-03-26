using EProjectNS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateScript : MonoBehaviour {

    public delegate void ClickActiveObjectEventHandler(string objectId, string subjectId);
    public static event ClickActiveObjectEventHandler ClickActiveObjectEvent;

    public bool isActiveLite = true;
    public static GameObject chosenGameObject = null;

  
    void Start ()
    {
        chosenGameObject = gameObject;
    }
	
	// Update is called once per frame
	virtual protected void Update ()
    {
        if (Cursor.lockState == CursorLockMode.Locked && Input.GetMouseButtonDown(0) && chosenGameObject == gameObject)//&& isActive
        {
            GameObject gameObjectPlayer = GameObject.Find("Player");
            InitSceneScript initSceneScript = gameObjectPlayer.GetComponent<InitSceneScript>();
            EProject eProject = initSceneScript.eProject;

            //if (eProject.InventoryItemCurrent != null && StartInventoryEvent != null)
            //{
            //    StartInventoryEvent(gameObject.name, eProject.InventoryItemCurrent.Id, open.ToString());
            //    eProject.InventoryItemCurrent = null;
            //}

            if (ClickActiveObjectEvent != null)
            {
                string subject = "";
                if (eProject.InventoryItemCurrent != null)
                {
                    subject = eProject.InventoryItemCurrent.Title;
                }
                ClickActiveObjectEvent(gameObject.name, subject);
            }
           
        }
    }

    virtual protected void OnGUI()
    {
        if (!isActiveLite)
        {
            return;
        }
        OperationsWithGameObject.LightObject(gameObject, chosenGameObject);
    }

}
