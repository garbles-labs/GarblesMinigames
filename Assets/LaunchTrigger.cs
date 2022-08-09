using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SwipeDetector))]
public class LaunchTrigger : MonoBehaviour
{
    [SerializeField]
    float _depth = 1;

    SwipeDetector _swipe;

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
        Debug.Log("DIRECTION: " + direction);
        Debug.Log("TIME: " + time);
        Vector3 pos = new Vector3(direction.x, direction.y, _depth);
        pos = Camera.main.ScreenToWorldPoint(pos);
        
        Debug.DrawLine(
            Camera.main.ScreenToWorldPoint(new Vector3(0,0,_depth)),
            pos,
            Color.red, 3f
        );
    }
}
