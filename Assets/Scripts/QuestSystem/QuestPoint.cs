using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class QuestPoint : MonoBehaviour
{
    [Header("Quest")]
    [SerializeField] private QuestInfoSO questInfoForPoint;

    [Header("Config")]
    [SerializeField] private bool startPoint = true;
    [SerializeField] private bool finishpoint = true;

    [Header("Quest InfoUI")]
    [SerializeField] private QuestUI questUI;

    [Header("Quest UI")]
    [SerializeField] public TextMeshProUGUI titleText;
    [SerializeField] public TextMeshProUGUI descriptionText;
    [SerializeField] public Image image;
    [SerializeField] public TextMeshProUGUI rewardText;
    [SerializeField] public TextMeshProUGUI diffText;

    private string questId;
    private QuestState currentQuestState;

    private void Awake()
    {
        questId = questInfoForPoint.id;
    }

    private void Start()
    {
        titleText.text = questUI.title;
        descriptionText.text = questUI.description;
        image.sprite = questUI.image;
        rewardText.text = questUI.reward.ToString();
        diffText.text = questUI.difficulty;
    }

    private void OnEnable()
    {
        GameEventsManager.Instance.questEvents.onQuestStateChange += QuestStateChange;
    }

    private void OnDisable()
    {
        GameEventsManager.Instance.questEvents.onQuestStateChange -= QuestStateChange;
    }

    public void onStartQuest()
    {
        if(currentQuestState.Equals(QuestState.CAN_START) && startPoint)
        {
            GameEventsManager.Instance.questEvents.StartQuest(questId);
        }
        else if(currentQuestState.Equals(QuestState.CAN_FINISH) && finishpoint)
        {
            Debug.Log("button to finish quest pressed");
            GameEventsManager.Instance.questEvents.FinishQuest(questId);
        }
    }

    private void QuestStateChange(Quest quest)
    {
        //only update the quest state if this point has the corresponding quest
        if(quest.info.id.Equals(questId))
        {
            currentQuestState = quest.state;
            Debug.Log("Quest with id: " + questId + "updated to state: " + currentQuestState);
        }

    }
}
