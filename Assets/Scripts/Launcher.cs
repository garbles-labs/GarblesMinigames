using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LauncherAim))]
public class Launcher : MonoBehaviour
{
    const float MAX_LAUNCH_FORCE = 0.1f;
    const float MIN_LAUNCH_FORCE = 3f;

    [SerializeField][Range(0.1f, 3f)]
    float _launchForce = 0.1f;

    [SerializeField]
    GameObject _ballPrototype;

    [SerializeField]
    Transform _ballOrigin;


    public float launchForce{set{
        _launchForce = value;
    }}

    


    public void Launch() {
        GameObject ball = Instantiate(_ballPrototype, _ballOrigin.position, _ballOrigin.rotation);
        
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.AddForce(_ballOrigin.forward * _launchForce, ForceMode.Impulse);

        float dir = Random.Range(0, 2) == 0 ? -1f:1f;

        rb.AddTorque(Random.insideUnitSphere * dir, ForceMode.Impulse);
    }


    void Start() {
        LaunchTrigger.onLaunchTriggered += OnLaunchTriggered;
    }

    void OnDestroy() {
        LaunchTrigger.onLaunchTriggered -= OnLaunchTriggered;
    }


    void OnLaunchTriggered(float force, float angle) {
        this.launchForce = Mathf.Lerp(MIN_LAUNCH_FORCE, MAX_LAUNCH_FORCE, force);
        Launch();
    }
}
