using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    void Start()
    {
        Game.onGameEnded += OnGameEnded;
    }

    void OnDestroy()
    {
        Game.onGameEnded += OnGameEnded;
    }

    void OnGameEnded(int points)
    {
        GetComponent<AudioSource>().Play();
    }
}
