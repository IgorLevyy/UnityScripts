using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

	public void StartExcurs()
    {
        SceneManager.LoadScene("InstpectingKTP", LoadSceneMode.Single);
    }

    public void StartView()
    {
        SceneManager.LoadScene("CheckKTP", LoadSceneMode.Single);
    }

    public void StartPractic()
    {
        SceneManager.LoadScene("Practic", LoadSceneMode.Single);
    }



    public void StartByStr(string srt)
    {
        if(srt == "Practic")
            SceneManager.LoadScene("Practic", LoadSceneMode.Single);
        else if (srt == "CheckKTP")
            SceneManager.LoadScene("CheckKTP", LoadSceneMode.Single);
        else if (srt == "InstpectingKTP")
            SceneManager.LoadScene("InstpectingKTP", LoadSceneMode.Single);

    }
}
