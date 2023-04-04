using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour, IInteractable
{
    public Chest chest;
    public ChestKey[] chestKey;

    public void OnInteract()
    {
        if (chest.GetResult())
        {
            chest.SetResult();
            gameObject.layer = LayerMask.NameToLayer("Default");
            foreach(var key in chestKey)
            {
                key.gameObject.layer = LayerMask.NameToLayer("Default");
            }
        }
        else
        {
            AudioManager.instance.Play("ClosedDoor");
        }

    }
}
