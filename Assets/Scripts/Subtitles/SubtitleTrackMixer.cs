using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using TMPro;

public class SubtitleTrackMixer : PlayableBehaviour
{
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        TextMeshProUGUI text = playerData as TextMeshProUGUI;
        string currentText = "";
        float currentAlpha = 0f;
        float currentElapsedTime = 0f;
        float currentTypingSpeed = 0.05f;

        if (!text) { return; }

        int inputCount = playable.GetInputCount();
        for (int i = 0; i < inputCount; i++) 
        {
            float inputWeight = playable.GetInputWeight(i);

            if (inputWeight > 0f) 
            {
                ScriptPlayable<SubtitleBehavior> inputPlayable = (ScriptPlayable<SubtitleBehavior>)playable.GetInput(i);

                SubtitleBehavior input = inputPlayable.GetBehaviour();
                currentText = input.subtitleText;
                currentAlpha = inputWeight;
                currentElapsedTime = input.elapsedTime;
                currentTypingSpeed = input.typingSpeed;

                // Update elapsed time
                input.elapsedTime += info.deltaTime;
            }
        }

        // Calculate the number of characters to display based on elapsed time and typing speed
        int charCount = Mathf.Min(currentText.Length, Mathf.FloorToInt(currentElapsedTime / currentTypingSpeed));

        // Update the UI text and color
        text.text = currentText.Substring(0, charCount);
        text.color = new Color(1, 1, 1, currentAlpha);
    }
}
