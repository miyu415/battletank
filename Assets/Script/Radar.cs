using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Payer"))
        {
            transform.root.LookAt(target);
        }
    }
}
