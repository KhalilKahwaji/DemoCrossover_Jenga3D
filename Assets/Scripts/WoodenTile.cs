using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class WoodenTile : Tiles
{
    public GameObject prefab;

    public WoodenTile(JToken jobj) : base(jobj)
    {
        prefab = woodentilePrefab;
    }
}

