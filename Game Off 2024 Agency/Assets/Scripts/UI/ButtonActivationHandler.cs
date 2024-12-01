using UnityEngine;
using UnityEngine.UI;

public class ButtonActivationHandler : MonoBehaviour
{
    public Transform specificParent; // Assign the specific GameObject (parent) to monitor in the Inspector
    private Button button; 

    private void Awake()
    {
        // Get the button component
        button = GetComponent<Button>();
        UIInitializationManager.Instance?.RegisterAgentButton(this.GetComponent<SelectAgentButton>());
    }

    private void OnTransformParentChanged()
    {
        // Check if the button's parent is the specific parent
        if (transform.parent == specificParent)
        {
            // If the button is a child of the specific parent, deactivate it
            button.interactable = false;
            gameObject.SetActive(false);
            Debug.Log($"{gameObject.name} deactivated as it's now a child of {specificParent.name}");
        }
        else
        {
            // If the button leaves the specific parent, reactivate it
            gameObject.SetActive(true);
            button.interactable = true;
            Debug.Log($"{gameObject.name} reactivated as it has left {specificParent.name}");
        }
    }
}
