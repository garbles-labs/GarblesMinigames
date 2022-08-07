using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherAim : MonoBehaviour
{
    [SerializeField][Range(-40f, 40f)]
    float _yaw = 0f;
    [SerializeField][Range(20f, 70f)]
    float _pitch = 50f;



    [Header("Internal Setup")]
    [SerializeField]
    Transform _yawTr;

    [SerializeField]
    Transform _pitchTr;


    public float yaw{set{_yaw = value;}}


    void Update()
    {
        _yawTr.localRotation = Quaternion.Euler(0f, _yaw, 0f);
        _pitchTr.localRotation = Quaternion.Euler(-_pitch, 0f, 0f);
    }
}
