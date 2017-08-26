using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnProfileOpen : MonoBehaviour {

    public Dropdown dropdown;

	public void UpdateDropdown()
    {
        int id = 0;
        int selectedId = 0;
        dropdown.options.Clear();
        foreach (PlayerSettings.Profile profile in PlayerSettings.settings.profileList)
        {
            if (profile.isCurrent) selectedId = id;
            else id++; 
            dropdown.options.Add(new Dropdown.OptionData() { text = profile.profileName });
        }
        dropdown.value = 1;
        dropdown.value = 0;
        dropdown.value = selectedId;
    }
}
