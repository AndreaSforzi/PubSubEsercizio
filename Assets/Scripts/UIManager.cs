using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI lvlText;
    [SerializeField] TextMeshProUGUI expText;
    [SerializeField] TextMeshProUGUI nextLevelExpText;

    

    private void Start()
    {

        PubSub.Instance.RegisterdFunction(MessageType.EXPCollected, OnEXPCollected);
        PubSub.Instance.RegisterdFunction(MessageType.LvlUp, OnLevelUp);
        nextLevelExpText.text = Player.Instance.expNeededToLevelUp.ToString();
    }

    void OnLevelUp(object content)
    {
        if (content is not int)
            return;

        lvlText.text = content.ToString();
        expText.text = "0";
        nextLevelExpText.text = Player.Instance.expNeededToLevelUp.ToString();
    }

    void OnEXPCollected(object content)
    {
        if (content is not int)
            return;

        expText.text = content.ToString();
    }
}
