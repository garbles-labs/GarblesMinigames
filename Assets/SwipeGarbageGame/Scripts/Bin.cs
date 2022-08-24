using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour
{
    [SerializeField]
    TrashType _trashType = TrashType.Garbage;

    [SerializeField]
    Animator _animator;

    [SerializeField]
    AudioSource _correctSound;

    [SerializeField]
    AudioSource _wrongSound;


    public void Enter(TrashObject obj) {
        bool correct = (_trashType == obj.trashType);
        obj.Hole();
        
        if(correct){
            _animator.SetTrigger("Correct");
            _correctSound.Play();
            Game.Correct();
        }
        else{
            _animator.SetTrigger("Incorrect");
            _wrongSound.Play();
        }
    }
}
