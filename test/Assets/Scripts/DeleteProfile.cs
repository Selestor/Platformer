using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteProfile : MonoBehaviour {

    public Dropdown dropdown;

    public void Delete()
    {
        dropdown.options.RemoveAt(dropdown.value);
        PlayerSettings.settings.profileList.Remove(PlayerSettings.settings.profileList.Find(i => i.profileName == dropdown.captionText.text));
        dropdown.value = 0;
    }
}
