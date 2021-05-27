using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    public GameObject MenuPanel;
    public GameObject GlobePanel;
    public GameObject FriendsPanel;

    public void OpenGlobePanel() {
      if (GlobePanel != null) {
        GlobePanel.SetActive(true);
      }
    }

    public void CloseGlobePanel() {
      if (GlobePanel != null) {
        GlobePanel.SetActive(false);
      }
    }

    public void OpenFriendsPanel() {
      if (FriendsPanel != null) {
        FriendsPanel.SetActive(true);
      }
    }

    public void CloseFriendsPanel() {
      if (FriendsPanel != null) {
        FriendsPanel.SetActive(false);
      }
    }


}
