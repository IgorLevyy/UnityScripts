using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {
    public Transform RaycastS;
    private RaycastHit Hit;
    public static string Type;
   // public GameObject thePrefab;

    private GameObject[] targetAll;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 Direction = RaycastS.TransformDirection(Vector3.forward);
        if (Physics.Raycast(RaycastS.position, Direction, out Hit, 1000f))
        {

            if (Hit.collider.tag == "target")
            {
                if (Input.GetKeyDown(KeyCode.N))
                {
                    print(Hit.collider.transform.rotation);
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    GameObject thePrefab = null;

                    if (Type == "Table")
                    {
                       thePrefab = GameObject.Find("Table1 (1) new");
                    }
                    else if(Type == "Ladder")
                    {
                        thePrefab = GameObject.Find("Ladder123");
                    }


                   // //Создание пустого объекта....
                   // GameObject emptyObject = new GameObject("EmptyObject");
                   // //emptyObject.transform.position.Normalize();
                   // emptyObject.transform.parent = Hit.collider.gameObject.transform;
                   //// emptyObject.transform.position.Normalize();
                   // emptyObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                   // emptyObject.transform.localPosition = new Vector3(0, 0, 0);

                   



                    Quaternion newRotation = new Quaternion(180.0f, 0.0f, 0.0f, 0.0f);
                    Vector3 newPosition = new Vector3(Hit.collider.gameObject.transform.position.x, Hit.collider.gameObject.transform.position.y, Hit.collider.gameObject.transform.position.z - 0.048f);
                    //print("Лестница поставлена");
                    GameObject instance = new GameObject();
                    instance = Instantiate(thePrefab,
                                           newPosition,
                                           newRotation) as GameObject;

                    
                    instance.transform.parent = Hit.collider.gameObject.transform.GetChild(0).gameObject.transform;

                    instance.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                    instance.transform.localPosition = new Vector3(0, 0, 0);

                    targetAll = GameObject.FindGameObjectsWithTag("target");
                    foreach (GameObject target in targetAll)
                    {
                        //door.GetComponent<Animation>().Play("OpenDoor");
                        target.GetComponent<Renderer>().material.shader = Shader.Find("Standard");
                    }
                    GetComponent<Target>().enabled = false;
                }
                //Using1 usingScript = Hit.collider.gameObject.GetComponent<Using1>();
                //if (usingScript)
                //{
                //    Using1.gameObjectForShader = Hit.collider.gameObject;
                //}
                //print("Teestesaesae");

                
            }



        }
    }
}
