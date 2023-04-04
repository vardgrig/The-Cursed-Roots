using UnityEngine;

public class PaperRotation : MonoBehaviour
{
    [SerializeField] StarterAssets.FirstPersonController character;

    float rotationSpeed = 50f;

    void Start()
    {
        //character._input.escape = false;
    }

    void Update()
    {
        float horizontal = character._input.look.x;
        transform.Rotate(Vector3.up, horizontal * rotationSpeed * Time.deltaTime);

        Debug.Log(character._input.escape);
        CheckEscape();
    }

    void CheckEscape()
    {
        if (character._input.escape && Paper.count == 4)
        {
            Debug.Log("Paper destroyed");
            character.canMove = true;
            character.canLook = true;

            character._input.escape = false;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            Destroy(gameObject);
        }
    }
}
