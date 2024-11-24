using UnityEngine;

public class UIMissionConfirmButton : MonoBehaviour
{
    [SerializeField] private UIAgentSelectMenu uiAgentSelectMenu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ConfirmMission()
    {
        uiAgentSelectMenu.Mission = GetComponentInParent<UIMissionMenu>().SelectedMission;
    }
}
