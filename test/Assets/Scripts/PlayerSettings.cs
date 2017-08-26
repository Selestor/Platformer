using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : MonoBehaviour {

    public static PlayerSettings settings;

    public class Profile
    {
        public string profileName;
        public int gamesPlayed;
        public float bestTime;
        public bool isCurrent;
    }

    public List<Profile> profileList;
    
	void Awake () {
        if (settings == null)
        {
            DontDestroyOnLoad(gameObject);
            profileList = new List<Profile>();
            settings = this;
        }
        else if(settings != this)
        {
            Destroy(this);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
