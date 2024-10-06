using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(fileName = "Planet", menuName = "Corpse/Planet")]
public class PlanetData : ScriptableObject
{
    public int id;
    public string exoName;
    public string description;
    public float distanceLightYears;
}
