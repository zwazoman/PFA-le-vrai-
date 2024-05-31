using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnd : MonoBehaviour
{
    Quest _quest;

    private void Awake()
    {
        _quest = GetComponent<Quest>();
    }

    private void Start()
    {
        _quest.OnQuestCompleted += EndTutorial;
    }

    void EndTutorial()
    {
        TimeManager.Instance.EndTutorial();
    }
}
