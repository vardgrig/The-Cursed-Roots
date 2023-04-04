using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestKey : MonoBehaviour, IInteractable
{
    public int Number = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnInteract()
    {
        Debug.Log("Interacted with key");

        if (Number <= 8)
            Number++;
        else
            Number = 0;

        transform.parent.transform.Rotate(new Vector3(36f, 0f, 0f), Space.World);
    }
}
