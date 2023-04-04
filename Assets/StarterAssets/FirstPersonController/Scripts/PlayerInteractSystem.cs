using StarterAssets;
using UnityEngine;

public interface IInteractable
{
    void OnInteract();
}

public class PlayerInteractSystem : MonoBehaviour
{
    [SerializeField] LayerMask interactableLayer;
    [SerializeField] float _interactDistance;
    Transform _playerCam;
    StarterAssetsInputs _input;
    [SerializeField] GameObject useText;

    // Start is called before the first frame update
    void Start()
    {
        _playerCam = Camera.main.transform;
        _input = GetComponent<StarterAssetsInputs>();
        AudioManager.instance.Play("BG");
    }

    // Update is called once per frame
    void Update()
    {
        OnInteract();
    }

    public void OnInteract()
    {
        if (Physics.Raycast(_playerCam.position, _playerCam.forward, out RaycastHit hit, _interactDistance, interactableLayer))
        {
            useText.SetActive(true);
            if (_input.interact)
            {
                //Debug.Log("Trying to interact");
                try
                {
                    hit.transform.gameObject.GetComponent<IInteractable>().OnInteract();
                }
                catch
                {
                    //Debug.Log("No IInteractable implemented");
                }
                finally
                {
                    _input.interact = false;
                }
            }
            else
            {
                _input.interact = false;
                //hit.transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
                //Debug.Log("You can interact with this object");

            }
        }
        else
        {
            _input.interact = false;
            useText.SetActive(false);
        }
    }
}
