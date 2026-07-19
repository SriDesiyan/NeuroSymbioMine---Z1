using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera[] cameras;

    private int currentCamera = 0;

    void Start()
    {
        SwitchCamera(0);
    }

    void Update()
    {
        // Press Space to go to the next camera
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentCamera++;

            if (currentCamera >= cameras.Length)
                currentCamera = 0;

            SwitchCamera(currentCamera);
        }
    }

    // Called by UI buttons
    public void SwitchCamera(int index)
    {
        if (index < 0 || index >= cameras.Length)
            return;

        currentCamera = index;

        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(i == currentCamera);
        }
    }

    // Optional: Next Camera (can also be called from a UI button)
    public void NextCamera()
    {
        currentCamera++;

        if (currentCamera >= cameras.Length)
            currentCamera = 0;

        SwitchCamera(currentCamera);
    }
}