using System.Collections;
using Newtonsoft.Json;
using System.Collections.Generic ;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using System;
using Newtonsoft.Json.Linq;


public class FetchAPI : MonoBehaviour
{

    public String url= "https://ga1vqcu3o1.execute-api.us-east-1.amazonaws.com/Assessment/stack";

    //public static FetchAPI instance;

    private void Awake()
    {
        /*        if(instance == null)
                {
                    instance = this;
                };*/
    }


    // Start is called before the first frame update
    void Start()
    {
        
        
        StartCoroutine(GetData("https://ga1vqcu3o1.execute-api.us-east-1.amazonaws.com/Assessment/stack"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator GetData(String uri)
    {
        
        using (UnityWebRequest webRequest= UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError("Something went wrong "+ webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    
                    JArray jArr= JArray.Parse(webRequest.downloadHandler.text);
                   
                    for(int i=0; i< jArr.Count; i++)
                    {
                        Tiles tmp= new(jArr[i]);
                        
                        TowerGenerator.AddTile(tmp);
                        //here, magic happens (we got all the data, we need to create jenga pieces)
                    }
                    TowerGenerator.StatisticsAndGenerate();
                    break;

            }
        }
        
    }
}
