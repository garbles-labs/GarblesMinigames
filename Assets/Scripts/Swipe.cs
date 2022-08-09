using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    enum InputType{Mouse=1, Touch=2}
    
    public List<Vector2> _positions;
    public List<float> _times;

    [SerializeField]
    float _thresholdTime = 1;

    [SerializeField]
    InputType _inputType = InputType.Mouse;



    Vector2 _lastMousePosition;


    void Update()
    {
        if(_inputType == InputType.Mouse) {
            bool detect = false; // makes swipe detection this frame
            Vector2 pos = Vector2.zero;

            TouchPhase phase = TouchPhase.Moved;
            if(Input.GetMouseButtonDown(0)) {
                phase = TouchPhase.Began;
                pos = Input.mousePosition;
                _lastMousePosition = pos;
                detect = true;
            }else if(Input.GetMouseButtonUp(0)){
                phase = TouchPhase.Ended;
                detect = true;
                pos = _lastMousePosition;
            } else if(Input.GetMouseButton(0)) {
                pos = Input.mousePosition;
                if(_lastMousePosition != pos)
                    phase = TouchPhase.Moved;
                else
                    phase = TouchPhase.Stationary;

                _lastMousePosition = pos;
                detect = true;
            }


            if(detect) {
                if(DetectSwipe(pos, phase, out Vector2 direction, out float time)) {
                    Debug.Log("TIME: " + time);
                    Debug.Log("DIRECTION: " + direction);
                }
            }
        }
        else if(_inputType == InputType.Touch) {
            if(Input.touchCount > 0){
                if(DetectSwipe(Input.touches[0].position, Input.touches[0].phase, out Vector2 direction, out float time)) {
                    Debug.Log(time);
                }
            }
        }
    }


    bool DetectSwipe(Vector2 position, TouchPhase phase, out Vector2 direction, out float time) 
    {
        direction = Vector2.zero;
        time = 0f;

        // start of the list
        if(phase == TouchPhase.Began){
            _positions = new List<Vector2>();
            _times = new List<float>();
        }


        if(phase == TouchPhase.Began || 
           phase == TouchPhase.Moved ||
           phase == TouchPhase.Ended) 
        {
            _positions.Add(position); 
            _times.Add(Time.time);
        } else if(phase == TouchPhase.Stationary) {
            _times[_times.Count - 1] = Time.time;
        } else if (position == _positions[_positions.Count-1]){
            _times[_times.Count - 1] = Time.time;
        }

        // detecting actual swipe
        if(phase == TouchPhase.Ended) {
            if(_positions.Count <= 1) // no swipe detected
                return false;

            float lastTime = _times[_times.Count - 1];

            for(int i=0;i<_positions.Count;i++) {
                if(lastTime - _times[i] <= _thresholdTime){
                    direction = _positions[_positions.Count-1] - _positions[i];
                    time = _times[_times.Count-1] - _times[i];

                    return true;
                }
            }
        }
            
        return false;
    }
}
