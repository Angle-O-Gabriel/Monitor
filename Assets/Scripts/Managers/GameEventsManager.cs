using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventsManager : MonoBehaviour
{
    public static GameEventsManager Instance { get; private set; }

    public MiscEvents miscEvents;
    public QuestEvents questEvents;
    public MoneyEvents moneyEvents;
    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("Found more than one GameEventsManager in the scene");
        }

        Instance = this;
        miscEvents = new MiscEvents();
        questEvents = new QuestEvents();
        moneyEvents = new MoneyEvents();
    }
}
