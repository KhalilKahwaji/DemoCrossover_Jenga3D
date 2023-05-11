using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFocus : MonoBehaviour
{
    public GameObject tile6Container, tile7Container, tile8Container;
    public GameObject focusObject;

    public static GameObject infoImg;

    private float hspeed = 0.01f;
    private float vspeed = 2.0f;
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    float timeCounter;
    // Start is called before the first frame update
    void Awake()
    {
        focusObject = tile6Container;
        infoImg = GameObject.FindGameObjectWithTag("InfoMenu");
        infoImg.SetActive(false) ;
    }

    // Update is called once per frame
    void Update()
    {
        //timeCounter += Time.deltaTime;
        if (Input.GetMouseButton(0) && TowerGenerator.ready)
        {
            timeCounter += Time.deltaTime;
            yaw += hspeed*Input.GetAxis("Mouse X");
            //pitch -= vspeed * Input.GetAxis("Mouse Y");
            Vector3 oldPos = transform.position;
            transform.position = new Vector3(focusObject.transform.position.x +20*Mathf.Sin(timeCounter), 8f, focusObject.transform.position.z + 20*Mathf.Cos(timeCounter));
            transform.LookAt(focusObject.transform.GetChild(7).transform);
            
            
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    public void FocusChange(GameObject go)
    {
        focusObject = go;
    }

    public void TestMyStack()
    {
        for(int i=8; i<focusObject.transform.childCount; i++)
        {
            GameObject go = focusObject.transform.GetChild(i).gameObject;
            if (go.name.ToLower().Contains("glass"))
            {
                go.SetActive(false);
            }
            else
            {
                go.GetComponent<Rigidbody>().isKinematic=false;
            }
        }
    }
}
