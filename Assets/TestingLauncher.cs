using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Launcher))]
[RequireComponent(typeof(LauncherAim))]
public class TestingLauncher : MonoBehaviour
{
    [SerializeField][Range(0f, 40f)]
    float _spreadAngle = 5f;

    [SerializeField][Range(0.1f, 3f)]
    float _minLaunchForce = 0.1f;

    [SerializeField][Range(0.1f, 3f)]
    float _maxLaunchForce = 3;

    [SerializeField] 
    float _timeInterval = 0.5f;


    Launcher _launcher;
    LauncherAim _aim;


    void Awake() 
    {
        _launcher = GetComponent<Launcher>();
        _aim = GetComponent<LauncherAim>();
    }

    IEnumerator Start()
    {
        while(true){
            yield return new WaitForSeconds(_timeInterval);

            _aim.yaw = Random.Range(-_spreadAngle, _spreadAngle);

            _launcher.launchForce = Random.Range(_minLaunchForce, _maxLaunchForce);
            _launcher.Launch();
        }
    }
}
