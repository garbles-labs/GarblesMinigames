using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashObject : MonoBehaviour
{
    [SerializeField]
    TrashType _type = TrashType.Garbage;

    [SerializeField]
    GameObject _holeParticles;


    public TrashType trashType => _type;


    public void Clean() {
        transform.Find("detectable").gameObject.SetActive(false);
        Destroy(gameObject, 5);
    }


    public void Hole() {
        _holeParticles.transform.SetParent(null);
        _holeParticles.SetActive(true);
        Destroy(gameObject);
    }

}
