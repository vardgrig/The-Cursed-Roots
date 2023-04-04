using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paper : MonoBehaviour, IInteractable
{
    [SerializeField] Image image;
    public StarterAssets.FirstPersonController player;
    public GameObject cameraPaper;

    static public int count = 0;

    public void OnInteract()
    {
        image.color = new Color(255, 255, 255, 255);

        count++;
        AudioManager.instance.Play("TakePaper");

        if (count == 4)
        {
            transform.parent.GetComponent<DarakScript>().anim.SetTrigger("CloseDarak");
            Debug.Log("Last paper picked up");

            player.canLook = false;
            player.canMove = false;

            cameraPaper.SetActive(true);
        }

        Destroy(this.gameObject);
    }
}
