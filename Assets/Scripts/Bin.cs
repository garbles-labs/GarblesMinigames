using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour
{
    [SerializeField]
    TrashType _trashType = TrashType.Garbage;

    [SerializeField]
    Animator _animator;


    public void Enter(TrashObject obj) {
        bool correct = (_trashType == obj.trashType);
        
        if(correct)
            _animator.SetTrigger("Correct");
        else
            _animator.SetTrigger("Incorrect");


    }
}
