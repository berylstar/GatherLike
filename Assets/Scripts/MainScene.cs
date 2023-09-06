using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainScene : MonoBehaviour
{
    public TextMeshProUGUI nicknameText;

    private void Start()
    {
        nicknameText.text = IntroScript.nickname;
    }
}
