using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckCode : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private TextMeshProUGUI notifierText;
    [SerializeField] private TextMeshProUGUI decipherText;
    [SerializeField] private TMP_InputField inputTextField;
    [SerializeField] private TextMeshProUGUI timerText;

    private float currenttime;
    private float startingtime = 10.5f;

    // Start is called before the first frame update
    void Start()
    {
        currenttime = startingtime;
        notifierText.gameObject.SetActive(false);
        Debug.Log(currenttime);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.activeInHierarchy)
        {
            currenttime -= Time.unscaledDeltaTime;
            timerText.text = $"{currenttime:F0}s";
            Debug.Log(currenttime);
            if(currenttime < 0)
            {
                currenttime = 0;
                StartCoroutine(CloseWindowAfter2());
            }
        }
    }

    public void CheckCodeIfCorrect()
    {
        switch (inputTextField.text)
        {
            case "tite":
                Debug.Log("typed tite");
                decipherText.text = inputTextField.text;
                StartCoroutine(ShowNotifierText("Deciphered Complete!", Color.green));
                StartCoroutine(CloseWindowAfter2());
                break;
            default:
                inputTextField.text = "";
                StartCoroutine(ShowNotifierText("Wrong Code", Color.red));
                break;
        }
    }

    IEnumerator ShowNotifierText(string text, Color color)
    {
        notifierText.text = text;
        notifierText.color = color;
        notifierText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        notifierText.gameObject.SetActive(false);
    }

    IEnumerator CloseWindowAfter2()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }
}
