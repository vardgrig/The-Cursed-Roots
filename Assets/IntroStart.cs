using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroStart : MonoBehaviour
{

    private void Start()
    {
        AudioManager.instance.Play("BGround");
        StartCoroutine(StartGame());
    }
    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1f);
        AudioManager.instance.Play("Intro");
        yield return new WaitForSeconds(25f);
        SceneManager.LoadScene(1);
    }
}
