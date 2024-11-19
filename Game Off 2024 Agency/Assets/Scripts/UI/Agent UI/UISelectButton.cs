using UnityEngine;

public class UISelectButton : MonoBehaviour
{
    [SerializeField] private UIAgentPanel selectedPanel;
    
    void Start()
    {
        selectedPanel = GetComponentInParent<UIAgentPanel>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setSelectedSO()
    {
        if (selectedPanel != null)
        {
            GetComponentInParent<UIRecruitmentScreen>().setAgentSO(selectedPanel.getAgentSO());
        }
    }

}
