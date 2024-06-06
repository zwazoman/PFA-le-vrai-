using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMPro;
using Unity.Mathematics;
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

    bool flickerOnEnable = true;//pour faire clignotter les premieres quetes

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
            //vfx
            QuestManager.Instance.OnAnyQuestCompleted.Invoke();
            //montrer les quetes suivantes
            foreach ( string q in _nextQuests)
            {
                Assert.IsTrue(QuestManager.Instance.Quests.Keys.Contains(q),"Cette quete existe pas gros fils de pute de merde");
                QuestManager.Instance.Quests[q].gameObject.SetActive(true);


                //_ = QuestManager.Instance.Quests[q].flicker();
            }

            //enlever cette quete
            OnQuestCompleted?.Invoke();
            gameObject.SetActive(false);
        }

    }

    private void OnEnable()
    {
        if (flickerOnEnable)
        {
            _ = flicker();
        }
        flickerOnEnable = false;
    }


    void OnDestroy()
    {
        QuestManager.Instance.Quests.Remove(_name);
    }


    private void UpdateUI()
    {
        _textComponent.text =  text + (_progressEndTreshold >1 ?  $" ({_progress}/{_progressEndTreshold}) ":"");
    }

    public async Task flicker()
    {
        Color c = _textComponent.color;
        for (int i = 0; i < 12; i++)
        {
            float h, s, v;
            Color.RGBToHSV(c,out h,out s,out v);
            _textComponent.color = Color.HSVToRGB(h,s*3f,v);

            transform.localScale = Vector3.one*1.02f;

            await Task.Delay(100);

            _textComponent.color = c;
            transform.localScale = Vector3.one * 1f;


            await Task.Delay(100);
        }
        _textComponent.color = c;
    }

}
