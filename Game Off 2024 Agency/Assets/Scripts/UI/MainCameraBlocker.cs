using UnityEngine;

public class MainCameraBlocker : MonoBehaviour
{
    [SerializeField]
    private bool blocksInput = true; // Flag to determine if this blocker should block input

    private void OnEnable()
    {
        if (blocksInput)
        {
            UIManager.AddCameraBlocker(this);
        }
    }

    private void OnDisable()
    {
        if (blocksInput)
        {
            UIManager.RemoveCameraBlocker(this);
        }
    }
}
