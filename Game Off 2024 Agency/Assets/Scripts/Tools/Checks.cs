using UnityEngine;

public class Checks : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static bool CheckStat(Agent agent, string stat, float checkValue)
    {
        float rollValue = Rolls.RollD100();
        if (rollValue <= agent.GetStatValue(stat))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool CheckHardStat(Agent agent, string stat)
    {
        float rollValue = Rolls.RollD100();
        if (rollValue <= (agent.GetStatValue(stat) / 5))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool CheckExtremeStat(Agent agent, string stat, float checkValue)
    {
        float rollValue = Rolls.RollD100();
        if (rollValue <= (agent.GetStatValue(stat) / 20))
        {
            return true;
        }
        else
        {
            return false;
        }
    }




}

