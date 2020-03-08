using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public class JSONLoader : MonoBehaviour
{
    public string URL;
    public JSONNode jsonObj = null;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RequestAPI(URL));
    }

    protected virtual void ParseJSON(string jsonStr)
    {
        jsonObj = JSON.Parse(jsonStr);

    }

    protected virtual IEnumerator RequestAPI(string WebURL)
    {
        using (UnityWebRequest Request = UnityWebRequest.Get(WebURL))
        {
            yield return Request.SendWebRequest();


            string[] pages = WebURL.Split('/');
            int page = pages.Length;

            if (Request.isNetworkError)
            {
                Debug.Log(pages[page] + "Error" + Request.error);
                yield break;
            }

            //ParseJSON
            ParseJSON(Request.downloadHandler.text);
        }
    }

}
