using UnityEngine;

public class RecruitMenuButton : MonoBehaviour
{
    [SerializeField] private GameObject agentSelectMenu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void turnOnAgentSelect(){
        agentSelectMenu.SetActive(true);
    }
}
