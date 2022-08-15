using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherAim : MonoBehaviour
{
    const float MAX_YAW_ANGLE = 40f;

    [SerializeField][Range(-40f, 40f)]
    float _yaw = 0f;
    [SerializeField][Range(20f, 70f)]
    float _pitch = 50f;



    [Header("Internal Setup")]
    [SerializeField]
    Transform _yawTr;

    [SerializeField]
    Transform _pitchTr;


    public float yaw{set{
        _yaw = Mathf.Max(-MAX_YAW_ANGLE, Mathf.Min(MAX_YAW_ANGLE,value));

        _yawTr.localRotation = Quaternion.Euler(0f, _yaw, 0f);
    }}


    void Update()
    {
        _yawTr.localRotation = Quaternion.Euler(0f, _yaw, 0f);
        _pitchTr.localRotation = Quaternion.Euler(-_pitch, 0f, 0f);
    }
}
