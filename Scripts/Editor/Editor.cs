using System.Collections;
using UnityEngine;

[ExecuteInEditMode]
public class Editor : MonoBehaviour
{
    public bool Do = false;

    private void Update()
    {
        if (Do)
        {
            Do = false;
            DoMyWork();
        }
    }

    private void DoMyWork()
    {
        Debug.Log("Do in EditorWork");
        GameObject gObjectStolb = GameObject.Find("Stolb");
        GameObject gObjectCube = GameObject.Find("Cube");
        // GameObject.GetComponent

        // Material materialCube = gObjectCube.GetComponent<MeshRenderer>().material;

        //      Material materialStolb = gObjectStolb.GetComponent<MeshRenderer>().material;
        //      materialStolb.mainTexture = materialCube.mainTexture;

        Material myMaterial = Resources.Load("Пол1") as Material;
        Material metall4154 = Resources.Load("4154") as Material;
        
        // Material materialStolb = gObjectStolb.GetComponent<Renderer>().material;
        gObjectStolb.GetComponent<Renderer>().material = myMaterial;

        //GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Untagged");
        GameObject[] gameObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        foreach (GameObject item in gameObjects)
        {
            Renderer rendererItem = item.GetComponent<Renderer>();
            if (rendererItem == null)
                continue;
            Material matItem = rendererItem.material;
            if (matItem == null)
                continue;
            if (matItem.name == "Material #30 (Instance)") //matItem.name    "Material #40 (Instance)"   System.String
            {
                item.GetComponent<Renderer>().material = myMaterial;
   //             matItem = myMaterial;
            }
            if (matItem.name == "Material #39 (Instance) (Instance) (Instance)") //matItem.name    "Material #40 (Instance)"   System.String
            {
                item.GetComponent<Renderer>().material = metall4154;
                //             matItem = myMaterial;
            }

            if (matItem.name == "Material #66 (Instance) (Instance) (Instance)") //matItem.name    "Material #40 (Instance)"   System.String
            {
                item.GetComponent<Renderer>().material = metall4154;
                //             matItem = myMaterial;
            }

        }



        //foreach(GameObject.

            //Material materialStolb =   gObjectStolb.get  GetComponent<Material>();
            //      materialStolb = myMaterial;
            // gObjectStolb.te = myMaterial.mainTexture;

            //GetComponent().material
    }
}