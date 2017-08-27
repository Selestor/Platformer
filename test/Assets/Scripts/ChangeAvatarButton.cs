using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ChangeAvatarButton : MonoBehaviour {

    public RawImage image;

    public void ChangeAvatar()
    {
        PlayerSettings.Profile currentProfile = PlayerSettings.settings.profileList.Find(i => i.isCurrent == true);
        if (currentProfile != null)
        {
#if UNITY_EDITOR
            currentProfile.avatarPath = EditorUtility.OpenFilePanel("", "", "png");
#endif
            if (currentProfile.avatarPath != "")
            {
                StartCoroutine(FinishDownload(currentProfile.avatarPath));
            }
        }
    }

    public IEnumerator FinishDownload(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        image.texture = www.texture;
    }
}
