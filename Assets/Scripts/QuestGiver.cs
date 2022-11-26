using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public Eammon player;

    public GameObject questWindows;
    public Text titleText;
    public Text descriptionText;
    public Text goldText;

    public void OpenQuestWindows()
    {
        questWindows.SetActive(true);
        titleText.text = quest.title;
        descriptionText.text = quest.description;
        goldText.text = quest.goldReward.ToString();
    }

    public void AcceptQuest()
    {
        questWindows.SetActive(false);
        quest.isActive = true;
        player.quest = quest;
        // give to player
    }
}
