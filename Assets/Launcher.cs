using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LauncherAim))]
public class Launcher : MonoBehaviour
{
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
    }
}
