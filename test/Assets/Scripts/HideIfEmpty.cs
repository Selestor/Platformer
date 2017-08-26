using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideIfEmpty : MonoBehaviour {

    public Dropdown dropdown;
    public Button delete;

    void Update () {
        if (dropdown.options.Count == 0)
        {
            dropdown.gameObject.SetActive(false);
            delete.gameObject.SetActive(false);
        }
        else
        {
            dropdown.gameObject.SetActive(true);
            delete.gameObject.SetActive(true);
        }
    }
}
