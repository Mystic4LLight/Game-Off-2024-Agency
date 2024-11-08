using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AgentPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI agentName;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private Image profilePhoto;
    [SerializeField] private TextMeshProUGUI strength;
    [SerializeField] private TextMeshProUGUI speed;
    [SerializeField] private TextMeshProUGUI intelligence;
    [SerializeField] public AgentSO agentSO;
    public bool isClicked = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void clickButton(){
        isClicked = true;
    }
    public void fillPanel(){
        
        agentName.text = agentSO.name;
        description.text = agentSO.description;
        profilePhoto.sprite = agentSO.profilePhoto;
        strength.text = agentSO.strength.ToString();
        speed.text = agentSO.speed.ToString();
        intelligence.text = agentSO.intelligence.ToString();
    }

}
