using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    
    // --- Variables --- \\
    public int strength, dexterity, constitution, intelligence, wisdom, charisma;
    private int strengthModifier, dexterityModifier, constitutionModifier, intelligenceModifier, wisdomModifier, charismaModifier;

    
    // --- Start Function --- \\
    private void Start()
    {
        strength = RollStat();
        strengthModifier = Mathf.FloorToInt((strength - 10) / 2);
        dexterity = RollStat();
        dexterityModifier = Mathf.FloorToInt((dexterity - 10) / 2);
        constitution = RollStat();
        constitutionModifier = Mathf.FloorToInt((constitution - 10) / 2);
        intelligence = RollStat();
        intelligenceModifier = Mathf.FloorToInt((intelligence - 10) / 2);
        wisdom = RollStat();
        wisdomModifier = Mathf.FloorToInt((wisdom - 10) / 2);
        charisma = RollStat();
        charismaModifier = Mathf.FloorToInt((charisma - 10) / 2);
    }

    
    // --- Function To Roll Dice For A Single Stat --- \\
    private int RollStat()
    {
        int[] stats = new int[4];
        int lowStat = 10, stat = 0;
        
        for (int i = 0; i < 4; i += 1)
        {
            stats[i] = (Random.Range(1, 7));
            if (stats[i] < lowStat)
            {
                lowStat = stats[i];
            }
        }

        stat -= lowStat;
        for (int i = 0; i < 4; i += 1)
        {
            stat += stats[i];
        }

        return stat;
    }

    
    // --- Function For Other Scripts To Get Player Stats --- \\
    public int GetStat(string stat)
    {
        if (stat == "strength")
        {
            return strength;
        }
        
        else if (stat == "dexterity")
        {
            return dexterity;
        }

        else if (stat == "constitution")
        {
            return constitution;
        }

        else if (stat == "intelligence")
        {
            return intelligence;
        }

        else if (stat == "wisdom")
        {
            return wisdom;
        }

        else
        {
            return charisma;
        }
    }

    
    // --- Function For Other Scripts To Get Player Stat Modifiers --- \\
    public int GetModifier(string stat)
    {
        if (stat == "strength")
        {
            return strengthModifier;
        }
        
        else if (stat == "dexterity")
        {
            return dexterityModifier;
        }

        else if (stat == "constitution")
        {
            return constitutionModifier;
        }

        else if (stat == "intelligence")
        {
            return intelligenceModifier;
        }

        else if (stat == "wisdom")
        {
            return wisdomModifier;
        }

        else
        {
            return charismaModifier;
        }
    }
}
