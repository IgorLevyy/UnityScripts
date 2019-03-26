using EProjectNS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enviropment// : MonoBehaviour
{
    public int id;
    public string name;
    public string description;
    public int count;
    public float mass;
    public Texture2D texture;
    public string bundleURL;
    public string skyboxMaterial;
}

public class ChoiceEnviropment : MonoBehaviour
{
    public bool show = false;
    public GUISkin skin;
    public Font font;

    public List<Enviropment> elements = new List<Enviropment>();
    public float maxMass = 50f;
    public float currMass = 0f;
    [HideInInspector] public Enviropment currItem;
    Vector2 scrollPosition;
    

    void Start()
    {
        var el1 = new Enviropment
        {
            id = 1,
            name = "Assets/Environment/Environment_field.prefab",
            description = "Окружение - поле",
            texture = new Texture2D(128, 128),
            bundleURL = 
            //"AssetBundles/field",
            "D:/Training3dProjects/Training_v7/Assets/AssetBundles/field",
            skyboxMaterial = "skybox/skybox2"
        };
        var el2 = new Enviropment
        {
            id = 2,
            name = "Assets/Environment/Environment_city.prefab",
            description = "Окружение - город",
            texture = new Texture2D(128, 128),
            bundleURL = 
            //"AssetBundles/city",
            "D:/Training3dProjects/Training_v7/Assets/AssetBundles/city",
            skyboxMaterial = "skybox/skybox7"
        };
               
        elements.Add(el1);
        elements.Add(el2);
        RebuilMase();
        show = true;
    }

    void AddMass(float mass)
    {
        currMass += mass;
    }

    void RebuilMase()
    {
        currMass = 0f;
        for (int i = 0; i < elements.Count; i++)
        {
            if (elements[i] != null)
            {
                if (elements[i].count > 0)
                {
                    currMass += elements[i].count * elements[i].mass;
                }
            }
        }
    }

    void Update()
    {

    }

    void OnGUI()
    {
        if (show)
        {
            MouseLook scriptMouseLook = GameObject.Find("Player").GetComponent<MouseLook>();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            scriptMouseLook.enabled = false;

            GUI.skin = skin;
            GUI.skin.font = font;
            GUI.Window(0, new Rect(Screen.width / 3, Screen.height / 3, 500, 100), EnviropmentBody, "Выберите окружение");
        }
    }


    public void Use(Enviropment item)
    {
        item.count--;
        RemoveElement(item);
        currItem = null;
    }

    public void RemoveElement(Enviropment item)
    {
        for (int i = 0; i < elements.Count; i++)
        {
            if (elements[i] == item)
            {
                elements[i] = null;
            }
        }
    }

    void EnviropmentBody(int id)
    {
        scrollPosition = GUILayout.BeginScrollView(
           scrollPosition, GUILayout.Width(Screen.width/4), GUILayout.Height(Screen.height/4));

        for (int i = 0; i < elements.Count; i++)
        {
            if (elements[i] != null)
            {
                if (GUILayout.Button(elements[i].description))
                {

                    MouseLook scriptMouseLook = GameObject.Find("Player").GetComponent<MouseLook>();
                    scriptMouseLook.enabled = true;
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;

                    currItem = elements[i];
                    show = false;
                    Material m_Material = Resources.Load<Material>(elements[i].skyboxMaterial);
                    RenderSettings.skybox = m_Material;

                    GameObject AssetManager = GameObject.Find("AssetManager");
                    NonCachingLoadExample NonCachingLoadExample = AssetManager.GetComponent<NonCachingLoadExample>();
                    AddAssetParameter addAssetParameter = new AddAssetParameter
                    {
                        bundleURL = currItem.bundleURL,
                        assetName = currItem.name
                    };

                    string json1 = JsonUtility.ToJson(addAssetParameter);
                    NonCachingLoadExample.LoadAsset(json1);

                    currItem = null;

                }

            }
            else
            {
                GUILayout.Box("", GUILayout.Width(100f), GUILayout.Height(100f));
            }

        }

        GUILayout.EndScrollView();
    }
}
