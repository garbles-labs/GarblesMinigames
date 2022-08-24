using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    static Game _instance;

    [SerializeField]
    Trash _nextTrash;

    [SerializeField]
    int _pointsPerCorrect = 10;

    [SerializeField]
    int _totalTime = 30;


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

    public static System.Action<int> onScore;
    public static System.Action<float,float> onTime;
    public static System.Action<int> onGameEnded;


    int _score;
    float _timeLeft;
    bool _playing;

    


    public static Trash nextTrash => _instance._nextTrash;

    public static bool playing => _instance._playing;

    public static GameObject nextPrototype{
        get{
            return _instance._prototypes[_instance._nextTrash];
        }
    }


    public static void Next() 
    {
        int index = Random.Range(0, _allTrashes.Count);
        _instance._nextTrash = _allTrashes[index];
    }

    public static void Correct(){
        _instance._score += _instance._pointsPerCorrect;

        if(onScore != null)
            onScore(_instance._score);
    }


    static List<Trash> _allTrashes;

    void Awake() 
    {
        _instance = this;
        _allTrashes = new List<Trash>() {
            Trash.Tobacco,
            Trash.Jerrycan,
            Trash.CanA,
            Trash.CanB,
            Trash.CanC,
            Trash.CanD,
            Trash.BrickA,
            Trash.BrickB,
            Trash.BrickC,
            Trash.BottleA,
            Trash.BottleB,
            Trash.BottleC,
            Trash.BottleD,
            Trash.BottleE,
            Trash.BottleF,
            Trash.Cup
        };
    }

    void Start()
    {
        _score = 0;
        _timeLeft = _totalTime;
        _playing = true;

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

    void Update() {
        if(_playing){
            _timeLeft -= Time.deltaTime;
            if(onTime != null)
                onTime(_timeLeft, _totalTime);

            if(_timeLeft <= 0f)
                _playing = false;
        } else {
            if(onTime != null)
                onTime(0f, _totalTime);

            if(onGameEnded!=null)
                onGameEnded(_score);

            gameObject.SetActive(false);
        }
    }

}
