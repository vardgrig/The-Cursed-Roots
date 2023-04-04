using UnityEngine;

public class DarakScript : MonoBehaviour, IInteractable
{
    public Animator anim;
    bool isOpen = false;
    [SerializeField] StarterAssets.FirstPersonController character;
    [SerializeField] GameObject slider;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OnInteract()
    {
        if (!isOpen && character.hasLockpick)
        {
            isOpen = true;

            slider.SetActive(true);
            gameObject.layer = LayerMask.NameToLayer("Default");

            character.canMove = false;
            character.canLook = false;
        }
        else if(!isOpen && !character.hasLockpick)
        {
            AudioManager.instance.Play("ClosedDoor");
        }
    }
}
