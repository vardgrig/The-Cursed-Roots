using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] Animator _anim;
    bool _isOpen = false;

    public void OnInteract()
    {
        if (_isOpen)
        {
            _anim.SetTrigger("CloseDoor");
            AudioManager.instance.Play("OpenTheDoor2");
        }
        else
        {
            _anim.SetTrigger("OpenDoor");
            AudioManager.instance.Play("OpenTheDoor");
        }
        _isOpen = !_isOpen;
    }
}
