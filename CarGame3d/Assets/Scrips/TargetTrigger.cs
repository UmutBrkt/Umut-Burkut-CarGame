using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.instance.NextCar();
            other.tag = "Dead";
            other.GetComponent<Collider>().isTrigger = true;
        }

    }
}
