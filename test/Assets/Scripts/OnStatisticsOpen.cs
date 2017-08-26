using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnStatisticsOpen : MonoBehaviour {

    public Text bestTime;
    public Text gamesPlayed;

    public void StatisticsUpdate()
    {
        PlayerSettings.Profile currentProfile = PlayerSettings.settings.profileList.Find(i => i.isCurrent == true);

        if (currentProfile != null)
        {
            bestTime.text = "The Best Time: " + currentProfile.bestTime;
            gamesPlayed.text = "Games Played: " + currentProfile.gamesPlayed;
        }
        else
        {
            bestTime.text = "The Best Time: " + "???";
            gamesPlayed.text = "Games Played: " + "???";
        }
    }
}
