using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator _animator;
    private string _currentState;

    public void ChangeAnimationState(string newState)
    {
        if(newState == _currentState) 
        {
            return;
        }
        // play new animation
        _animator.Play(newState);
        _currentState = newState;

        Debug.Log("now playing: " + newState);
    }


}
