using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteProfile : MonoBehaviour {

    public Dropdown dropdown;
    public RawImage image;

    public void Delete()
    {
        dropdown.options.RemoveAt(dropdown.value);
        image.texture = null;
        PlayerSettings.Profile profile = PlayerSettings.settings.profileList.Find(i => i.profileName == dropdown.captionText.text);
        PlayerSettings.settings.profileList.Remove(profile);
        dropdown.value = 1;
        dropdown.value = 0;
    }
}
