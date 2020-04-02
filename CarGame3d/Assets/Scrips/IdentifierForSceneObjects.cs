using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdentifierForSceneObjects : MonoBehaviour
{
    public Color colorObj;
    void OnDrawGizmos()
    {
        Gizmos.color = colorObj;
        Gizmos.DrawSphere(transform.position, 1);
    }

}
