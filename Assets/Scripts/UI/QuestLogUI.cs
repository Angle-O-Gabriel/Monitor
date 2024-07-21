using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class QuestLogUI : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject contentParent;
    [SerializeField] private QuestLogScrollingList scrollingList;
    [SerializeField] private TextMeshProUGUI questDisplayNameText;
    [SerializeField] private TextMeshProUGUI questClientNameText;
    [SerializeField] private TextMeshProUGUI questDescriptionText;
    [SerializeField] private TextMeshProUGUI moneyRewardsText;
    [SerializeField] private TextMeshProUGUI locationText;

    private void OnEnable()
    {
        GameEventsManager.Instance.questEvents.onQuestStateChange += QuestStateChange;
    }
    private void OnDisable()
    {
        GameEventsManager.Instance.questEvents.onQuestStateChange -= QuestStateChange;
    }
    private void QuestStateChange(Quest quest)
    {
        QuestLogButton questLogButton = scrollingList.CreateButtonIfNotExists(quest, () =>
        {
            SetQuestInfo(quest);
        });

        questLogButton.SetState(quest.state);
    }
    private void SetQuestInfo(Quest quest)
    {
        // quest name
        questDisplayNameText.text = quest.info.displayName;

        // client name
        questClientNameText.text = quest.info.clientName;

        // 
        questDescriptionText.text = quest.info.description;

        // Rewards
        moneyRewardsText.text = "$ " + quest.info.MoneyReward.ToString();

        // location
        locationText.text = quest.info.location;
    }    
}
