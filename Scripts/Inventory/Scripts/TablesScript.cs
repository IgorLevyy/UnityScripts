using EProjectNS;
using UnityEngine;


public class TablesScript : MonoBehaviour
{
    public Vector3 localRotation;
    public Vector3 localPosition;
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

        if (eProject.InventoryItemCurrent != null)
        {
            light = true;
        }
    }
    void OnMouseExit()
    {
        //Debug.Log(gameObject);
        light = false;

    }
}

