using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    //Item Data
    public Sprite photoSprite;
    public bool hasPhoto = false;

    // ADD THIS
    public Texture2D photoTexture;

    //Item Slot
    [SerializeField] private Image itemImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPhotoSprite(Sprite photoSprite)
    {
        this.photoSprite = photoSprite;
        this.itemImage.gameObject.SetActive(true);
        this.itemImage.sprite = this.photoSprite;
        this.hasPhoto = true;
        
    }
}
