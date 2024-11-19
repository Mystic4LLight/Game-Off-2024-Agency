using System.Collections.Generic;
using System.Linq;
//using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIMissionPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI missionName;
    [SerializeField] private Image missionImage;
    [SerializeField] private TextMeshProUGUI missionDescription;
    private Mission mission;

    public void OnEnable()
    {
             
    }

    //public global::System.String MissionName { get => missionName; set => missionName = value; }
    //public Image MissionImage { get => missionImage; set => missionImage = value; }
    //public global::System.String MissionDescription { get => missionDescription; set => missionDescription = value; }
    public Mission Mission { get => mission; set => mission = value; }

    void Start()
    {
        
    }
    public void setMission(Mission newMission)
    {
        mission = newMission;
        missionName.text = mission.MissionName;
        missionImage.sprite = mission.missionImage;
        missionDescription.text = mission.Description;
    }

    // Update is called once per frame
    void Update()
    {
            
    }
    

}
