using UnityEngine;

public class playerStats : MonoBehaviour
{
    
    public int strength, dexterity, constitution, intelligence, wisdom, charisma;
    private int strengthModifier, dexterityModifier, constitutionModifier, intelligenceModifier, wisdomModifier, charismaModifier;

    
    // Start is called before the first frame update
    void Start()
    {
        strength = rollStat();
        strengthModifier = Mathf.FloorToInt((strength - 10) / 2);
        dexterity = rollStat();
        dexterityModifier = Mathf.FloorToInt((dexterity - 10) / 2);
        constitution = rollStat();
        constitutionModifier = Mathf.FloorToInt((constitution - 10) / 2);
        intelligence = rollStat();
        intelligenceModifier = Mathf.FloorToInt((intelligence - 10) / 2);
        wisdom = rollStat();
        wisdomModifier = Mathf.FloorToInt((wisdom - 10) / 2);
        charisma = rollStat();
        charismaModifier = Mathf.FloorToInt((charisma - 10) / 2);
    }

    int rollStat()
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

    public int getStat(string stat)
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

    public int getModifier(string stat)
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
