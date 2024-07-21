using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
public class QuestLogScrollingList : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject contentParent;
    [SerializeField] private GameObject TaskLogUI;
    [Header("Quest Log Button")]
    [SerializeField] private GameObject questLogButtonPrefab;

    private Dictionary<string, QuestLogButton> idToButtonMap = new Dictionary<string, QuestLogButton>();

    //Below is code to test that the scrolling list is working as expected.
    //For it to work, you'll need to change the QuestInfoSO id field to be publicly settable
    //private void Start()
    //{
    //    for (int i = 0; i < 20; i++)
    //    {
    //        QuestInfoSO questInfoTest = ScriptableObject.CreateInstance<QuestInfoSO>();
    //        questInfoTest.id = "test_" + i;
    //        questInfoTest.displayName = "Test " + i;
    //        questInfoTest.questStepPrefabs = new GameObject[0];
    //        Quest quest = new Quest(questInfoTest);

    //        QuestLogButton questLogButton = CreateButtonIfNotExists(quest, () =>
    //        {
    //            Debug.Log("Selected: " + questInfoTest.displayName);
    //        });

    //        if (i == 0)
    //        {
    //            questLogButton.button.Select();
    //            ;
    //        }
    //    }
    //}
    public QuestLogButton CreateButtonIfNotExists(Quest quest, UnityAction selectAction)
    {
        QuestLogButton questLogButton = null;
        //only create the if we havent seen this quest id before
        if (!idToButtonMap.ContainsKey(quest.info.id))
        {
            questLogButton = InstantiateQuestLogButton(quest, selectAction);
            questLogButton.uiPanel = TaskLogUI;
        }
        else
        {
            questLogButton = idToButtonMap[quest.info.id];
        }
        return questLogButton;
    }
   private QuestLogButton InstantiateQuestLogButton(Quest quest, UnityAction selectAction)
    {
        // create the button
        QuestLogButton questLogButton = Instantiate(questLogButtonPrefab, contentParent.transform).GetComponent<QuestLogButton>();
        questLogButton.gameObject.GetComponent<QuestPoint>().questInfoForPoint = quest.info;
        // game object name in the scene
        questLogButton.gameObject.name = quest.info.id + "_button";
        // initialize and set up function for when the button is selected
        questLogButton.Initialize(quest, selectAction);
        // add to map to keep track of the new button
        idToButtonMap[quest.info.id] = questLogButton;
        return questLogButton;
    }
}
