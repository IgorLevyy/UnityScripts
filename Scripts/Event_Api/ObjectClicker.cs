using EProjectNS;
using System;
using UnityEngine;

public class ObjectClicker : MonoBehaviour
{
    public static GameObject chosenGameObject = null;

    void Start()
    {
        //Debug.Log("132");
        chosenGameObject = gameObject;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            GameObject mainCamera = GameObject.Find("Main Camera");
            //GameObject.Find("MainCamera").GetComponent<Camera>();

            //Vector3 Direction = RaycastS.TransformDirection(Vector3.forward);
            //if (Physics.Raycast(RaycastS.position, Direction, out Hit, 1000f))


            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Transform RaycastS = mainCamera.transform;
            //if (Physics.Raycast(ray, out hit, 100.0f) && hit.transform != null)
            Vector3 Direction = RaycastS.TransformDirection(Vector3.forward);
            if (Physics.Raycast(RaycastS.position, Direction, out hit, 1000f) && hit.transform != null)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    GameObject gameObjectUnityApi = GameObject.Find("Inventory");
                    Inventory inventoryScript = gameObjectUnityApi.GetComponent<Inventory>();
                    string invName = "Не определен";

                    InitSceneScript scriptSetActive = GameObject.Find("Player").GetComponent<InitSceneScript>();
                    EProject eProject = scriptSetActive.eProject;

                    if (eProject.InventoryItemCurrent != null && eProject.InventoryItemCurrent.Title != null)
                    {
                        invName = eProject.InventoryItemCurrent.Title;
                    }

                    Addlog(hit.transform.gameObject, invName);

                    Actions.currentInventory = invName;
                    Actions.currentObject = hit.transform.gameObject.name;

#warning править хардкорд удаления
                    //if (hit.transform.gameObject.transform.parent.parent.name == "Лестница Твердое тело1 1087"
                    //    || hit.transform.gameObject.transform.parent.parent.name == "Табличка <Не включать, работают люди> SRF3 2")
                    //{
                    //    GameObject.Destroy(hit.transform.gameObject.transform.parent.parent.gameObject);
                       
                    //}


                    if (Actions.currentObject != string.Empty && Actions.objectClickList.inventoryItems.Count != 0)
                    {
                        foreach (InventoryItem inventoryItem in Actions.objectClickList.inventoryItems)//InventoryItem определяется при выборе инвентаря
                        {
                            if (inventoryItem.inventoryName == Actions.currentInventory)
                            {
                                foreach (Option option in inventoryItem.options)
                                {
                                    if (option.targetObject == Actions.currentObject)
                                    {
                                        if (option.actions.Count == 1)
                                        {
                                            Actions.DoAction(option.actions[0]);
                                        }
                                        else
                                        {
                                            Actions.option = option;
                                            Actions.showAction = true;
                                        }
                                        
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                    }
                }
            }
        }
    }

    private void Addlog(GameObject gameObject, string inventoryName)
    {
        var mainCamera = GameObject.Find("UnityAPI");
        Logging log = mainCamera.GetComponent<Logging>();
        if (inventoryName == String.Empty)
        {
            log.logs.Add(new LogElement
            {
                dataTime = DateTime.Now,
                name = "Клик по объекту " + gameObject.name,
                objName = gameObject.name,
                timeExecution = "none"
            });
        }
        else
        {
            log.logs.Add(new LogElement
            {
                dataTime = DateTime.Now,
                name = "Клик по объекту " + gameObject.name + " инструментом <" + inventoryName + ">",
                objName = gameObject.name,
                timeExecution = "none"
            });
        }
        
    }
}