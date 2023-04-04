using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lockpick : MonoBehaviour, IInteractable
{
    public StarterAssets.FirstPersonController player;
    public Image image;

    public void OnInteract()
    {
        player.hasLockpick = true;
        image.color = new Color(255, 255, 255, 255);

        Destroy(gameObject);
    }
}
