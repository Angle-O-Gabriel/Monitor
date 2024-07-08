using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadHomeScene : MonoBehaviour
{

    public void LoadHome()
    {
        SceneManager.LoadScene("HomeScene");
    }
}

