using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashObject : MonoBehaviour
{
    [SerializeField]
    TrashType _type = TrashType.Garbage;


    public TrashType trashType => _type;

}
