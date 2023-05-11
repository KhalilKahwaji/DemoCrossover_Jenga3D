using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class TowerGenerator : MonoBehaviour
{
    public  GameObject tile6Container, tile7Container, tile8Container;
    public List<GameObject> clones;
    public static TowerGenerator instance;
    public static bool ready = false;


    private void Awake()
    {
        
        if(instance== null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        //Debug.Log("instance>??? " + instance);

    }
    private static PriorityQueue jengaTower6= new PriorityQueue();
    private static PriorityQueue jengaTower7= new PriorityQueue();
    private static PriorityQueue jengaTower8 = new PriorityQueue();

    public Rigidbody glassPrefab, woodenPrefab, stonePrefab;

    public static void AddTile(Tiles t)
    {
        
        if (t.grade.Equals("6th Grade") )
        {
            jengaTower6.Enqueue(t); 

        }else if (t.grade.Equals("7th Grade"))
        {
            jengaTower7.Enqueue(t);

        }else if(t.grade.Equals("8th Grade"))
        {
            jengaTower8.Enqueue(t);
        }
        else
        {
            Debug.LogError("Grade not in  {6,7,8}, grade is: "+ t.grade+" id: " +t.id);
            return;
        }
    }

    public static void StatisticsAndGenerate()
    {
        Debug.Log("jengaTower6 count: " + jengaTower6.Count() + " jengaTower7 count: " + jengaTower7.Count() + " jengaTower8 count: " + jengaTower8.Count());
        instance.Create();
    }
    public void Create()
    {
        //6th grade tower
        int glass=0, wood=0, stone = 0;
        Rigidbody go;

        for(int i=0; i < jengaTower6.Count()+i; i++)
        {
            //basically, theres a template of 6 stacked jenga tiles, each time we make 6, we repeat adding 1.55 (height of each tile)
            int repetition = i / 6;

            Vector3 curPos = tile6Container.transform.GetChild(i%6).gameObject.transform.position+new Vector3(0,2.22f*repetition,0);
            Quaternion curRot = tile6Container.transform.GetChild(i % 6).gameObject.transform.rotation;
            Tiles tmp = jengaTower6.Dequeue();
            if (tmp.mastery == 0)
            {

                go= Instantiate(glassPrefab, curPos, curRot);
                go.gameObject.SetActive(true);
                go.gameObject.transform.SetParent(tile6Container.transform);
                go.GetComponent<GlassTile>().tileString = tmp.tileString;

                glass++;
            }
            else if (tmp.mastery == 1)
            {
                go = Instantiate(woodenPrefab, curPos, curRot);
                go.gameObject.SetActive(true);
                go.gameObject.transform.SetParent(tile6Container.transform);
                go.GetComponent<WoodenTile>().tileString = tmp.tileString;
                wood++;
            }
            else if(tmp.mastery==2){

                go = Instantiate(stonePrefab, curPos, curRot);
                go.gameObject.SetActive(true);
                go.gameObject.transform.SetParent(tile6Container.transform);
                go.GetComponent<StoneTile>().tileString = tmp.tileString;
                stone++;
            
            } else { Debug.LogError("not valid mastery: " + tmp.mastery); }


            // here i clone the towers to use them to refresh the towers later.
            clones.Add(GameObject.Instantiate(tile6Container));
            clones.Add(GameObject.Instantiate(tile7Container)); 
            clones.Add (GameObject.Instantiate(tile8Container));
            foreach (var clone in clones)
            {
                clone.gameObject.SetActive(false);
            }
            ready = true;
        }



        //7th grade tower
        
        for (int i = 0; i < jengaTower7.Count() + i; i++)
        {
            //basically, theres a template of 6 stacked jenga tiles, each time we make 6, we repeat adding 1.55 (height of each tile)
            int repetition = i / 6;

            Vector3 curPos = tile7Container.transform.GetChild(i % 6).gameObject.transform.position + new Vector3(0, 2.22f * repetition, 0);
            Quaternion curRot = tile7Container.transform.GetChild(i % 6).gameObject.transform.rotation;
            Tiles tmp = jengaTower7.Dequeue();
            if (tmp.mastery == 0)
            {

                go = Instantiate(glassPrefab, curPos, curRot);
                go.gameObject.SetActive(true);
                go.gameObject.transform.SetParent(tile7Container.transform);
                go.GetComponent<GlassTile>().tileString = tmp.tileString;
                glass++;
            }
            else if (tmp.mastery == 1)
            {
                go = Instantiate(woodenPrefab, curPos, curRot);
                go.gameObject.SetActive(true);
                go.gameObject.transform.SetParent(tile7Container.transform);
                go.GetComponent<WoodenTile>().tileString = tmp.tileString;
                wood++;
            }
            else if (tmp.mastery == 2)
            {

                go = Instantiate(stonePrefab, curPos, curRot);
                go.gameObject.SetActive(true);
                go.gameObject.transform.SetParent(tile7Container.transform);
                go.GetComponent<StoneTile>().tileString = tmp.tileString;
                stone++;

            }
            else { Debug.LogError("not valid mastery: " + tmp.mastery); }


        }




        //8th grade tower
       
        for (int i = 0; i < jengaTower8.Count() + i; i++)
        {
            //basically, theres a template of 6 stacked jenga tiles, each time we make 6, we repeat adding 1.55 (height of each tile)
            int repetition = i / 6;
            
            Vector3 curPos = tile8Container.transform.GetChild(i % 6).gameObject.transform.position + new Vector3(0, 2.22f * repetition, 0);
            Quaternion curRot = tile8Container.transform.GetChild(i % 6).gameObject.transform.rotation;
            Tiles tmp = jengaTower8.Dequeue();
            if (tmp.mastery == 0)
            {

                go = Instantiate(glassPrefab, curPos, curRot);
                go.gameObject.SetActive(true);
                go.gameObject.transform.SetParent(tile8Container.transform);
                go.GetComponent<GlassTile>().tileString = tmp.tileString;
                glass++;
            }
            else if (tmp.mastery == 1)
            {
                go = Instantiate(woodenPrefab, curPos, curRot);
                go.gameObject.SetActive(true);
                go.gameObject.transform.SetParent(tile8Container.transform);
                go.GetComponent<WoodenTile>().tileString = tmp.tileString;
                wood++;
                Debug.Log(">>>>>>>>>>>>>>>>>>>>>>>>>>\n" + tmp.ToString());
            }
            else if (tmp.mastery == 2)
            {

                go = Instantiate(stonePrefab, curPos, curRot);
                go.gameObject.SetActive(true);
                go.gameObject.transform.SetParent(tile8Container.transform);
                go.GetComponent<StoneTile>().tileString = tmp.tileString;
                stone++;

            }
            else { Debug.LogError("not valid mastery: " + tmp.mastery); }


        }


    }
}


public class PriorityQueue
{
    private List<Tiles> data;

    public PriorityQueue()
    {
        this.data = new List<Tiles>();

    }

    public void Enqueue(Tiles item)
    {
        data.Add(item);
        int ci = data.Count - 1; // child index; start at end
        while (ci > 0)
        {
            int pi = (ci - 1) / 2; // parent index
            if (data[ci].priority.CompareTo(data[pi].priority) >= 0) break; // child item is larger than (or equal) parent so we're done
            Tiles tmp = data[ci]; data[ci] = data[pi]; data[pi] = tmp;
            ci = pi;
        }
    }

    public Tiles Dequeue()
    {
        // assumes pq is not empty; up to calling code
        int li = data.Count - 1; // last index (before removal)
        Tiles frontItem = data[0];   // fetch the front
        data[0] = data[li];
        data.RemoveAt(li);

        --li; // last index (after removal)
        int pi = 0; // parent index. start at front of pq
        while (true)
        {
            int ci = pi * 2 + 1; // left child index of parent
            if (ci > li) break;  // no children so done
            int rc = ci + 1;     // right child
            if (rc <= li && data[rc].priority.CompareTo(data[ci].priority) < 0) // if there is a rc (ci + 1), and it is smaller than left child, use the rc instead
                ci = rc;
            if (data[pi].priority.CompareTo(data[ci].priority) <= 0) break; // parent is smaller than (or equal to) smallest child so done
            Tiles tmp = data[pi]; data[pi] = data[ci]; data[ci] = tmp; // swap parent and child
            pi = ci;
        }
        return frontItem;
    }

    public Tiles Peek()
    {
        Tiles frontItem = data[0];
        return frontItem;
    }

    public int Count()
    {
        return data.Count;
    }

    public override string ToString()
    {
        string s = "";
        for (int i = 0; i < data.Count; ++i)
            s += data[i].ToString() + " ";
        s += "count = " + data.Count;
        return s;
    }

    public bool IsConsistent()
    {
        // is the heap property true for all data?
        if (data.Count == 0) return true;
        int li = data.Count - 1; // last index
        for (int pi = 0; pi < data.Count; ++pi) // each parent index
        {
            int lci = 2 * pi + 1; // left child index
            int rci = 2 * pi + 2; // right child index

            if (lci <= li && data[pi].priority.CompareTo(data[lci].priority) > 0) return false; // if lc exists and it's greater than parent then bad.
            if (rci <= li && data[pi].priority.CompareTo(data[rci].priority) > 0) return false; // check the right child too.
        }
        return true; // passed all checks
    } // IsConsistent
} // PriorityQueue