using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;

public class Quest : MonoBehaviour
{
    string _name;
    int _progress = 0;
    [SerializeField] int _progressEndTreshold;
    bool _completed = false;
    [SerializeField] List<string> _nextQuests = new List<string>();
    TMP_Text _textComponent;
    [SerializeField] string text;

    public event Action OnQuestCompleted;

    private void Awake()
    {
        _name = gameObject.name;
        _textComponent = GetComponent<TMP_Text>();
        UpdateUI();
    }

    public void AddProgress(int amount = 1)
    {
        if (_completed || !gameObject.activeSelf) { return; }

        _progress += amount;
        UpdateUI();

        if( _progress >= _progressEndTreshold)
        {
            //montrer les quetes suivantes
            foreach ( string q in _nextQuests)
            {
                Assert.IsTrue(QuestManager.Instance.Quests.Keys.Contains(q),"Cette quete existe pas gros fils de pute de merde");
                QuestManager.Instance.Quests[q].gameObject.SetActive(true);
            }

            //enlever cette quete
            OnQuestCompleted?.Invoke();
            Destroy(gameObject);
        }

    }

    void OnDestroy()
    {
        QuestManager.Instance.Quests.Remove(_name);
    }

    private void UpdateUI()
    {
        _textComponent.text =  text + (_progressEndTreshold >1 ?  $" ({_progress}/{_progressEndTreshold}) ":"");
    }

}
