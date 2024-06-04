using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestReward : MonoBehaviour
{
    [SerializeField] bool _hasReward;

    [SerializeField] GameObject _rewardObjectPrefab;
    [SerializeField] string _rewardDialog;

    [SerializeField] float _height;

    Quest _quest;

    private void Awake()
    {
        _quest = GetComponent<Quest>();
    }

    private void Start()
    {
        _quest.OnQuestCompleted += StartReward;
    }

    void StartReward()
    {
        PlayerMain.Instance.Sounds.PlayQuestValidateSound();
        if (!_hasReward) return;
        _ = UiManager.Instance.PopupDialogue(_rewardDialog, this);
    }

    public void GiveObject()
    {
        Instantiate(_rewardObjectPrefab, transform.position + Vector3.up * _height, Quaternion.identity);
    }
}
