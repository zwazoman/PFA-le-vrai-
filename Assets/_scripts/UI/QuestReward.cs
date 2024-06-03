using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestReward : MonoBehaviour
{
    Quest _quest;
    [SerializeField] float _heightToInstantiate;
    [SerializeField] bool _givesReward;
    [SerializeField] GameObject _rewardPrefab;
    [SerializeField] string _rewardDialog;

    private void Awake()
    {
        _quest = GetComponent<Quest>();
    }

    private void Start()
    {
        //if (!_givesReward) _quest.OnQuestCompleted += SayReward;
    }

    public void GiveReward()
    {
        if (!_givesReward) return;
        Instantiate(_rewardPrefab, PlayerMain.Instance.gameObject.transform.position + Vector3.up * _heightToInstantiate, Quaternion.identity);
    }

    private void SayReward()
    {
        _ = UiManager.Instance.PopupDialogue(_rewardDialog,this);
    }
}
