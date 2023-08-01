using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [Header("Subtitle event")]
    [SerializeField] private TextMeshProUGUI textObj;

    private void Start()
    {
        StartCoroutine(StartTextNarrator());
    }

    private IEnumerator StartTextNarrator()
    {
        yield return new WaitForSeconds(1.5f);
        textObj.text = "Augh.. Where am i?";
        yield return new WaitForSeconds(2f);

        textObj.text = "";
    }

    public IEnumerator CantOpenTextNarrator()
    {
        textObj.text = "Can't open it";
        yield return new WaitForSeconds(2f);

        textObj.text = "";
    }
}
