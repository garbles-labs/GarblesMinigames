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


    void OnSwipeDetected(Vector2 origin, Vector2 direction, float time) {
        float speed = direction.magnitude / time;

        float forceParameter = Mathf.InverseLerp(_maxSpeed, _minSpeed, speed);

        float angle = CalculateAngle(origin, direction);

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


    /* Obtaining shot angle with two different points projected on floor plane */
    float CalculateAngle(Vector2 origin, Vector2 direction) 
    {
        Ray ray = Camera.main.ScreenPointToRay(origin);
        Plane floor = new Plane(Vector3.up, Vector3.zero);

        Vector3 a = Vector3.zero,
                b = Vector3.zero;

        if(floor.Raycast(ray,out float dist)){
            a = ray.GetPoint(dist);
            Debug.DrawRay(a, Vector3.up, Color.green);
        }

        ray = Camera.main.ScreenPointToRay(origin+direction);
        if(floor.Raycast(ray, out dist)) {
            b = ray.GetPoint(dist);;
            Debug.DrawRay(b, Vector3.up, Color.green);
        }

        Vector3 projected = b-a;
        projected = new Vector3(projected.x, 0f, projected.z); // just in case y=0

        Debug.DrawRay(a, projected, Color.white);
        Debug.DrawRay(a, Vector3.forward, Color.blue);

        return Vector3.SignedAngle(Vector3.forward, projected, Vector3.up);
    }
}
