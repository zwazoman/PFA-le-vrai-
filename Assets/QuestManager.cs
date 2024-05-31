using CustomInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance { get;private set; }

    public Dictionary<string,Quest> Quests = new Dictionary<string, Quest>();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        foreach(Transform child in transform)
        {
            if(child.gameObject.TryGetComponent<Quest>(out Quest q))
            {
                Quests.Add(q.name, q);
                //child.gameObject.SetActive(false);
            }
        }
    }

    public void TryProgressQuest(string name, int amount)
    {
        Quests[name].AddProgress(amount);
    }


}
