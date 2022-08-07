using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField][Range(0.1f, 3f)]
    float _minLaunchForce = 0.1f;

    [SerializeField][Range(0.1f, 3f)]
    float _maxLaunchForce = 3;

    [SerializeField] 
    float _timeInterval = 0.5f;

    [SerializeField]
    ForceMode _mode;


    [SerializeField]
    GameObject _ballPrototype;

    IEnumerator Start()
    {
        while(true){
            yield return new WaitForSeconds(_timeInterval);

            GameObject ball = Instantiate(_ballPrototype, transform.position, transform.rotation);
            Launch(ball);
        }

    }


    public void Launch(GameObject ball) {
        Rigidbody rb = ball.GetComponent<Rigidbody>();

        float force = Random.Range(_minLaunchForce, _maxLaunchForce);

        rb.AddForce(transform.forward * force, _mode);
    }

}
