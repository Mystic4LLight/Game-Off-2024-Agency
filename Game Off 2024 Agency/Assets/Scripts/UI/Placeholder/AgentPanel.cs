using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AgentPanel : MonoBehaviour
{
    // Corris: shoud be Agent, not AgentSO 
    [SerializeField] public Agent agent;

    [SerializeField] public AgentSO agentSO;
    [SerializeField] private TextMeshProUGUI agentName;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private Image profilePhoto;
    [Header("Stats")]
    [SerializeField] private TextMeshProUGUI strength;
    [SerializeField] private TextMeshProUGUI constitution;
    [SerializeField] private TextMeshProUGUI size;
    [SerializeField] private TextMeshProUGUI dexterity;
    [SerializeField] private TextMeshProUGUI appearance;
    [SerializeField] private TextMeshProUGUI education;
    [SerializeField] private TextMeshProUGUI intelligence;
    [SerializeField] private TextMeshProUGUI power;
    [Header("Abilities")]
    [SerializeField] private TextMeshProUGUI accounting;
    [SerializeField] private TextMeshProUGUI anthropology;
    [SerializeField] private TextMeshProUGUI appraise;
    [SerializeField] private TextMeshProUGUI archaeology;
    [SerializeField] private TextMeshProUGUI artCraft1;
    [SerializeField] private TextMeshProUGUI artCraft2;
    [SerializeField] private TextMeshProUGUI artCraft3;
    [SerializeField] private TextMeshProUGUI charm;
    [SerializeField] private TextMeshProUGUI climb;
    [SerializeField] private TextMeshProUGUI computerUse;
    [SerializeField] private TextMeshProUGUI creditRating;
    [SerializeField] private TextMeshProUGUI cthulhuMythos;
    [SerializeField] private TextMeshProUGUI disguise;
    [SerializeField] private TextMeshProUGUI dodge;
    [SerializeField] private TextMeshProUGUI driveAuto;
    [SerializeField] private TextMeshProUGUI elecRepair;
    [SerializeField] private TextMeshProUGUI electronics;
    [SerializeField] private TextMeshProUGUI fastTalk;
    [SerializeField] private TextMeshProUGUI fightingBrawl;
    [SerializeField] private TextMeshProUGUI fighting2;
    [SerializeField] private TextMeshProUGUI fighting3;
    [SerializeField] private TextMeshProUGUI firearmsAiming;
    [SerializeField] private TextMeshProUGUI firearmsHipshot;
    [SerializeField] private TextMeshProUGUI firearms3;
    [SerializeField] private TextMeshProUGUI firstAid;
    [SerializeField] private TextMeshProUGUI history;
    [SerializeField] private TextMeshProUGUI intimidate;
    [SerializeField] private TextMeshProUGUI jump;
    [SerializeField] private TextMeshProUGUI languageOther1;
    [SerializeField] private TextMeshProUGUI languageOther2;
    [SerializeField] private TextMeshProUGUI languageOwn;
    [SerializeField] private TextMeshProUGUI law;
    [SerializeField] private TextMeshProUGUI libraryUse;
    [SerializeField] private TextMeshProUGUI listen;
    [SerializeField] private TextMeshProUGUI locksmith;
    [SerializeField] private TextMeshProUGUI mechRepair;
    [SerializeField] private TextMeshProUGUI medicine;
    [SerializeField] private TextMeshProUGUI naturalWorld;
    [SerializeField] private TextMeshProUGUI navigate;
    [SerializeField] private TextMeshProUGUI occult;
    [SerializeField] private TextMeshProUGUI opHvMachine;
    [SerializeField] private TextMeshProUGUI persuade;
    [SerializeField] private TextMeshProUGUI pilot;
    [SerializeField] private TextMeshProUGUI psychology;
    [SerializeField] private TextMeshProUGUI psychanalysis;
    [SerializeField] private TextMeshProUGUI science1;
    [SerializeField] private TextMeshProUGUI science2;
    [SerializeField] private TextMeshProUGUI science3;
    [SerializeField] private TextMeshProUGUI sleightOfHand;
    [SerializeField] private TextMeshProUGUI spotHidden;
    [SerializeField] private TextMeshProUGUI stealth;
    [SerializeField] private TextMeshProUGUI survival1;
    [SerializeField] private TextMeshProUGUI swim;
    [SerializeField] private TextMeshProUGUI throw1;
    [SerializeField] private TextMeshProUGUI track;
    [SerializeField] private TextMeshProUGUI other1;
    [SerializeField] private TextMeshProUGUI other2;
    [SerializeField] private TextMeshProUGUI other3;
    [SerializeField] private TextMeshProUGUI other4;
    [SerializeField] private TextMeshProUGUI other5;
    public bool isClicked = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (agent != null)
            Update_Stat();
    }

    void Update_Stat()
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
        constitution.text = agentSO.constitution.ToString();
        size.text = agentSO.size.ToString();
        dexterity.text = agentSO.dexterity.ToString();
        appearance.text = agentSO.appearance.ToString();
        education.text = agentSO.education.ToString();
        intelligence.text = agentSO.intelligence.ToString();
        power.text = agentSO.power.ToString();

        accounting.text = agentSO.accounting.ToString();
        anthropology.text = agentSO.anthropology.ToString();
        appraise.text = agentSO.appraise.ToString();
        archaeology.text = agentSO.archaeology.ToString();
        artCraft1.text = agentSO.artCraft1.ToString();
        artCraft2.text = agentSO.artCraft2.ToString();
        artCraft3.text = agentSO.artCraft3.ToString();
        charm.text = agentSO.charm.ToString();
        climb.text = agentSO.climb.ToString();
        computerUse.text = agentSO.computerUse.ToString();
        creditRating.text = agentSO.creditRating.ToString();
        cthulhuMythos.text = agentSO.cthulhuMythos.ToString();
        disguise.text = agentSO.disguise.ToString();
        dodge.text = agentSO.dodge.ToString();
        driveAuto.text = agentSO.driveAuto.ToString();
        elecRepair.text = agentSO.elecRepair.ToString();
        electronics.text = agentSO.electronics.ToString();
        fastTalk.text = agentSO.fastTalk.ToString();
        fightingBrawl.text = agentSO.fightingBrawl.ToString();
        fighting2.text = agentSO.fighting2.ToString();
        fighting3.text = agentSO.fighting3.ToString();
        firearmsAiming.text = agentSO.firearmsAiming.ToString();
        firearmsHipshot.text = agentSO.firearmsHipshot.ToString();
        firearms3.text = agentSO.firearms3.ToString();
        firstAid.text = agentSO.firstAid.ToString();
        history.text = agentSO.history.ToString();
        intimidate.text = agentSO.intimidate.ToString();
        jump.text = agentSO.jump.ToString();
        languageOther1.text = agentSO.languageOther1.ToString();
        languageOther2.text = agentSO.languageOther2.ToString();
        languageOwn.text = agentSO.languageOwn.ToString();
        law.text = agentSO.law.ToString();
        libraryUse.text = agentSO.libraryUse.ToString();
        listen.text = agentSO.listen.ToString();
        locksmith.text = agentSO.locksmith.ToString();
        mechRepair.text = agentSO.mechRepair.ToString();
        medicine.text = agentSO.medicine.ToString();
        naturalWorld.text = agentSO.naturalWorld.ToString();
        navigate.text = agentSO.navigate.ToString();
        occult.text = agentSO.occult.ToString();
        opHvMachine.text = agentSO.opHvMachine.ToString();
        persuade.text = agentSO.persuade.ToString();
        pilot.text = agentSO.pilot.ToString();
        psychology.text = agentSO.psychology.ToString();
        psychanalysis.text = agentSO.psychanalysis.ToString();
        science1.text = agentSO.science1.ToString();
        science2.text = agentSO.science2.ToString();
        science3.text = agentSO.science3.ToString();
        sleightOfHand.text = agentSO.sleightOfHand.ToString();
        spotHidden.text = agentSO.spotHidden.ToString();
        stealth.text = agentSO.stealth.ToString();
        survival1.text = agentSO.survival1.ToString();
        swim.text = agentSO.swim.ToString();
        throw1.text = agentSO.throw1.ToString();
        track.text = agentSO.track.ToString();
        other1.text = agentSO.other1.ToString();
        other2.text = agentSO.other2.ToString();
        other3.text = agentSO.other3.ToString();
        other4.text = agentSO.other4.ToString();
        other5.text = agentSO.other5.ToString();
        
    }
}
