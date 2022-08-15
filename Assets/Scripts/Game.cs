using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    static Game _instance;

    [SerializeField]
    Trash _nextTrash;


    public GameObject TobaccoPrototype;
    public GameObject JerrycanPrototype;
    public GameObject CanAPrototype;
    public GameObject CanBPrototype;
    public GameObject CanCPrototype;
    public GameObject CanDPrototype;
    public GameObject BrickAPrototype;
    public GameObject BrickBPrototype;
    public GameObject BrickCPrototype;
    public GameObject BottleAPrototype;
    public GameObject BottleBrototype;
    public GameObject BottleCPrototype;
    public GameObject BottleDPrototype;
    public GameObject BottleEPrototype;
    public GameObject BottleFPrototype;
    public GameObject CupPrototype;


    Dictionary<Trash, GameObject> _prototypes;


    public static Trash nextTrash => _instance._nextTrash;

    public static GameObject nextPrototype{
        get{
            return _instance._prototypes[_instance._nextTrash];
        }
    }

    void Awake() 
    {
        _instance = this;
    }

    void Start()
    {
        _prototypes  = new Dictionary<Trash, GameObject>();
        _prototypes.Add(Trash.Tobacco, TobaccoPrototype);
        _prototypes.Add(Trash.Jerrycan, JerrycanPrototype);
        _prototypes.Add(Trash.CanA, CanAPrototype);
        _prototypes.Add(Trash.CanB, CanBPrototype);
        _prototypes.Add(Trash.CanC, CanCPrototype);
        _prototypes.Add(Trash.CanD, CanDPrototype);
        _prototypes.Add(Trash.BrickA, BrickAPrototype);
        _prototypes.Add(Trash.BrickB, BrickBPrototype);
        _prototypes.Add(Trash.BrickC, BrickCPrototype);
        _prototypes.Add(Trash.BottleA, BottleAPrototype);
        _prototypes.Add(Trash.BottleB, BottleBrototype);
        _prototypes.Add(Trash.BottleC, BottleCPrototype);
        _prototypes.Add(Trash.BottleD, BottleDPrototype);
        _prototypes.Add(Trash.BottleE, BottleEPrototype);
        _prototypes.Add(Trash.BottleF, BottleFPrototype);
        _prototypes.Add(Trash.Cup, CupPrototype);
    }

    void Update()
    {
        
    }
}
