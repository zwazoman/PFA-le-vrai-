using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance { get;private set; }

    public Dictionary<string,Quest> Quests = new Dictionary<string, Quest>();

    public UnityEvent OnAnyQuestCompleted;

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
        if (!Quests.Keys.Contains(name)) return;
        Quests[name].AddProgress(amount);
    }
}
