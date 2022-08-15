using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashDetector : MonoBehaviour
{
    Bin _bin;

    void Awake() {
        _bin = GetComponentInParent<Bin>();
    }


    void OnTriggerEnter(Collider coll){
        _bin.Enter(coll.GetComponentInParent<TrashObject>());
    }
}
