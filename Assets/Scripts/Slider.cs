using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Slider : MonoBehaviour
{
    StarterAssets.FirstPersonController player;
    StarterAssets.StarterAssetsInputs input;
    public RectTransform ReactionAreaTransform;
    public DarakScript Darak;

    float t = 0.0f;
    float speedIncrement = 250.0f;
    float initialWidth = 0f;
    const float WIDTH_DECREMENT = 10.0f;

    int counter = 0;
    const int MAX_COUNT = 4;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<StarterAssets.FirstPersonController>();
        input = GameObject.FindGameObjectWithTag("Player").GetComponent<StarterAssets.StarterAssetsInputs>();
        input.jump = false;
        initialWidth = ReactionAreaTransform.GetComponent<RectTransform>().rect.width;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActiveAndEnabled)
        {
            t += Time.deltaTime * speedIncrement;
            GetComponent<UnityEngine.UI.Slider>().value = Mathf.PingPong(t, 350f);

            if (input.jump)
            {
                float val = GetComponent<UnityEngine.UI.Slider>().value;
                float width = GetComponent<RectTransform>().rect.width;
                float start = width / 2 - ReactionAreaTransform.rect.width / 2;
                float end = width / 2 + ReactionAreaTransform.rect.width / 2;
                if (val > start && val < end)
                {
                    Debug.Log("Picked the lock");
                    counter++;

                    if (counter == MAX_COUNT)
                    {
                        player.canLook = true;
                        player.canMove = true;
                        Darak.GetComponent<DarakScript>().anim.SetTrigger("OpenDarak");
                        Destroy(gameObject);
                    }

                    ReactionAreaTransform.sizeDelta = new Vector2(ReactionAreaTransform.rect.width - WIDTH_DECREMENT, ReactionAreaTransform.rect.height);
                    speedIncrement += 50f;
                }
                else
                {
                    Debug.Log("Missed");
                    ReactionAreaTransform.sizeDelta = new Vector2(initialWidth, ReactionAreaTransform.rect.height);
                    speedIncrement = 250f;
                    counter = 0;
                }
                input.jump = false;
            }
        }

    }

    void OnEnable()
    {
        Debug.Log("Lockpicking");
    }

    void OnDisable()
    {
        Debug.Log("Finished lockpicking");

    }
}
