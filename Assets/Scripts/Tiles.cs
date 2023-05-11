using Newtonsoft.Json.Linq;
using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Tiles :MonoBehaviour
{
   

    public int id;
    public string subject;
    public string grade;
    public int mastery;
    public string domainId;
    public string domain;
    public string cluster;
    public string standardId;
    public string standardDescription;
    public string priority;
    public JToken json;
    public string tileString;

    public UnityEvent unityEvent= new UnityEvent();
    public GameObject btn;

    [SerializeField]
    public GameObject glasstilePrefab;

    [SerializeField]
    public GameObject woodentilePrefab;

    [SerializeField]
    public GameObject stonetilePrefab;

    public Tiles() { }
    public Tiles(JToken jobj)
    {
        this.id = (int)jobj["id"];
        this.subject = jobj["subject"].ToString();
        //this.grade is int:: (fail)
        /*string str= jobj["grade"].ToString();
        this.grade = (int)str[0];*/
        this.grade = jobj["grade"].ToString();


        this.mastery = (int)jobj["mastery"];
        this.domainId = jobj["domainid"].ToString();
        this.domain = jobj["domain"].ToString();
        this.cluster = jobj["cluster"].ToString();
        this.standardId = jobj["standardid"].ToString();
        this.standardDescription = jobj["standarddescription"].ToString();
        this.json = jobj;
        

        this.priority = domain + cluster + standardId;
        tileString = this.ToString();
    }




    private void Awake()
    {
        btn = this.gameObject;

       
    }


    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(1))
        {
            if(Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                Debug.Log("fa2ast!");
                CamFocus.infoImg.SetActive(true);
                CamFocus.infoImg.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = this.tileString;
            } 
        }
    }



    public override string ToString()
    {
        return "-"+grade + " : " + domain + "\n-" + cluster + " \n-" + standardId + " : " + standardDescription; 
    }

   


}



