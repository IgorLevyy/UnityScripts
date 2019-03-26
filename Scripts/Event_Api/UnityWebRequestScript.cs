using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System;
using System.Text;

public class UnityWebRequestScript : MonoBehaviour
{
    //https://habr.com/ru/post/433366/
    public string UrlServer;
    public void PostWebRequest(string methodName, Dictionary<string, string> formFields)
    {
        string url = UrlServer + "/" + methodName;
        StartCoroutine(CoroutinePostWebRequest(url, formFields));
    }

    public void PostWebRequest(string methodName, string data)
    {
        string url = UrlServer + "/" + methodName;
        StartCoroutine(CoroutinePostWebRequest(url, data));
    }

    IEnumerator CoroutinePostWebRequest(string url, Dictionary<string, string> formFields)
    {
       // List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
      //  formData.Add(new MultipartFormDataSection("field1=foo&field2=bar"));
       // formData.Add(new MultipartFormFileSection("my file data", "myfile.txt"));

        UnityWebRequest request = UnityWebRequest.Post(url, formFields); // "http://www.my-server.com/myform", formData);
        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
        string strResponse = request.downloadHandler.text;
        Debug.Log(strResponse);

        //var data = JsonUtility.FromJson<T>(strResponse);
        //здесь T тип данных, которые хранятся в строке
    }

    IEnumerator CoroutinePostWebRequest(string url, string data)  // Отправка данных в виде json
    {
        var request = new UnityWebRequest(url, UnityWebRequest.kHttpVerbPOST)
        {
            uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(data)),
            downloadHandler = new DownloadHandlerBuffer()
        };
        request.uploadHandler.contentType = "application/json";

        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
        string strResponse = request.downloadHandler.text;
        Debug.Log(strResponse);

        //var data = JsonUtility.FromJson<T>(strResponse);
        //здесь T тип данных, которые хранятся в строке
    }

    //private IEnumerator WebRequestPost(string url, string data, Action<float> progress, Action<UnityWebRequest> response)
    //{
    //    var request = new UnityWebRequest(url, UnityWebRequest.kHttpVerbPOST)
    //    {
    //        uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(data)),
    //        downloadHandler = new DownloadHandlerBuffer()
    //    };

    //    request.uploadHandler.contentType = "application/json";

    //    return WebRequest(request, progress, response);
    //}


    //private IEnumerator WebRequest(UnityWebRequest request, Action<float> progress, Action<UnityWebRequest> response)
    //{
    //    while (!Caching.ready)
    //    {
    //        yield return null;
    //    }

    //    if (progress != null)
    //    {
    //        request.SendWebRequest(); _currentRequests.Add(request);

    //        while (!request.isDone)
    //        {
    //            progress(request.downloadProgress);

    //            yield return null;
    //        }

    //        progress(1f);
    //    }
    //    else
    //    {
    //        yield return request.SendWebRequest();
    //    }

    //    response(request);

    //    if (_currentRequests.Contains(request))
    //    {
    //        _currentRequests.Remove(request);
    //    }

    //    request.Dispose();
    //}



    //public string PostWebRequestAsync(string url, string username, string password)
    //{
    //    WebClient client = new WebClient();

    //    // This specialized key-value pair will store the form data we're sending to the server
    //    var loginData = new System.Collections.Specialized.NameValueCollection();
    //    loginData.Add("Username", username);
    //    loginData.Add("Password", password);

    //    // Upload client data and receive a response
    //    byte[] opBytes = client.UploadValues(ServerIpAddress, "POST", loginData);

    //    // Encode the response bytes into a proper string
    //    string opResponse = Encoding.UTF8.GetString(opBytes);

    //    return opResponse;
    //}


    //public class UIManager : MonoBehaviour
    //{
    //    public InputField output;

    //    public void SaveStrOnClick()
    //    {
    //        StartCoroutine("SaveStr");
    //    }

    //    IEnumerator SaveStr()
    //    {
    //        WWWForm form = new WWWForm();
    //        form.AddField("str", "Hello");
    //        WWW www = new WWW("http://dev3dapps.freeoda.com/unity/Polyglot/database.php", form);
    //        yield return www;
    //        output.text = www.text;
    //    }
    //}


}