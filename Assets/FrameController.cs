using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameController : MonoBehaviour, IInteractable
{
    Animator anim;
    bool isCollected = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    public void OnInteract()
    {
        if (!isCollected)
        {
            anim.SetTrigger("MoveFrame");
            isCollected = true;
            gameObject.layer = LayerMask.NameToLayer("Default");
        }
    }
}
