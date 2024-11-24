using System.Collections.Generic;
using System.Linq;
//using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class UIInfoButton : MonoBehaviour
{
    [SerializeField] private UIAgentPanel agentPanel;
    [SerializeField] private UIAgentFile agentFile;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
           
    }
    public void openFile()
    {
        if (agentPanel.getAgentSO() != null)
        {
            agentFile.setAgentSO(agentPanel.getAgentSO());
            agentFile.transform.gameObject.SetActive(true);
        }
    }

}
