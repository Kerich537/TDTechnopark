using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StoreCell", menuName = "Scriptable Objects/StoreCell", order = 1)]
public class StoreScriptableObject : ScriptableObject
{
    public GameObject turretPrefab;
    public Sprite turretSprite;
    public int turretPrice;
}
