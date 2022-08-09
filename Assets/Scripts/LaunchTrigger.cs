using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SwipeDetector))]
public class LaunchTrigger : MonoBehaviour
{
    [SerializeField]
    float _depth = 1;

    [SerializeField]
    float _minSpeed = 1000;

    [SerializeField]
    float _maxSpeed = 5000;

    SwipeDetector _swipe;


    public static System.Action<float, float> onLaunchTriggered; // force , angle



    void Awake()
    {
        _swipe = GetComponent<SwipeDetector>();        
    }


    void Start(){
        _swipe.onSwipeDetected += OnSwipeDetected;
    }

    void OnDestroy() {
        _swipe.onSwipeDetected -= OnSwipeDetected;
    }


    void OnSwipeDetected(Vector2 direction, float time) {
        float speed = direction.magnitude / time;

        float forceParameter = Mathf.InverseLerp(_minSpeed, _maxSpeed, speed);
        float angle = Vector2.SignedAngle(Vector2.up, direction);

        if(onLaunchTriggered != null) {
            onLaunchTriggered(forceParameter, angle);
        }



        Vector3 pos = new Vector3(direction.x, direction.y, _depth);
        pos = Camera.main.ScreenToWorldPoint(pos);
        
        Debug.DrawLine(
            Camera.main.ScreenToWorldPoint(new Vector3(0,0,_depth)),
            pos,
            Color.red, 3f
        );
    }
}
