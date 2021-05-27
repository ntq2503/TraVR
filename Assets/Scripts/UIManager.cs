using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class UIManager : MonoBehaviour
{
    public SteamVR_Action_Boolean toggleInventoryCanvas;
    public SteamVR_Action_Boolean toggleTasksCanvas;
    public SteamVR_Input_Sources handLeft;
    public SteamVR_Input_Sources handRight;
    public GameObject inventory;
    public GameObject tasksList;

    // Start is called before the first frame update
    void Start()
    {
        toggleInventoryCanvas.AddOnStateDownListener(ToggleInventoryCanvas, handLeft);
        toggleTasksCanvas.AddOnStateDownListener(ToggleTasksCanvas, handRight);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToggleInventoryCanvas(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if (tasksList.activeInHierarchy)
            tasksList.SetActive(false);
        inventory.SetActive(!inventory.activeInHierarchy);
    }

    public void ToggleTasksCanvas(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if (inventory.activeInHierarchy)
            inventory.SetActive(false);
        tasksList.SetActive(!tasksList.activeInHierarchy);
    }
}
