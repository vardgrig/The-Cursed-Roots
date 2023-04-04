using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubtitleIntro : MonoBehaviour
{
    public string textone = "In my family's dark past, an ancestor was accused of witchcraft and suffered a public execution...";
    public string texttwo = "As the last breath left their body, a curse was cast upon their accusers - my own bloodline...";
    public string textthree = "I must break this vicious cycle and bring an end to the curse, not just for myself, but to protect my forebears...";
    public float firstTransition;
    public float secondTransition;

    void OnEnable()
    {
        GetComponent<TMPro.TMP_Text>().text = textone;
        StartCoroutine(ShowTextTwo());
    }

    IEnumerator ShowTextTwo()
    {
        yield return new WaitForSeconds(firstTransition);
        GetComponent<TMPro.TMP_Text>().text = texttwo;
        yield return new WaitForSeconds(secondTransition);
        GetComponent<TMPro.TMP_Text>().text = textthree;
    }
}
