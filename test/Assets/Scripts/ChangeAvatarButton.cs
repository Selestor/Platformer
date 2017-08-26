using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ChangeAvatarButton : MonoBehaviour {

    public RawImage image;

    public void ChangeAvatar()
    {
        PlayerSettings.Profile currentProfile = PlayerSettings.settings.profileList.Find(i => i.isCurrent == true);
        if (currentProfile != null)
        {
            currentProfile.avatarPath = EditorUtility.OpenFilePanel("", "", "png");

            if (currentProfile.avatarPath != "")
            {
                WWW www = new WWW(currentProfile.avatarPath);
                image.texture = www.texture;
            }
        }
    }
}
