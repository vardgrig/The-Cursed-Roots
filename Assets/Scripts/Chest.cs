using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Chest : MonoBehaviour, IInteractable
{
    [SerializeField]
    Animator upperChest;
    bool isOpen = false;
    public GameObject ChestKeysCamera;
    public StarterAssets.FirstPersonController character;
    public CinemachineVirtualCamera virtualCam;
    public GameObject playerPosForChest;
    const string CODE = "493";

    ChestKey[] keys = new ChestKey[3];

    // Start is called before the first frame update
    void Start()
    {
        keys = GetComponentsInChildren<ChestKey>();
    }

    public void OnInteract()
    {
        if (character.canMove && !isOpen)
        {
            character.canMove = false;

            character.transform.position = playerPosForChest.transform.position;
            virtualCam.Follow = ChestKeysCamera.transform;
        }
        else
        {
            PlayerStand();
        }
    }

    public bool GetResult()
    {
        return keys[0].Number.ToString() + keys[1].Number.ToString() + keys[2].Number.ToString() == CODE;
    }

    public void SetResult()
    {
        PlayerStand();
        upperChest.SetTrigger("OpenChest");
        AudioManager.instance.Play("OpenTheDoor");
        isOpen = true;
        gameObject.layer = LayerMask.NameToLayer("Default");
    }
    public void PlayerStand()
    {
        virtualCam.Follow = character.CinemachineCameraTarget.transform;
        character.canMove = true;
    }
}
