using UnityEngine;


//using System.Collections;

public class Ladder : MonoBehaviour
{
    //public bool enter = true;
    private bool State1 = true;
    //private bool State2 = true;
    private bool State3 = false;

    private bool enter = true;
    private bool exit = false;

    private bool isPlayerIn;

    private void Start()
    {
        isPlayerIn = false;

    }
    void OnTriggerEnter()
    {
        isPlayerIn = true;
    }
    private int count = 0;

    private void Update()
    {
        
        if (isPlayerIn && Input.GetKeyDown(KeyCode.F))
        {

            count++;
            print(count);

            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Rigidbody rigidbody = player.GetComponent<Rigidbody>();
            LadderController ladderController = GameObject.FindGameObjectWithTag("Player").GetComponent<LadderController>();
            ladderController.LadderCollider = GetComponent<BoxCollider>();
            if (ladderController.enabled == false)
            {

                ladderController.enabled = true;
                player.GetComponent<Player>().enabled = false;
                rigidbody.useGravity = false;
            }
            else
            {
                ladderController.enabled = false;
                player.GetComponent<Player>().enabled = true;
                rigidbody.useGravity = true;
            }

            //State1;

            //GameObject.FindGameObjectWithTag("Player").GetComponent<FPSInputController>().enabled = State2;

            //State3;

        }
    }

    //private void OnGUI()
    //{
    //    if(enter)
    //    {
    //        GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height - 300, 800, 250), "");
    //        GUI.Label(new Rect(Screen.width / 2 - 350, Screen.height - 280, 700, 90), "Нажмите F для подъема по лестнице");
    //    }

    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(enter)
    //    {
    //        Debug.Log("Enter");
    //    }

    //}
   
    
    //void OnTriggerStay()
    //{
        

    //    if (Input.GetKeyDown(KeyCode.F))
    //    {

    //        count++;
    //        print(count);

    //        GameObject player = GameObject.FindGameObjectWithTag("Player");
    //        Rigidbody rigidbody = player.GetComponent<Rigidbody>();
    //        LadderController ladderController = GameObject.FindGameObjectWithTag("Player").GetComponent<LadderController>();
    //        ladderController.LadderCollider = GetComponent<BoxCollider>();
    //        if (ladderController.enabled == false)
    //        {
                
    //            ladderController.enabled = true;
    //            player.GetComponent<Player>().enabled = false;
    //            rigidbody.useGravity = false;
    //        }
    //        else
    //        {
    //            ladderController.enabled = false;
    //            player.GetComponent<Player>().enabled = true;
    //            rigidbody.useGravity = true;
    //        }
            
    //        //State1;

    //        //GameObject.FindGameObjectWithTag("Player").GetComponent<FPSInputController>().enabled = State2;
            
    //        //State3;

    //    }
    //}

    void OnTriggerExit()
    {
        isPlayerIn = false;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Rigidbody rigidbody = player.GetComponent<Rigidbody>();

        player.GetComponent<Player>().enabled = enter;
        //GameObject.FindGameObjectWithTag("Player").GetComponent<FPSInputController>().enabled = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<LadderController>().enabled = exit;
        rigidbody.useGravity = true;
    }
}

