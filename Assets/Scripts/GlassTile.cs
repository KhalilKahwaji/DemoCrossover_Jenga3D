using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class GlassTile : Tiles
{
    public GameObject prefab;
    public GlassTile(JToken jobj) : base(jobj)
    {
        prefab = glasstilePrefab;
    }
}