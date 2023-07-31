using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafePuzzleController : MonoBehaviour
{
    [SerializeField] private List<ButtonTest> correctBtnList = new List<ButtonTest>();
    [SerializeField] private List<ButtonTest> wrongBtnList = new List<ButtonTest>();

    [SerializeField] private GameObject lit;

    private bool isCorrect = false;

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

        foreach(var correctBtn in correctBtnList)
        {
            correctBtn.GetComponent<BoxCollider>().enabled = false;
        }

        foreach(var wrongBtn in wrongBtnList)
        {
            wrongBtn.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
