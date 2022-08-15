using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFinalScore : MonoBehaviour
{
    [SerializeField]
    Text _scoreText;

    [SerializeField]
    GameObject _panel;


    void Start(){
        _panel.SetActive(false);
        Game.onGameEnded += OnGameEnded;
    }

    void OnDestroy(){
        Game.onGameEnded -= OnGameEnded;
    }


    void OnGameEnded(int points) {
        _panel.SetActive(true);
        _scoreText.text = string.Format("{0}",points);
    }
}
