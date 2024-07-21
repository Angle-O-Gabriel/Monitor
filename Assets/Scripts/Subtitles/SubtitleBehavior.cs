using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class SubtitleBehavior : PlayableBehaviour
{
    public string subtitleText;
    public float typingSpeed = 0.05f; // Speed in seconds per character
    public float elapsedTime;
}
