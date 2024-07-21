using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class SubtitleClip : PlayableAsset
{
    public string subtitleText;
    public float typingSpeed = 0.05f; // Default speed in seconds per character
    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<SubtitleBehavior>.Create(graph);

        SubtitleBehavior subtitleBehavior = playable.GetBehaviour();
        subtitleBehavior.subtitleText = subtitleText;
        subtitleBehavior.typingSpeed = typingSpeed;

        return playable;
    }

}
