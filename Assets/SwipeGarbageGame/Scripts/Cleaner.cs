using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour
{
    void OnTriggerEnter(Collider coll){
        coll.GetComponentInParent<TrashObject>().Clean();
    }
}
