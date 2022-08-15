using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimeText : MonoBehaviour
{
    Text _timeText;

    void Start()
    {
        _timeText = GetComponent<Text>();
        Game.onTime += OnTime;
    }

    void OnTime(float time){
        _timeText.text = string.Format("TIME:\n {0:0.00}",time);
    }

}
