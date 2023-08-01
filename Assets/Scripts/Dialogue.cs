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
        Invoke(nameof(StartTextNarrator), 2f);
    }

    private void StartTextNarrator()
    {
        textObj.text = "Augh.. Where am i?";
        Invoke(nameof(ClearDialogue), 2f);
    }

    public void CantOpenTextNarrator()
    {
        textObj.text = "Can't open it";
        Invoke(nameof(ClearDialogue), 2f);
    }

    public void MonsterTextNarrator()
    {
        textObj.text = "I should grab key and get out of here";
        Invoke(nameof(ClearDialogue), 2f);
    }

    public void ClearDialogue()
    {
        textObj.text = "";
    }
}
