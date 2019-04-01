using EProjectNS;
using System.Collections.Generic;
using UnityEngine;


public class TablesScript : MonoBehaviour
{
    public Vector3 localRotation;
    public Vector3 localPosition;
    public List<string> inventoryName;
    private bool light = false;

    void Start()
    {
    }

    void Update()
    {
        if (light)
        {
            Shader shader = Shader.Find("Custom/NewSurfaceShader");
            gameObject.GetComponent<Renderer>().material.shader = shader;

        }
        else
        {
            Shader shader = Shader.Find("Standard");
            gameObject.GetComponent<Renderer>().material.shader = shader;

        }
    }

    void OnMouseEnter()
    {
        //Debug.Log(gameObject);
        InitSceneScript scriptSetActive = GameObject.Find("Player").GetComponent<InitSceneScript>();
        EProject eProject = scriptSetActive.eProject;
        EProjectNS.InventoryItem curItem = eProject.InventoryItemCurrent;

        if (curItem != null)
        {
            if(inventoryName.Contains(curItem.Title))
                light = true;
        }
    }
    void OnMouseExit()
    {
        //Debug.Log(gameObject);
        light = false;

    }
}

