using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [Header("Inventory Panel")]
    [SerializeField]public GameObject InventoryMenu;

    [Header("Inventory Slots")]
    [SerializeField] ItemSlot[] ItemSlot;

    [Header("Camera - Canvas")]
    [SerializeField]public GameObject CameraCanvas;

    private static List<Sprite> photoSprites = new List<Sprite>();

    private bool menuActivated;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            InventoryMenu.SetActive(!menuActivated);
            CameraCanvas.SetActive(menuActivated);
            menuActivated = !menuActivated;
            
        }
    }

    public void AddPhotoSprite(Sprite photoSprite)
    {
        for (int i = 0; i < ItemSlot.Length; i++)
        {
            if (!ItemSlot[i].hasPhoto)
            {
                ItemSlot[i].AddPhotoSprite(photoSprite);
                Debug.Log($"Photo added to slot {i}");
                return;
            }
        }
        Debug.LogWarning("No empty slot available for the photo.");
    }

    public void ClearPhotoSprite()
    {
        photoSprites.Clear();
        Debug.Log("Photo Album cleared.");
    }

}
