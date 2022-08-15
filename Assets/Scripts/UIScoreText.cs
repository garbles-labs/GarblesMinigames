using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScoreText : MonoBehaviour
{
    Text _scoreText;

    void Awake(){
        _scoreText = GetComponent<Text>();
    }

    void Start(){
        Game.onScore += OnScore;
    }

    void OnDestroy(){
        Game.onScore -= OnScore;
    }

    void OnScore(int score) {
        _scoreText.text = "POINTS:\n" + score;
    }
}
