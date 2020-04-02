using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterancePoint : MonoBehaviour
{
    public static List<EnterancePoint> all;
    private void OnEnable()
    {
        if (all == null) all = new List<EnterancePoint>();
        all.Add(this);
    }
    private void OnDisable()
    {
        all.Remove(this);
    }
}
