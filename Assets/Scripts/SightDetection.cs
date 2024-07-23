using UnityEngine;

public class SightDetection : MonoBehaviour
{
    public string targetTag = "PlayerHolder"; // Tag of the object you want to detect (set in the Inspector)

    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering collider has the tag we are looking for
        if (other.CompareTag(targetTag))
        {
            isDetected = true;
            Debug.Log(targetTag + " detected!");
        }
    }

}
