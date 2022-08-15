using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashObject : MonoBehaviour
{
    [SerializeField]
    TrashType _type = TrashType.Garbage;


    public TrashType trashType => _type;


    public void Clean() {
        transform.Find("detectable").gameObject.SetActive(false);
        Destroy(gameObject, 5);
    }

}
