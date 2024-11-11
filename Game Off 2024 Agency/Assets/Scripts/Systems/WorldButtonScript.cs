using UnityEngine;

public class WorldButtonScript : MonoBehaviour
{
    public GameObject targetWindow;  // The window that the world button will open
    private Renderer buttonRenderer;  // To change the button's color on hover and click
    public Color hoverColor = Color.green;  // Color when mouse hovers
    public Color clickColor = Color.blue;  // Color when mouse clicks
    private Color originalColor;  // Store the original color of the button
    private bool isHovered = false; // Track if the player is hovering over the button

    void Start()
    {
        // Get the Renderer component to change color
        buttonRenderer = GetComponent<Renderer>();
        originalColor = buttonRenderer.material.color;  // Save the original color
    }

    void Update()
    {
        // Raycast to detect if the mouse clicked while hovering
        if (isHovered && Input.GetMouseButtonDown(0)) // 0 is the left mouse button
        {
            OnWorldButtonClicked(); // Trigger the button click action
        }
    }

    // Handle raycast hover detection
    void OnMouseEnter()
    {
        isHovered = true;
        // Change the button color to indicate hover
        buttonRenderer.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        isHovered = false;
        // Reset the button color back to the original color
        buttonRenderer.material.color = originalColor;
    }

    // Simulate the "click" behavior of opening a specific window
    public void OnWorldButtonClicked()
    {
        if (targetWindow != null)
        {
            UIManager.Instance.OpenWindow(targetWindow); // Open the specified window
            buttonRenderer.material.color = clickColor;  // Change color on click
            Debug.Log("World Window Opened!");
        }
    }
}
