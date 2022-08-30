using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LauncherAim))]
public class Launcher : MonoBehaviour
{
    const float MAX_LAUNCH_FORCE = 0.5f;
    const float MIN_LAUNCH_FORCE = 0.8f;

    [SerializeField][Range(0.1f, 3f)]
    float _launchForce = 0.1f;

    [SerializeField][Range(5f, 70f)]
    float _maxYaw = 30;
    [SerializeField][Range(2, 5)]
    int _totalAngles = 3;

    [SerializeField]
    Transform _ballOrigin;

    LauncherAim _aim;
    public List<float> _allAngles;


    public float launchForce{set{
        _launchForce = value;
    }}

    


    public void Launch() {
        GameObject ball = Instantiate(Game.nextPrototype, _ballOrigin.position, _ballOrigin.rotation);
        
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.AddForce(_ballOrigin.forward * _launchForce, ForceMode.Impulse);

        float dir = Random.Range(0, 2) == 0 ? -1f:1f;

        rb.AddTorque(Random.insideUnitSphere * dir, ForceMode.Impulse);
    }

    void Awake() {
        _aim = GetComponent<LauncherAim>();

        // calculate all angles
        float diffAngle = (_maxYaw * 2)/(_totalAngles-1);
        float currAngle = -_maxYaw;
        _allAngles = new List<float>();
        for(int i=0;i<_totalAngles;i++) {
            _allAngles.Add(currAngle);
            currAngle += diffAngle;
        }
    }


    void Start() {
        LaunchTrigger.onLaunchTriggered += OnLaunchTriggered;
    }

    void OnDestroy() {
        LaunchTrigger.onLaunchTriggered -= OnLaunchTriggered;
    }


    void OnLaunchTriggered(float force, float angle) {
        this.launchForce = Mathf.Lerp(MIN_LAUNCH_FORCE, MAX_LAUNCH_FORCE, force);

        angle = Mathf.Min(angle, _maxYaw);
        angle = Mathf.Max(angle, -_maxYaw);
        _aim.yaw = angle;
        /*

        float best = 999;
        int bestIndex = -1;
        for(int i=0;i<_allAngles.Count;i++) {
            float dist = Mathf.Abs(_allAngles[i] - angle);
            if(dist < best){
                best = dist;
                bestIndex = i;
            }
        }

        _aim.yaw = _allAngles[bestIndex];
        */
        //Debug.Log("ANGLE: " + angle);
        //Debug.Log("BEST: " + best);
        //Debug.Log("LAUNCH FORCE: " + _launchForce);
        Launch();

        Game.Next();
    }
}
