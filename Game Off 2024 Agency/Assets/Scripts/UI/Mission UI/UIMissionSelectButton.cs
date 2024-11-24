using UnityEngine;

public class UIMissionSelectButton : MonoBehaviour
{
    private Mission selectedMission;
    
    void OnEnable()
    {
        selectedMission = GetComponentInParent<UIMissionPanel>().Mission;
    }

    public void selectMission()
    {
        GetComponentInParent<UIMissionMenu>().SelectedMission = selectedMission;
    }
 
}
