using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnStatisticsOpen : MonoBehaviour {

    public Text bestTime;
    public Text gamesPlayed;

    public void StatisticsUpdate()
    {
        if (PlayerPrefs.HasKey("Best Time"))
            bestTime.text = "The Best Time: " + PlayerPrefs.GetFloat("Best Time");
        else bestTime.text = "The Best Time: " + "???";

        if (PlayerPrefs.HasKey("Games Played"))
            gamesPlayed.text = "Games Played: " + PlayerPrefs.GetInt("Games Played");
        else gamesPlayed.text = "Games Played: " + 0;
    }
}
