using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New QuestUI", menuName = "ScriptableObjects/QuestUI")]
public class QuestUI : ScriptableObject
{
    public string title;
    public string description;

    public Sprite image;
    public int reward;
    public string difficulty;
}
