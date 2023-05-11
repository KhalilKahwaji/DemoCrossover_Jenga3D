using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class StoneTile : Tiles
{
    public GameObject prefab;
    public StoneTile(JToken jobj) : base(jobj)
    {
        prefab = stonetilePrefab;
    }
}

