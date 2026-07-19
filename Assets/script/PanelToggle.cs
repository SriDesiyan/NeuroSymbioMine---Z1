using UnityEngine;

public class PanelToggle : MonoBehaviour
{
    public GameObject cameraPanel;

    public void TogglePanel()
    {
        Debug.Log("CLICK WORKING");

        cameraPanel.SetActive(!cameraPanel.activeSelf);
    }
}