using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class AddAssetParameter
{
    public string bundleURL;
    public string assetName;
    public float x;
    public float y;
    public float z;
    public float rotationX;
    public float rotationY;
    public float rotationZ;
    public float scaleX;
    public float scaleY;
    public float scaleZ;
}

class NonCachingLoadExample : MonoBehaviour
{
    public string BundleURL;
    public string AssetName;
    public int count;
    public float step;
    public int version;


    IEnumerator AddAssetCoroutine(AddAssetParameter addAssetParameter)
    {
        // Download the file from the URL. It will not be saved in the Cache
        using (UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(addAssetParameter.bundleURL))  //WWW www = new WWW(addAssetParameter.bundleURL)
        {
            yield return www.SendWebRequest();
            if (www.error != null)
                throw new Exception("WWW download had an error:" + www.error);
            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);

            // if(AssetName == "")
            //     Instantiate(bundle.mainAsset);
            //else
            UnityEngine.Object obj = Instantiate(bundle.LoadAsset(addAssetParameter.assetName));
            GameObject gObj = (GameObject)obj;
            gObj.transform.position += Vector3.right * 2;


            // Unload the AssetBundles compressed contents to conserve memory
            bundle.Unload(false);

        } // memory is freed from the web stream (www.Dispose() gets called implicitly)
    }

    public void LoadAsset(string strAddAssetParameter)
    {
        string str = Application.dataPath;
        AddAssetParameter addAssetParameter = JsonUtility.FromJson<AddAssetParameter>(strAddAssetParameter);
        StartCoroutine(AddAssetCoroutine(addAssetParameter));
    }

   
}