using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(QuestPoint))]
public class QuestLogButton : MonoBehaviour, ISelectHandler
{
    public Button button { get; private set; }
    public GameObject uiPanel;
    [Header("Components")]
    [SerializeField] private TextMeshProUGUI TitleText;
    [SerializeField] private TextMeshProUGUI RewardText;
    [SerializeField] private TextMeshProUGUI DifficultyText;
    [SerializeField] private Button questButton;
    [SerializeField] private TextMeshProUGUI ButtonText;

    [Header("Colors")]
    [SerializeField] private Color initialColor;
    [SerializeField] private Color inProgressColor;
    [SerializeField] private Color claimColor;
    [SerializeField] private Color finishedColor;


    private UnityAction onSelectAction;

    public void Initialize(Quest quest, UnityAction selectAction)
    {
        this.button = this.GetComponent<Button>();
        this.TitleText.text = quest.info.displayName;
        this.RewardText.text = "$ " + quest.info.MoneyReward;
        this.DifficultyText.text = quest.info.difficulty;
        this.onSelectAction = selectAction;
    }

    public void OnSelect(BaseEventData eventData)
    {
        onSelectAction();
    }

    public void onButtonClick()
    {
        uiPanel.SetActive(true);
    }

    public void SetState(QuestState state)
    {
        ColorBlock cb = questButton.colors;
        switch (state)
        {
            case QuestState.REQUIREMENTS_NOT_MET:
            case QuestState.CAN_START:
                questButton.colors = changeButtonColor(questButton.colors, initialColor);
                ButtonText.text = "Accept";
                questButton.interactable = true;
                break;
            case QuestState.IN_PROGRESS:
                questButton.colors = changeButtonColor(questButton.colors, inProgressColor);
                ButtonText.text = "In Progress";
                questButton.interactable = false;
                break;
            case QuestState.CAN_FINISH:
                questButton.colors = changeButtonColor(questButton.colors, claimColor);
                ButtonText.text = "Claim";
                questButton.interactable = true;
                break;
            case QuestState.FINISHED:
                questButton.colors = changeButtonColor(questButton.colors, finishedColor);
                ButtonText.text = "Finished";
                questButton.interactable = false;
                break;
            default:
                Debug.LogWarning("Quest State not recognized by switch statement: " + state);
                break;
        }
        
    }

    private ColorBlock changeButtonColor(ColorBlock cb, Color color)
    {
        cb.normalColor = color;
        cb.selectedColor = color;
        cb.pressedColor = color;
        cb.disabledColor = color;

        return cb;
    }
}
