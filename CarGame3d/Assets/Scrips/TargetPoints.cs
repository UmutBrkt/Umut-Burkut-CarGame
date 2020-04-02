using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPoints : MonoBehaviour
{
    public static List<TargetPoints> all;
    private void OnEnable()
    {
        if (all == null) all = new List<TargetPoints>();
        all.Add(this);
    }
    private void OnDisable()
    {
        all.Remove(this);
    }
}
