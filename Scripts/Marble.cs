using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Marble Class", menuName = "MarbleClasses")]
public class Marble : ScriptableObject
{
    public int maxPower;
    public float chargeRate;
    public float decreaseRate;

    public Material material;
}
