using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashViewer : MonoBehaviour
{
    public GameObject Tobacco;
    public GameObject Jerrycan;
    public GameObject CanA;
    public GameObject CanB;
    public GameObject CanC;
    public GameObject CanD;
    public GameObject BrickA;
    public GameObject BrickB;
    public GameObject BrickC;
    public GameObject BottleA;
    public GameObject BottleB;
    public GameObject BottleC;
    public GameObject BottleD;
    public GameObject BottleE;
    public GameObject BottleF;
    public GameObject Cup;

    Dictionary<Trash, GameObject> _objects;

    void Awake() {
        _objects = new Dictionary<Trash, GameObject>();
        _objects.Add(Trash.Tobacco, Tobacco);
        _objects.Add(Trash.Jerrycan, Jerrycan);
        _objects.Add(Trash.CanA, CanA);
        _objects.Add(Trash.CanB, CanB);
        _objects.Add(Trash.CanC, CanC);
        _objects.Add(Trash.CanD, CanD);
        _objects.Add(Trash.BrickA, BrickA);
        _objects.Add(Trash.BrickB, BrickB);
        _objects.Add(Trash.BrickC, BrickC);
        _objects.Add(Trash.BottleA, BottleA);
        _objects.Add(Trash.BottleB, BottleB);
        _objects.Add(Trash.BottleC, BottleC);
        _objects.Add(Trash.BottleD, BottleD);
        _objects.Add(Trash.BottleE, BottleE);
        _objects.Add(Trash.BottleF, BottleF);
        _objects.Add(Trash.Cup, Cup);

    }


    void Update()
    {
        foreach(var obj in _objects){
            obj.Value.SetActive(Game.nextTrash == obj.Key);
        }
        
    }
}
