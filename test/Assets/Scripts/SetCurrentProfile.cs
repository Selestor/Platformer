using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SetCurrentProfile : MonoBehaviour {

    public Dropdown dropdown;
    public RawImage image;

    public void CurrentProfile()
    {
        string currentProfileName = dropdown.captionText.text;
        foreach (PlayerSettings.Profile profile in PlayerSettings.settings.profileList)
        {
            if (profile.profileName == currentProfileName)
            {
                profile.isCurrent = true;
                WWW www = new WWW(profile.avatarPath);
                if (profile.avatarPath != "") image.texture = www.texture;
                else image.texture = null;
            }
            else profile.isCurrent = false;
        }
    }
}
