using UnityEngine;
using UnityEngine.UI;

public class CreateNewProfile : MonoBehaviour {

    public Dropdown dropdown;
    public Text profileName;

	public void CreateProfile()
    {
        string name = profileName.text;

        if (PlayerSettings.settings.profileList.Find(i => i.profileName == name) != null)
            print("Profile named " + name + " already exists.");
        else
        {
            PlayerSettings.Profile profile = new PlayerSettings.Profile();
            profile.profileName = name;
            profile.gamesPlayed = 0;
            profile.bestTime = 60;
            profile.isCurrent = false;
            profile.avatarPath = "";
            PlayerSettings.settings.profileList.Add(profile);
            dropdown.options.Add(new Dropdown.OptionData() { text = profile.profileName });
            dropdown.value = 1;
            dropdown.value = 0;
        }
    }
}
