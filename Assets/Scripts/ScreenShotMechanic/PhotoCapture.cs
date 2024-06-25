using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PhotoCapture : MonoBehaviour
{
    [Header("Photo Taker")]
    [SerializeField] private Image photoDisplayArea;
    [SerializeField] private GameObject photoFrame;
    [SerializeField] private GameObject cameraUI;
    [SerializeField] TextMeshProUGUI ShotsRemainingDisplay;

    [Header("Flash Effect")]
    [SerializeField] private GameObject cameraFlash;
    [SerializeField] private float flashTime;

    [Header("Photo Fader Effect")]
    [SerializeField] private Animator fadingAnimation;

    [Header("Cooldown Settings")]
    [SerializeField] private float photoCooldown = 2f; // Cooldown period between taking photos
    private float lastPhotoTime; // Time when the last photo was taken

    [Header("Audio")]
    [SerializeField] private AudioSource cameraAudio;

    [Header("Inventory Manager")]
    [SerializeField] private InventoryManager inventoryManager;
    private Texture2D screenCapture;

    private bool viewingPhoto;
    private int shotsRemaining;
    private int shotsAvailable = 6;
    private void Start()
    {
        shotsRemaining = shotsAvailable;

        screenCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

        ShotsRemainingDisplay.text = $"{(shotsAvailable - shotsRemaining)}/{shotsAvailable}";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!viewingPhoto && Time.time - lastPhotoTime > photoCooldown)
            {
                if(shotsRemaining != 0)
                {
                    StartCoroutine(CapturePhoto());
                    lastPhotoTime = Time.time; // Update the last photo time
                    shotsRemaining--;
                    ShotsRemainingDisplay.text = $"{(shotsAvailable - shotsRemaining)}/{shotsAvailable}";
                }    
            }
            else if (viewingPhoto)
            {
                RemovePhoto();
            }
        }
    }

    IEnumerator CapturePhoto()
    {
        cameraUI.SetActive(false);
        viewingPhoto = true;

        yield return new WaitForEndOfFrame();

        Rect regionToRead = new Rect (0, 0, Screen.width,Screen.height);

        screenCapture.ReadPixels(regionToRead, 0, 0, false);
        screenCapture.Apply();
        ShowPhoto();
    }

    void ShowPhoto()
    {
        Sprite photoSprite = Sprite.Create(screenCapture, new Rect(0.0f, 0.0f, screenCapture.width, screenCapture.height), new Vector2(0.5f, 0.5f), 100.0f);
        photoDisplayArea.sprite = photoSprite;

        inventoryManager.AddPhotoSprite(photoSprite);

        photoFrame.SetActive(true);
        StartCoroutine(CameraFlashEffect());
        fadingAnimation.Play("PhotoFade");

        //ADD THIS
        screenCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
    }

    IEnumerator CameraFlashEffect()
    {
        cameraAudio.Play();
        cameraFlash.SetActive(true);
        yield return new WaitForSeconds(flashTime);
        cameraFlash.SetActive(false);
    }    
    void RemovePhoto()
    {
        viewingPhoto = false;
        photoFrame.SetActive(false);
        cameraUI.SetActive(true);
    }
}
