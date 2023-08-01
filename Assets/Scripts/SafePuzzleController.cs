using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SafePuzzleController : MonoBehaviour
{
    [Header("Button List")]
    [SerializeField] private List<ButtonTest> correctBtnList = new List<ButtonTest>();
    [SerializeField] private List<ButtonTest> wrongBtnList = new List<ButtonTest>();

    [Header("Puzzle")]
    [SerializeField] private GameObject lit;

    [Header("Enemy Spawner")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject spawnPoint;

    [Header("Subtitle event")]
    [SerializeField] private TextMeshProUGUI textObj;

    [Header("Debug Only")]
    public bool isTesting;

    private bool isCorrect = false;

    private Dialogue dialogue;

    private void Start() 
    {
        dialogue = FindObjectOfType<Dialogue>();
    }

    public void CheckCorrection()
    {
        foreach(var correctBtn in correctBtnList)
        {
            if(correctBtn.isOn) isCorrect = true;

            if(!correctBtn.isOn)
            {
                isCorrect = false;
                break;
            }
        }

        foreach(var wrongBtn in wrongBtnList)
        {
            if(wrongBtn.isOn)
            {
                isCorrect = false;
            }
        }

        if(!isCorrect) return;

        SetCompleted();
    }

    public void SetCompleted()
    {
        Destroy(lit);
        SpawnMonster();

        foreach(var correctBtn in correctBtnList)
        {
            correctBtn.GetComponent<BoxCollider>().enabled = false;
        }

        foreach(var wrongBtn in wrongBtnList)
        {
            wrongBtn.GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void SpawnMonster()
    {
        textObj.text = "I think i heard something";
        dialogue.Invoke(nameof(dialogue.MonsterTextNarrator), 2f);

        if(isTesting) return;
        
        Instantiate(enemyPrefab,spawnPoint.transform.position,spawnPoint.transform.rotation);
    }
}
