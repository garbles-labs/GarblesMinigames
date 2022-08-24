using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimeText : MonoBehaviour
{
    Text _timeText;

    [SerializeField]
    Image _img;

    void Start()
    {
        _timeText = GetComponent<Text>();
        Game.onTime += OnTime;
    }

    void OnTime(float time, float totalTime){
        _timeText.text = string.Format("TIME:\n {0:0.00}",time);
        _img.fillAmount = time/totalTime;
    }

}
