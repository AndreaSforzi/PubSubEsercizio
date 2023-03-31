using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI textMeshQuestName;
    [SerializeField] TextMeshProUGUI textMeshQuestObjective;

    public int currentLevelObjective = 2;
    
    private void Start()
    {
        PubSub.Instance.RegisterdFunction(MessageType.LvlUp, OnLevelUp);
        textMeshQuestName.text = $"From {0} to {currentLevelObjective}";
        textMeshQuestObjective.text = $"Reach level {currentLevelObjective}";
    }

    void OnLevelUp(object content)
    {
        if(Player.Instance.Lvl >= currentLevelObjective)
        {
            textMeshQuestName.text = $"From {currentLevelObjective} to {currentLevelObjective += 2}";
            textMeshQuestObjective.text = $"Reach level {currentLevelObjective}";
        }
    }
}
