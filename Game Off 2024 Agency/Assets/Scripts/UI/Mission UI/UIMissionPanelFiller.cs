using UnityEngine;
using System.Collections.Generic;

public class UIMissionPanelFiller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Mission currentMainMission;
    [SerializeField] private List<Mission> sideMissions = new List<Mission>();
    //[SerializeField] private List<MissionSO> missionSOs = new List<MissionSO>();
    [SerializeField] private UIMissionPanel mainMissionPanel;
    [SerializeField] private List<UIMissionPanel> sideMissionPanels = new List<UIMissionPanel>();   

    private void OnEnable()
    {
        refreshMainMission();
        refreshSideMission();
        fillMissionPanels();
    }
    public void fillMissionPanels()
    {
        if (currentMainMission != null)
        {
            mainMissionPanel.setMission(currentMainMission);
        }
        for (int i = 0; i < sideMissionPanels.Count; i++)
        {
            if (sideMissions[i] != null)
            {
                sideMissionPanels[i].setMission(sideMissions[i]);
            }
        }
    }
    public void refreshMainMission()
    {
        currentMainMission = MissionManager.Instance.getAvaiableMainMission(0);
    }
    public void refreshSideMission()
    {
        for (int i = 0; i < 2; i++)
        {
            if (MissionManager.Instance.getAvaiableSideMission(i) != null)
                sideMissions.Add(MissionManager.Instance.getAvaiableSideMission(i));
        }
    }

}
