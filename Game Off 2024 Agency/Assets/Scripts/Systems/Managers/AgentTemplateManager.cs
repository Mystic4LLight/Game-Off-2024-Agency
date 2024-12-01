using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AgentTemplateManager
{
    public static string GenerateRandomName(bool isMale)
    {
        string[] maleFirstNames = { "John", "Robert", "Michael", "David", "James", "William" };
        string[] femaleFirstNames = { "Alice", "Diana", "Susan", "Mary", "Linda", "Karen" };
        string[] lastNames = { "Smith", "Brown", "Johnson", "Taylor", "White", "Lee" };

        string firstName = isMale
            ? maleFirstNames[Random.Range(0, maleFirstNames.Length)]
            : femaleFirstNames[Random.Range(0, femaleFirstNames.Length)];

        string lastName = lastNames[Random.Range(0, lastNames.Length)];

        return $"{firstName} {lastName}";
    }

    public static string GetRandomArchetype()
    {
        string[] archetypes = 
        { 
            "Adventurer", 
            "Egghead", 
            "Grease Monkey", 
            "Gumshoe", 
            "Heavy", 
            "Mystic", 
            "Swashbuckler", 
            "Thrill-Seeker", 
            "Weird Scientist", 
            "Marksman", 
            "Everyman/Woman" 
        };

        return archetypes[Random.Range(0, archetypes.Length)];
    }

    public static string GetRandomOccupation(string archetype)
    {
        Dictionary<string, string[]> occupationMap = new Dictionary<string, string[]>()
        {
            { "Adventurer", new string[] { "Extreme Sports Athlete", "Urban Explorer", "Survivalist" } },
            { "Egghead", new string[] { "Tech Innovator", "AI Researcher", "Hacker", "Digital Archaeologist", "Quantum Tech Scientist" } },
            { "Grease Monkey", new string[] { "Drone Engineer", "IT Specialist", "Cyberneticist", "Robotics Mechanic", "Device Hacker" } },
            { "Gumshoe", new string[] { "True Crime Podcaster", "Investigative Journalist", "Private Eye", "Digital PI", "Conspiracy Investigator" } },
            { "Heavy", new string[] { "Private Security Expert", "MMA Fighter", "Mercenary", "Bodyguard", "Bouncer" } },
            { "Mystic", new string[] { "Paranormal Investigator", "Cult Survivor", "Occult Specialist", "Spiritual Researcher", "Mystic Academic" } },
            { "Swashbuckler", new string[] { "Parkour Artist", "Freelance Stunt Performer", "Ex-Con", "Charismatic Rogue", "Agile Fighter" } },
            { "Thrill-Seeker", new string[] { "Social Media Daredevil", "Undercover Agent", "Risk Analyst", "Stunt YouTuber", "Extreme Stunt Performer" } },
            { "Weird Scientist", new string[] { "Biohacker", "Fringe Scientist", "R&D Specialist", "Experimental Technologist", "Artifact Researcher" } },
            { "Marksman", new string[] { "Sniper", "Competitive Shooter", "Gun Instructor" } },
            { "Everyman/Woman", new string[] { "Influencer", "Barista with a Side Hustle", "Uber Driver", "Gig Worker", "Urban Fantasy Writer" } }
        };

        if (occupationMap.ContainsKey(archetype))
        {
            string[] occupations = occupationMap[archetype];
            return occupations[Random.Range(0, occupations.Length)];
        }

        // Default occupation if archetype doesn't match any in the dictionary
        return "Freelancer";
    }

    public static void AssignAgentHobbies(AgentSO agent)
    {
        if (agent == null)
        {
            GameLogger.LogError("Cannot assign hobbies. AgentSO is null.");
            return;
        }

        int numberOfHobbies = Random.Range(1, 3); // Each agent gets 1 or 2 hobbies
        agent.hobbies = new List<string>();

        List<string> availableHobbies = new List<string>(hobbySkillBonuses.Keys);

        for (int i = 0; i < numberOfHobbies; i++)
        {
            if (availableHobbies.Count == 0) break; // No more available hobbies

            int randomIndex = Random.Range(0, availableHobbies.Count);
            string selectedHobby = availableHobbies[randomIndex];
            availableHobbies.RemoveAt(randomIndex); // Remove chosen hobby to avoid duplicates

            agent.hobbies.Add(selectedHobby);

            // Apply skill bonuses for the selected hobby
            if (hobbySkillBonuses.TryGetValue(selectedHobby, out var bonuses))
            {
                foreach (var bonus in bonuses)
                {
                    AgentStatsManager.EnsureSkillInitialized(agent, bonus.Key);
                    agent.skills[bonus.Key] += bonus.Value;
                }
            }
            else
            {
                GameLogger.LogWarning($"No skill bonuses defined for hobby: {selectedHobby}");
            }
        }

        GameLogger.Log($"Assigned hobbies to {agent.agentName}: {string.Join(", ", agent.hobbies)}");
    }

    private static readonly Dictionary<string, Dictionary<string, int>> hobbySkillBonuses = new Dictionary<string, Dictionary<string, int>>
    {
        { "Rock Climbing", new Dictionary<string, int> { { "Climb", 20 }, { "Strength", 10 } } },
        { "Chess", new Dictionary<string, int> { { "Intelligence", 15 }, { "Psychology", 10 } } },
        { "Photography", new Dictionary<string, int> { { "SpotHidden", 15 }, { "Art/Craft", 10 } } },
        { "Cooking", new Dictionary<string, int> { { "Craft", 20 }, { "Persuade", 5 } } },
        { "Shooting Range", new Dictionary<string, int> { { "Firearms(Aiming)", 20 }, { "SpotHidden", 10 } } },
        { "Gymnastics", new Dictionary<string, int> { { "Jump", 20 }, { "Dodge", 15 } } },
        { "Reading", new Dictionary<string, int> { { "Library Use", 15 }, { "Occult", 10 } } },
        { "Carpentry", new Dictionary<string, int> { { "Mechanical Repair", 15 }, { "Strength", 10 } } },
        { "Debate Club", new Dictionary<string, int> { { "Persuade", 20 }, { "Fast Talk", 10 } } },
        { "Survival Camping", new Dictionary<string, int> { { "Survival", 20 }, { "Navigate", 10 } } }
    };

    public static string GetRandomLanguage()
    {
        string[] languages = { "Spanish", "German", "French", "Mandarin", "Russian", "Japanese", "Italian", "Arabic" };
        string selectedLanguage = languages[Random.Range(0, languages.Length)];
        GameLogger.Log($"Random language selected: {selectedLanguage}");
        return selectedLanguage;
    }

    public static string GetRandomScienceField()
    {
        string[] sciences = { "Physics", "Chemistry", "Biology", "Astrophysics", "Robotics", "Genetics", "Cybernetics", "AI Research" };
        string selectedScience = sciences[Random.Range(0, sciences.Length)];
        GameLogger.Log($"Random science field selected: {selectedScience}");
        return selectedScience;
    }

    public static string GetRandomFightingStyle()
    {
        string[] fightingStyles = { "Boxing", "Karate", "Judo", "Muay Thai", "Krav Maga", "Capoeira", "Wrestling", "Mixed Martial Arts" };
        string selectedStyle = fightingStyles[Random.Range(0, fightingStyles.Length)];
        GameLogger.Log($"Random fighting style selected: {selectedStyle}");
        return selectedStyle;
    }

    public static string GetRandomFirearmType()
    {
        string[] firearmTypes = { "Sniper Rifle", "Pistol", "Shotgun", "Assault Rifle", "Submachine Gun", "Revolver", "Marksman Rifle", "Carbine" };
        string selectedFirearm = firearmTypes[Random.Range(0, firearmTypes.Length)];
        GameLogger.Log($"Random firearm type selected: {selectedFirearm}");
        return selectedFirearm;
    }

    public static string GetRandomBiome()
    {
        string[] biomes = { "Forest", "Desert", "Mountain", "Arctic", "Jungle", "Swamp", "Coastal", "Urban" };
        string selectedBiome = biomes[Random.Range(0, biomes.Length)];
        GameLogger.Log($"Random biome selected: {selectedBiome}");
        return selectedBiome;
    }

    public static void InitializeAgentSpecializations(AgentSO agent)
    {
        if (agent == null)
        {
            GameLogger.LogError("Cannot initialize specializations. AgentSO is null.");
            return;
        }

        if (agent.specializations == null)
        {
            GameLogger.LogWarning($"Specializations for {agent.agentName} are null. Initializing a new list.");
            agent.specializations = new List<Specialization>();
        }

        agent.specializations.Clear();

        // Adding 18 specializations with placeholder names for every type
        agent.specializations.Add(new Specialization(Specialization.SpecializationType.ArtCraft, "Art/Craft", 5));
        
    agent.specializations.Add(new Specialization(Specialization.SpecializationType.ArtCraft, "----", 0));
    for (int i = 1; i < 18; i++)
    {
        agent.specializations.Add(new Specialization(Specialization.SpecializationType.Other, $"Placeholder {i}", 0));
    }
    
        
    agent.specializations.Add(new Specialization(Specialization.SpecializationType.ArtCraft, "----", 0));
    for (int i = 1; i < 18; i++)
    {
        agent.specializations.Add(new Specialization(Specialization.SpecializationType.Other, $"Placeholder {i}", 0));
    }
    
        agent.specializations.Add(new Specialization(Specialization.SpecializationType.Fighting, "----", 25));
        agent.specializations.Add(new Specialization(Specialization.SpecializationType.Fighting, "----", 0));
        agent.specializations.Add(new Specialization(Specialization.SpecializationType.Firearms, "----", 0));
        agent.specializations.Add(new Specialization(Specialization.SpecializationType.Language, "Language(Other)\n----", 0));
        agent.specializations.Add(new Specialization(Specialization.SpecializationType.Language, "----", 0));

        // Set "Language (Own)" based on Education
        int eduValue = agent.currentStats.ContainsKey("Education") ? agent.currentStats["Education"] : 0;
        agent.specializations.Add(new Specialization(Specialization.SpecializationType.Language, $"Language(Own)\n----", eduValue));

        agent.specializations.Add(new Specialization(Specialization.SpecializationType.Science, "Science\n----", 1));
        agent.specializations.Add(new Specialization(Specialization.SpecializationType.Science, "----", 0));
        agent.specializations.Add(new Specialization(Specialization.SpecializationType.Science, "----", 0));
        agent.specializations.Add(new Specialization(Specialization.SpecializationType.Survival, "Survival\n----", 10));
        agent.specializations.Add(new Specialization(Specialization.SpecializationType.Other, "----", 0));
        agent.specializations.Add(new Specialization(Specialization.SpecializationType.Other, "----", 0));
        agent.specializations.Add(new Specialization(Specialization.SpecializationType.Other, "----", 0));
        agent.specializations.Add(new Specialization(Specialization.SpecializationType.Other, "----", 0));
        agent.specializations.Add(new Specialization(Specialization.SpecializationType.Other, "----", 0));

        GameLogger.Log($"Default specializations initialized for agent: {agent.agentName}");

        // Modify specializations based on archetype and occupation
        for (int i = 0; i < agent.specializations.Count; i++)
        {
            var specialization = agent.specializations[i];

            // Example: Modify Art/Craft specialization for specific archetypes
            if (specialization.type == Specialization.SpecializationType.ArtCraft)
            {
                if (specialization.name == "Art/Craft" && agent.archetype == "Adventurer")
                {
                    specialization.name = "Art/Craft\nClimbing Equipment";
                    specialization.value = Random.Range(20, 51);
                }
            }

            // Example: Modify Language specialization
            if (specialization.type == Specialization.SpecializationType.Language)
            {
                if (specialization.name.StartsWith("Language (Other)"))
                {
                    string randomLanguage = GetRandomLanguage();
                    specialization.name = $"Language\n{randomLanguage}";
                    specialization.value = Random.Range(15, 36);
                }
            }

            // Continue modifying other types...
        }

        GameLogger.Log($"Specializations modified for agent: {agent.agentName}");
    }

}
