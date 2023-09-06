using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class IntroScript : MonoBehaviour
{
    public Button joinButton;
    public TextMeshProUGUI inputText;

    public static string nickname = "";

    public void Join()
    {
        if (inputText.text.Length < 2)
            return;

        nickname = inputText.text;

        SceneManager.LoadScene("MainScene");
    }
}
