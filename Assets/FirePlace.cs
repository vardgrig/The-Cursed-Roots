using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlace : MonoBehaviour,IInteractable
{
    [SerializeField] GameObject paper;
    [SerializeField] GameObject fadeObj;
    [SerializeField] GameObject subtitles;


    private void Start()
    {
        AudioManager.instance.Play("Fire");
    }
    public void OnInteract()
    {
        if (Paper.count == 4)
        {
            gameObject.layer = LayerMask.NameToLayer("Default");
            AudioManager.instance.Play("Whisper");
            AudioManager.instance.Stop("BG");
            Debug.Log("Burn Paper");
            paper.SetActive(true);
            StartCoroutine(EndGame());
        }
    }

    IEnumerator EndGame()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<StarterAssets.FirstPersonController>().canLook = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<StarterAssets.FirstPersonController>().canMove = false;
        AudioManager.instance.Play("Outro");
        subtitles.SetActive(true);
        yield return new WaitForSeconds(18.7f);
        fadeObj.GetComponent<Animator>().SetTrigger("FadeStart");
    }
}
