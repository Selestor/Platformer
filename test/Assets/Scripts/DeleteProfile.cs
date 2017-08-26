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
        image.material.mainTexture = null;
        PlayerSettings.settings.profileList.Remove(PlayerSettings.settings.profileList.Find(i => i.profileName == dropdown.captionText.text));
        dropdown.value = 0;
    }
}
