using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    float _speed = 10f;

    void Update()
    {
        transform.Rotate(0f, _speed * Time.deltaTime, 0f);
    }
}
