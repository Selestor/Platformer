using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnProfileOpen : MonoBehaviour {

    public Dropdown dropdown;
    public RawImage image;

	public void UpdateDropdown()
    {
        int id = 0;
        int selectedId = 0;
        string avatar = "";
        image.texture = null;
        dropdown.options.Clear();
        foreach (PlayerSettings.Profile profile in PlayerSettings.settings.profileList)
        {
            if (profile.isCurrent)
            {
                selectedId = id;
                avatar = profile.avatarPath;
            }
            else id++; 
            dropdown.options.Add(new Dropdown.OptionData() { text = profile.profileName });
        }
        dropdown.value = 1;
        dropdown.value = 0;
        dropdown.value = selectedId;

        if (avatar != "")
        {
            WWW www = new WWW(avatar);
            image.texture = www.texture;
        }
    }
}
