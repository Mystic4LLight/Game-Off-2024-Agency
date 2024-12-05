using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AgentTemplateManager
{
    public static string GenerateRandomName(bool isMale)
    {
        string[] maleFirstNames = { 
        "Liam", "Noah", "Oliver", "Elijah", "James", "William", "Benjamin", "Lucas", "Henry", "Alexander",
        "Ethan", "Jacob", "Michael", "Daniel", "Logan", "Jackson", "Sebastian", "Jack", "Aiden", "Owen",
        "Samuel", "Matthew", "Joseph", "Levi", "Mateo", "David", "John", "Wyatt", "Carter", "Julian",
        "Luke", "Grayson", "Isaac", "Jayden", "Gabriel", "Anthony", "Dylan", "Leo", "Lincoln", "Nathan",
        "Jaxon", "Ezra", "Hudson", "Charles", "Caleb", "Elias", "Isaiah", "Andrew", "Joshua", "Christopher",
        "Theodore", "Thomas", "Jonathan", "Maverick", "Landon", "Nicholas", "Dominic", "Miles", "Cooper", "Xavier",
        "Evan", "Christian", "Aaron", "Cameron", "Nolan", "Adrian", "Colton", "Roman", "Axel", "Brooks",
        "Adam", "Ian", "Jace", "Easton", "Vincent", "Ryder", "Silas", "Wesley", "Nathaniel", "Harrison",
        "Brayden", "Cole", "Damian", "Ezekiel", "Riley", "Micah", "Zachary", "Asher", "Jason", "Chase",
        "Leonardo", "Connor", "Kingston", "Elliot", "Kaiden", "Max", "Bryson", "Jasper", "Beckett", "Sawyer"
    };

        string[] femaleFirstNames = {
        "Emma", "Olivia", "Ava", "Sophia", "Isabella", "Mia", "Amelia", "Harper", "Evelyn", "Abigail",
        "Emily", "Ella", "Elizabeth", "Camila", "Luna", "Sofia", "Avery", "Mila", "Aria", "Scarlett",
        "Penelope", "Layla", "Chloe", "Victoria", "Madison", "Eleanor", "Grace", "Nora", "Riley", "Zoey",
        "Hannah", "Hazel", "Lily", "Ellie", "Violet", "Lillian", "Zoe", "Stella", "Aurora", "Natalie",
        "Emilia", "Everly", "Leah", "Aubrey", "Willow", "Addison", "Lucy", "Audrey", "Bella", "Nova",
        "Brooklyn", "Paisley", "Savannah", "Claire", "Skylar", "Isla", "Genesis", "Naomi", "Elena", "Caroline",
        "Eliana", "Anna", "Maya", "Valentina", "Ruby", "Kennedy", "Ivy", "Ariana", "Aaliyah", "Cora",
        "Madelyn", "Alice", "Kinsley", "Hailey", "Gabriella", "Allison", "Gianna", "Serenity", "Samantha", "Autumn",
        "Piper", "Eva", "Sophie", "Sadie", "Delilah", "Josephine", "Nevaeh", "Adeline", "Arya", "Clara",
        "Vivian", "Raelynn", "Sarah", "Madeline", "Liliana", "Jade", "Melanie", "Mackenzie", "Brielle", "Rylee"
    };
        string[] lastNames = {
        "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez",
        "Hernandez", "Lopez", "Gonzalez", "Wilson", "Anderson", "Thomas", "Taylor", "Moore", "Jackson", "Martin",
        "Lee", "Perez", "Thompson", "White", "Harris", "Sanchez", "Clark", "Ramirez", "Lewis", "Robinson",
        "Walker", "Young", "Allen", "King", "Wright", "Scott", "Torres", "Nguyen", "Hill", "Flores",
        "Green", "Adams", "Nelson", "Baker", "Hall", "Rivera", "Campbell", "Mitchell", "Carter", "Roberts",
        "Gomez", "Phillips", "Evans", "Turner", "Diaz", "Parker", "Cruz", "Edwards", "Collins", "Reyes",
        "Stewart", "Morris", "Morales", "Murphy", "Cook", "Rogers", "Gutierrez", "Ortiz", "Morgan", "Cooper",
        "Peterson", "Bailey", "Reed", "Kelly", "Howard", "Ramos", "Kim", "Cox", "Ward", "Richardson",
        "Watson", "Brooks", "Chavez", "Wood", "James", "Bennett", "Gray", "Mendoza", "Ruiz", "Hughes",
        "Price", "Alvarez", "Castillo", "Sanders", "Patel", "Myers", "Long", "Ross", "Foster", "Jimenez",
        "Powell", "Jenkins", "Perry", "Russell", "Sullivan", "Bell", "Coleman", "Butler", "Henderson", "Barnes",
        "Gonzales", "Fisher", "Vasquez", "Simmons", "Romero", "Jordan", "Patterson", "Alexander", "Hamilton", "Graham",
        "Reynolds", "Griffin", "Wallace", "Moreno", "West", "Cole", "Hayes", "Bryant", "Herrera", "Gibson",
        "Ellis", "Tran", "Medina", "Aguilar", "Stevens", "Murray", "Ford", "Castro", "Marshall", "Owens",
        "Harrison", "Fernandez", "Mcdonald", "Woods", "Washington", "Kennedy", "Wells", "Vargas", "Henry", "Chen",
        "Freeman", "Webb", "Tucker", "Guzman", "Burns", "Crawford", "Olson", "Simpson", "Porter", "Hunter",
        "Gordon", "Mendez", "Silva", "Shaw", "Snyder", "Mason", "Dixon", "Muñoz", "Hunt", "Hicks",
        "Holmes", "Palmer", "Wagner", "Black", "Robertson", "Boyd", "Rose", "Stone", "Salazar", "Fox",
        "Warren", "Mills", "Meyer", "Rice", "Schmidt", "Garza", "Daniels", "Ferguson", "Nichols", "Stephens",
        "Soto", "Weaver", "Ryan", "Gardner", "Payne", "Grant", "Dunn", "Kelley", "Spencer", "Hawkins",
        "Arnold", "Pierce", "Vazquez", "Hansen", "Peters", "Santos", "Hart", "Bradley", "Knight", "Elliott",
        "Cunningham", "Duncan", "Armstrong", "Hudson", "Carroll", "Lane", "Riley", "Andrews", "Alvarado", "Ray"
    };


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
            { "Adventurer", new string[] { "Extreme Sports Athlete", "Urban Explorer", "Survivalist", "Extreme Environment Photograph", "Treasure Hunter" } },
            { "Egghead", new string[] { "Tech Innovator", "AI Researcher", "Hacker", "Digital Archaeologist", "Quantum Tech Scientist" } },
            { "Grease Monkey", new string[] { "Drone Engineer", "IT Specialist", "Cyberneticist", "Robotics Mechanic", "Device Hacker" } },
            { "Gumshoe", new string[] { "True Crime Podcaster", "Investigative Journalist", "Private Eye", "Digital PI", "Conspiracy Investigator" } },
            { "Heavy", new string[] { "Private Security Expert", "MMA Fighter", "Mercenary", "Bodyguard", "Bouncer" } },
            { "Mystic", new string[] { "Paranormal Investigator", "Cult Survivor", "Occult Specialist", "Spiritual Researcher", "Mystic Academic" } },
            { "Swashbuckler", new string[] { "Parkour Artist", "Freelance Stunt Performer", "Ex-Con", "Charismatic Rogue", "Agile Fighter" } },
            { "Thrill-Seeker", new string[] { "Social Media Daredevil", "Undercover Agent", "Risk Analyst", "Stunt YouTuber", "Extreme Stunt Performer" } },
            { "Weird Scientist", new string[] { "Biohacker", "Fringe Scientist", "R&D Specialist", "Experimental Technologist", "Artifact Researcher" } },
            { "Marksman", new string[] { "Sniper", "Competitive Shooter", "Gun Instructor", "Tactical Shooter", "Bow Hunter" } },
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
    { "Survival Camping", new Dictionary<string, int> { { "Survival", 20 }, { "Navigate", 10 } } },
    { "Fishing", new Dictionary<string, int> { { "Survival", 15 }, { "Patience", 10 } } },
    { "Knitting", new Dictionary<string, int> { { "Art/Craft", 15 }, { "Concentration", 10 } } },
    { "Parkour", new Dictionary<string, int> { { "Climb", 15 }, { "Jump", 20 } } },
    { "Yoga", new Dictionary<string, int> { { "Balance", 15 }, { "Willpower", 10 } } },
    { "Archery", new Dictionary<string, int> { { "Firearms(Aiming)", 15 }, { "SpotHidden", 10 } } },
    { "Fencing", new Dictionary<string, int> { { "Fighting", 20 }, { "Dodge", 15 } } },
    { "Sailing", new Dictionary<string, int> { { "Navigate", 20 }, { "Survival", 10 } } },
    { "Scuba Diving", new Dictionary<string, int> { { "Swim", 20 }, { "SpotHidden", 10 } } },
    { "Bird Watching", new Dictionary<string, int> { { "SpotHidden", 20 }, { "Natural World", 10 } } },
    { "Gardening", new Dictionary<string, int> { { "Natural World", 15 }, { "Craft", 10 } } },
    { "Baking", new Dictionary<string, int> { { "Craft", 20 }, { "Persuade", 5 } } },
    { "Amateur Astronomy", new Dictionary<string, int> { { "Astronomy", 20 }, { "SpotHidden", 10 } } },
    { "Playing Guitar", new Dictionary<string, int> { { "Art/Music", 20 }, { "Dexterity", 10 } } },
    { "Acting", new Dictionary<string, int> { { "Disguise", 20 }, { "Persuade", 10 } } },
    { "Dancing", new Dictionary<string, int> { { "Dexterity", 15 }, { "Art/Performance", 20 } } },
    { "Horse Riding", new Dictionary<string, int> { { "Ride", 20 }, { "Animal Handling", 10 } } },
    { "Blacksmithing", new Dictionary<string, int> { { "Craft", 20 }, { "Strength", 10 } } },
    { "Beekeeping", new Dictionary<string, int> { { "Natural World", 15 }, { "Dexterity", 10 } } },
    { "Calligraphy", new Dictionary<string, int> { { "Art/Craft", 20 }, { "Dexterity", 10 } } },
    { "Pottery", new Dictionary<string, int> { { "Art/Craft", 20 }, { "Concentration", 10 } } },
    { "Meditation", new Dictionary<string, int> { { "Willpower", 15 }, { "Concentration", 10 } } },
    { "Metal Detecting", new Dictionary<string, int> { { "SpotHidden", 20 }, { "Patience", 10 } } },
    { "Tattoo Art", new Dictionary<string, int> { { "Art/Craft", 15 }, { "Dexterity", 10 } } },
    { "Origami", new Dictionary<string, int> { { "Dexterity", 15 }, { "Concentration", 10 } } },
    { "Falconry", new Dictionary<string, int> { { "Animal Handling", 20 }, { "Natural World", 10 } } },
    { "Scrapbooking", new Dictionary<string, int> { { "Art/Craft", 10 }, { "Memory", 15 } } },
    { "Lock Picking", new Dictionary<string, int> { { "Mechanical Repair", 20 }, { "Dexterity", 15 } } },
    { "Amateur Radio", new Dictionary<string, int> { { "Electronics", 20 }, { "Listen", 10 } } },
    { "Puzzles", new Dictionary<string, int> { { "Intelligence", 15 }, { "Concentration", 10 } } },
    { "Animal Rescue", new Dictionary<string, int> { { "Animal Handling", 20 }, { "First Aid", 10 } } },
    { "Piloting", new Dictionary<string, int> { { "Pilot", 20 }, { "Navigate", 15 } } },
    { "Dungeons & Dragons", new Dictionary<string, int> { { "Intelligence", 10 }, { "Persuade", 10 } } },
    { "Park Cleanup", new Dictionary<string, int> { { "Natural World", 15 }, { "Strength", 5 } } },
    { "Caving", new Dictionary<string, int> { { "Climb", 15 }, { "Navigate", 10 } } },
    { "Wine Tasting", new Dictionary<string, int> { { "Charm", 10 }, { "Knowledge", 10 } } },
    { "Motorcycle Riding", new Dictionary<string, int> { { "Drive", 20 }, { "Balance", 10 } } },
    { "Meteorology", new Dictionary<string, int> { { "Natural World", 20 }, { "SpotHidden", 5 } } }
    { "Surfing", new Dictionary<string, int> { { "Swim", 20 }, { "Balance", 15 } } },
    { "Pottery", new Dictionary<string, int> { { "Art/Craft", 20 }, { "Concentration", 10 } } },
    { "Parkour", new Dictionary<string, int> { { "Jump", 20 }, { "Climb", 15 } } },
    { "Scuba Diving", new Dictionary<string, int> { { "Swim", 20 }, { "SpotHidden", 10 } } },
    { "Falconry", new Dictionary<string, int> { { "Animal Handling", 20 }, { "Natural World", 10 } } },
    { "DJing", new Dictionary<string, int> { { "Art/Music", 20 }, { "Persuade", 10 } } },
    { "Glassblowing", new Dictionary<string, int> { { "Art/Craft", 20 }, { "Dexterity", 10 } } },
    { "Rock Balancing", new Dictionary<string, int> { { "Balance", 20 }, { "Patience", 15 } } },
    { "Wine Making", new Dictionary<string, int> { { "Craft", 15 }, { "Natural World", 10 } } },
    { "Bee Keeping", new Dictionary<string, int> { { "Natural World", 20 }, { "Dexterity", 10 } } },
    { "Knife Throwing", new Dictionary<string, int> { { "Throw", 20 }, { "SpotHidden", 10 } } },
    { "Astrology", new Dictionary<string, int> { { "Occult", 20 }, { "Psychology", 10 } } },
    { "Graffiti Art", new Dictionary<string, int> { { "Art/Craft", 20 }, { "Dexterity", 10 } } },
    { "Leatherworking", new Dictionary<string, int> { { "Craft", 20 }, { "Strength", 10 } } },
    { "Escape Room Enthusiast", new Dictionary<string, int> { { "SpotHidden", 20 }, { "Intelligence", 10 } } },
    { "Geocaching", new Dictionary<string, int> { { "Navigate", 20 }, { "SpotHidden", 10 } } },
    { "Bird Watching", new Dictionary<string, int> { { "SpotHidden", 20 }, { "Natural World", 15 } } },
    { "Bonsai", new Dictionary<string, int> { { "Natural World", 15 }, { "Concentration", 10 } } },
    { "Metal Sculpting", new Dictionary<string, int> { { "Art/Craft", 20 }, { "Strength", 10 } } },
    { "Rappelling", new Dictionary<string, int> { { "Climb", 20 }, { "Strength", 15 } } },
    { "Tattoo Designing", new Dictionary<string, int> { { "Art/Craft", 20 }, { "Dexterity", 10 } } },
    { "Cheese Making", new Dictionary<string, int> { { "Craft", 20 }, { "Science", 10 } } },
    { "Skateboarding", new Dictionary<string, int> { { "Balance", 20 }, { "Dexterity", 10 } } },
    { "Whittling", new Dictionary<string, int> { { "Craft", 15 }, { "Dexterity", 10 } } },
    { "Tinkering", new Dictionary<string, int> { { "Mechanical Repair", 20 }, { "Electronics", 10 } } },
    { "Leather Carving", new Dictionary<string, int> { { "Craft", 20 }, { "Art/Craft", 15 } } },
    { "Cosplaying", new Dictionary<string, int> { { "Disguise", 20 }, { "Art/Craft", 10 } } },
    { "Trail Running", new Dictionary<string, int> { { "Endurance", 20 }, { "Navigate", 10 } } },
    { "Soap Carving", new Dictionary<string, int> { { "Craft", 15 }, { "Concentration", 10 } } },
    { "Candle Making", new Dictionary<string, int> { { "Craft", 20 }, { "Art/Craft", 10 } } },
    { "Whale Watching", new Dictionary<string, int> { { "SpotHidden", 20 }, { "Natural World", 10 } } },
    { "Free Diving", new Dictionary<string, int> { { "Swim", 20 }, { "Endurance", 15 } } },
    { "Astrophotography", new Dictionary<string, int> { { "Art/Craft", 20 }, { "SpotHidden", 10 } } },
    { "Antiquing", new Dictionary<string, int> { { "Appraise", 20 }, { "Bargain", 10 } } },
    { "Kite Flying", new Dictionary<string, int> { { "Navigate", 15 }, { "Art/Craft", 10 } } },
    { "Spelunking", new Dictionary<string, int> { { "Climb", 20 }, { "Navigate", 15 } } },
    { "Cheerleading", new Dictionary<string, int> { { "Performance", 20 }, { "Dexterity", 15 } } },
    { "Fire Dancing", new Dictionary<string, int> { { "Art/Performance", 20 }, { "Dexterity", 15 } } },
    { "Foraging", new Dictionary<string, int> { { "Natural World", 20 }, { "Survival", 10 } } },
    { "Ice Carving", new Dictionary<string, int> { { "Craft", 20 }, { "Strength", 10 } } },
    { "Magnet Fishing", new Dictionary<string, int> { { "SpotHidden", 20 }, { "Strength", 10 } } },
    { "Urban Exploration", new Dictionary<string, int> { { "SpotHidden", 15 }, { "Navigate", 10 } } },
    { "Sand Sculpting", new Dictionary<string, int> { { "Art/Craft", 20 }, { "Concentration", 10 } } },
    { "Ventriloquism", new Dictionary<string, int> { { "Performance", 20 }, { "Persuade", 10 } } },
    { "Underwater Basket Weaving", new Dictionary<string, int> { { "Craft", 20 }, { "Swim", 10 } } },
    { "Street Magic", new Dictionary<string, int> { { "Sleight of Hand", 20 }, { "Fast Talk", 10 } } }
    { "Soccer", new Dictionary<string, int> { { "Dexterity", 20 }, { "Endurance", 15 } } },
    { "Basketball", new Dictionary<string, int> { { "Jump", 20 }, { "Dexterity", 10 } } },
    { "Tennis", new Dictionary<string, int> { { "Dexterity", 20 }, { "Endurance", 10 } } },
    { "Boxing", new Dictionary<string, int> { { "Fighting", 20 }, { "Strength", 15 } } },
    { "Swimming", new Dictionary<string, int> { { "Swim", 20 }, { "Endurance", 15 } } },
    { "Running", new Dictionary<string, int> { { "Endurance", 20 }, { "Speed", 15 } } },
    { "Cycling", new Dictionary<string, int> { { "Endurance", 20 }, { "Navigate", 10 } } },
    { "Golf", new Dictionary<string, int> { { "SpotHidden", 15 }, { "Concentration", 10 } } },
    { "Fencing", new Dictionary<string, int> { { "Fighting", 20 }, { "Dexterity", 10 } } },
    { "Wrestling", new Dictionary<string, int> { { "Strength", 20 }, { "Grapple", 15 } } },
    { "Rowing", new Dictionary<string, int> { { "Strength", 20 }, { "Endurance", 15 } } },
    { "Cricket", new Dictionary<string, int> { { "Dexterity", 20 }, { "SpotHidden", 10 } } },
    { "Baseball", new Dictionary<string, int> { { "Throw", 20 }, { "SpotHidden", 10 } } },
    { "Table Tennis", new Dictionary<string, int> { { "Dexterity", 20 }, { "Concentration", 10 } } },
    { "Volleyball", new Dictionary<string, int> { { "Jump", 15 }, { "Dexterity", 10 } } },
    { "Hiking", new Dictionary<string, int> { { "Endurance", 15 }, { "Navigate", 10 } } },
    { "Skiing", new Dictionary<string, int> { { "Balance", 20 }, { "Endurance", 10 } } },
    { "Snowboarding", new Dictionary<string, int> { { "Balance", 20 }, { "Dexterity", 10 } } },
    { "Ice Skating", new Dictionary<string, int> { { "Balance", 20 }, { "Dexterity", 10 } } },
    { "Rock Climbing", new Dictionary<string, int> { { "Climb", 20 }, { "Strength", 15 } } },
    { "Martial Arts", new Dictionary<string, int> { { "Fighting", 20 }, { "Dodge", 15 } } },
    { "Horse Riding", new Dictionary<string, int> { { "Ride", 20 }, { "Animal Handling", 10 } } },
    { "Archery", new Dictionary<string, int> { { "Firearms(Aiming)", 20 }, { "Concentration", 10 } } },
    { "Rugby", new Dictionary<string, int> { { "Strength", 20 }, { "Endurance", 15 } } },
    { "Field Hockey", new Dictionary<string, int> { { "Dexterity", 20 }, { "Endurance", 10 } } },
    { "Kayaking", new Dictionary<string, int> { { "Swim", 20 }, { "Strength", 10 } } },
    { "Skateboarding", new Dictionary<string, int> { { "Balance", 20 }, { "Dexterity", 10 } } },
    { "Ballet", new Dictionary<string, int> { { "Balance", 20 }, { "Performance", 15 } } },
    { "Gymnastics", new Dictionary<string, int> { { "Jump", 20 }, { "Balance", 15 } } },
    { "Badminton", new Dictionary<string, int> { { "Dexterity", 20 }, { "Endurance", 10 } } },
    { "Sailing", new Dictionary<string, int> { { "Navigate", 20 }, { "Survival", 10 } } },
    { "Kickboxing", new Dictionary<string, int> { { "Fighting", 20 }, { "Strength", 10 } } },
    { "Diving", new Dictionary<string, int> { { "Swim", 20 }, { "SpotHidden", 10 } } },
    { "Polo", new Dictionary<string, int> { { "Ride", 20 }, { "Dexterity", 10 } } },
    { "Ice Hockey", new Dictionary<string, int> { { "Strength", 20 }, { "Dexterity", 10 } } },
    { "Judo", new Dictionary<string, int> { { "Grapple", 20 }, { "Dodge", 15 } } },
    { "Table Soccer", new Dictionary<string, int> { { "Dexterity", 15 }, { "Concentration", 10 } } },
    { "Racquetball", new Dictionary<string, int> { { "Dexterity", 20 }, { "Endurance", 10 } } },
    { "CrossFit", new Dictionary<string, int> { { "Endurance", 20 }, { "Strength", 15 } } },
    { "Surfing", new Dictionary<string, int> { { "Swim", 20 }, { "Balance", 15 } } },
    { "Triathlon", new Dictionary<string, int> { { "Endurance", 25 }, { "Swim", 15 } } },
    { "Weightlifting", new Dictionary<string, int> { { "Strength", 25 }, { "Endurance", 10 } } },
    { "Snooker", new Dictionary<string, int> { { "Dexterity", 15 }, { "Concentration", 10 } } },
    { "Handball", new Dictionary<string, int> { { "Dexterity", 20 }, { "Strength", 10 } } },
    { "Mountain Biking", new Dictionary<string, int> { { "Endurance", 20 }, { "Navigate", 10 } } },
    { "Futsal", new Dictionary<string, int> { { "Dexterity", 20 }, { "Endurance", 15 } } }.
    { "Street Racer", new Dictionary<string, int>{ { "Drive", 20 }, { "MechRepair", 15 } } }
};


    public static string GetRandomLanguage()
    {
        string[] languages = {
        "Spanish", "German", "French", "Mandarin", "Russian", "Japanese", "Italian", "Arabic",
        "English", "Portuguese", "Hindi", "Bengali", "Urdu", "Korean", "Vietnamese", "Turkish",
        "Persian", "Greek", "Hebrew", "Latin", "Sanskrit", "Coptic", "Akkadian", "Sumerian",
        "Phoenician", "Aramaic", "Old Norse", "Old English", "Classical Greek", "Ancient Egyptian",
        "Gaelic", "Irish", "Scottish Gaelic", "Welsh", "Breton", "Cornish", "Basque", "Dutch",
        "Afrikaans", "Swedish", "Danish", "Norwegian", "Finnish", "Icelandic", "Hungarian", "Polish",
        "Czech", "Slovak", "Bulgarian", "Serbian", "Croatian", "Bosnian", "Slovenian", "Macedonian",
        "Ukrainian", "Belarusian", "Romanian", "Lithuanian", "Latvian", "Estonian", "Armenian", "Georgian",
        "Albanian", "Pashto", "Kurdish", "Malay", "Indonesian", "Tagalog", "Swahili", "Zulu",
        "Xhosa", "Yoruba", "Igbo", "Amharic", "Hausa", "Somali", "Bantu", "Tigrinya", "Thai",
        "Maori", "Hawaiian", "Samoan", "Fijian", "Inuktitut", "Quechua", "Nahuatl", "Maya",
        "Aymara", "Navajo", "Cherokee", "Sioux", "Apache", "Ojibwe", "Inuit", "Mohawk",
        "Sanskrit", "Pali", "Prakrit", "Avestan", "Gothic", "Tocharian", "Hittite", "Etruscan",
        "Phoenician", "Ugaritic", "Elamite", "Lycian", "Luwian", "Punic", "Gaulish", "Old Irish",
        "Old High German", "Middle English", "Middle Persian", "Old Church Slavonic", "Manchu", "Khmer", "Lao", "Burmese",
        "Tibetan", "Mongolian", "Ainu", "Klingon", "Esperanto", "Sindarin", "Quenya", "Volapük",
        "Occitan", "Catalan", "Galician", "Asturian", "Sardinian", "Faroese", "Ladino", "Yiddish",
        "Haitian Creole", "Papiamento", "Tongan", "Tok Pisin", "Romani", "Hittite", "Scots", "Friulian",
        "Piedmontese", "Ligurian", "Lombard", "Neapolitan", "Sicilian", "Venetian", "Walloon", "Flemish",
        "Bashkir", "Chechen", "Kabardian", "Abkhaz", "Ossetian", "Udmurt", "Mari", "Chuvash",
        "Tatar", "Kalmyk", "Sami", "Karelian", "Mansi", "Khanty", "Evenki", "Yakut"
    };
    string[] mythosLanguages = {
        "Latin", "Greek", "Arabic", "Hebrew", "Sanskrit", "Akkadian", "Ancient Egyptian", "Chinese",
        "English", "French", "German", "Spanish", "Portuguese", "Dutch", "Russian", "Norwegian",
        "Gaelic", "Old English", "Old Norse", "Sumerian", "Phoenician", "Aramaic", "Pnakotic", 
        "Aklo", "R'lyehian", "Yithian", "Naacal", "Hyperborean", "Tsath-Yo", "Valusian", 
        "Elder Hieroglyphs", "Tcho-Tcho", "Muvian", "Yuggothic", "Atlantean", "Mnarish"
    };

        string selectedLanguage = languages[Random.Range(0, languages.Length)];
        GameLogger.Log($"Random language selected: {selectedLanguage}");
        return selectedLanguage;
    }

    public static string GetRandomArtCraft()
    {
        string[] artCrafts = {
        "Pottery", "Weaving", "Glassblowing", "Leatherworking", "Metalworking", "Wood Carving", "Stone Sculpture",
        "Painting", "Calligraphy", "Drawing", "Mosaic", "Tattoo Art", "Graffiti Art", "Origami", "Jewelry Making",
        "Blacksmithing", "Ceramics", "Embroidery", "Knitting", "Crochet", "Quilting", "Basket Weaving",
        "Bookbinding", "Stained Glass", "Silk Painting", "Textile Dyeing", "Sand Sculpting", "Ice Carving",
        "Digital Art", "Graphic Design", "3D Modeling", "Photography", "Videography", "Animation", "Concept Art",
        "Printmaking", "Etching", "Lithography", "Screen Printing", "Collage", "Mixed Media", "Papermaking",
        "Paper Cutting", "Enameling", "Beadwork", "Fashion Design", "Costume Design", "Cosplay", "Felting",
        "Metal Sculpting", "Wood Burning", "Illumination (Manuscripts)", "Heraldry Art", "Tapestry Weaving",
        "Ikebana (Flower Arrangement)", "Candle Making", "Soap Carving", "Shadow Puppetry"
    };

        string selectedArtCraft = artCrafts[Random.Range(0, artCrafts.Lenght)];
        GameLogger.Log($"Random artCraft field selected: {selectedArtCraft}");
        return selectedArtCraft;
    }

    public static string GetRandomScienceField()
    {
        string[] sciences = {
        "Physics", "Chemistry", "Biology", "Astrophysics", "Robotics", "Genetics", "Cybernetics", "AI Research",
        "Mathematics", "Geology", "Meteorology", "Astronomy", "Oceanography", "Ecology", "Neuroscience", "Biochemistry",
        "Molecular Biology", "Microbiology", "Zoology", "Botany", "Anthropology", "Sociology", "Psychology", "Paleontology",
        "Environmental Science", "Forensic Science", "Material Science", "Nuclear Physics", "Quantum Mechanics", "Particle Physics",
        "Optics", "Thermodynamics", "Acoustics", "Electronics", "Computer Science", "Information Technology", "Genomics",
        "Bioinformatics", "Nanotechnology", "Biophysics", "Medical Science", "Pharmacology", "Toxicology", "Virology",
        "Pathology", "Immunology", "Endocrinology", "Cardiology", "Dermatology", "Oncology", "Astrobiology", "Cryogenics",
        "Aeronautics", "Astronautics", "Hydrology", "Soil Science", "Agricultural Science", "Entomology", "Evolutionary Biology",
        "Genetic Engineering", "Ethology", "Marine Biology", "Biotechnology", "Cognitive Science", "Linguistics", "Social Science",
        "Political Science", "Economics", "Histology", "Hematology", "Biomechanics", "Kinesiology", "Sports Science",
        "Health Science", "Nutrition", "Veterinary Science", "Forestry", "Horticulture", "Remote Sensing", "Geophysics",
        "Climatology", "Planetary Science", "Seismology", "Radiology", "Spectroscopy", "Orthopedics", "Ecotoxicology",
        "Geomorphology", "Topography", "Cartography", "Environmental Engineering", "Civil Engineering", "Mechanical Engineering",
        "Electrical Engineering", "Systems Engineering", "Software Engineering", "Structural Biology", "Theoretical Physics",
        "Condensed Matter Physics", "Computational Science", "Quantum Computing", "Artificial Intelligence", "Deep Learning",
        "Machine Learning", "Data Science", "Statistics", "Network Science", "Cultural Anthropology", "Human Geography"
    };

        string selectedScience = sciences[Random.Range(0, sciences.Length)];
        GameLogger.Log($"Random science field selected: {selectedScience}");
        return selectedScience;
    }

    public static string GetRandomFightingStyle()
    {
        string[] fightingStyles = {
        "Boxing", "Karate", "Judo", "Muay Thai", "Krav Maga", "Capoeira", "Wrestling", "Mixed Martial Arts",
        "Taekwondo", "Brazilian Jiu-Jitsu", "Sambo", "Aikido", "Savate", "Kung Fu", "Wing Chun", "Jeet Kune Do",
        "Jiu-Jitsu", "Kickboxing", "Pencak Silat", "Hapkido", "Kali", "Eskrima", "Arnis", "Systema",
        "Sanda", "Lethwei", "Vale Tudo", "Shootfighting", "Shuai Jiao", "Kenpo", "Shorinji Kempo", "Bartitsu",
        "Kyokushin Karate", "Shotokan Karate", "Goju-Ryu Karate", "Wado-Ryu Karate", "Tang Soo Do", "Choi Kwang Do",
        "Pradal Serey", "Dambe", "Ninjutsu", "Iaido", "Kendo", "Sumo", "Greco-Roman Wrestling", "Freestyle Wrestling",
        "Catch Wrestling", "Glima", "Yaw-Yan", "Savate", "American Kenpo", "Bakom", "Zui Quan", "Panantukan",
        "Mongolian Wrestling", "Gatka", "Eagle Claw Kung Fu", "Hung Gar", "White Crane Kung Fu", "Bajiquan",
        "Bagua Zhang", "Hsing-I", "Wushu", "Choy Li Fut", "Dragon Style Kung Fu", "Fujian White Crane", "Tiger Style Kung Fu",
        "Shuai Jiao", "Kajukenbo", "Defendo", "MCMAP (Marine Corps Martial Arts Program)", "Sambo Combat",
        "Tai Chi Chuan", "Savate", "Bando", "Pankration", "Daito-ryu Aiki-jujutsu", "Gongkwon Yusul",
        "Combat Hapkido", "Sambo", "Dambe", "Singi", "Shastar Vidya", "Yaw Yan", "Kinomichi",
        "Okichitaw", "Krabi Krabong", "Taekkyeon", "Canne de Combat", "Kinomichi", "Buza", "Kapap",
        "Savika", "Antarctica Tactics", "Basque Lucha", "Silat Patani", "Albanian Fustanella", "Slavic Pankratia"
    };

        string selectedStyle = fightingStyles[Random.Range(0, fightingStyles.Length)];
        GameLogger.Log($"Random fighting style selected: {selectedStyle}");
        return selectedStyle;
    }

    public static string GetRandomFirearmType()
    {
        string[] otherDistanceWeapons = {
            "Longbow", "Shortbow", "Recurve Bow", "Compound Bow", "Sling", "Atlatl", "Javelin", "Throwing Knife", 
            "Throwing Axe", "Ballista", "Catapult", "Trebuchet", "Spear", "Bo-hiya (Rocket Arrow)", "Chu-Ko-Nu (Repeating Crossbow)",
            "Arbalest", "Scorpio (Ancient Roman Artillery)", "Dart", "Harpoon", "Net", "Slingstaff", "Hand Cannon", 
            "Musket", "Arquebus", "Culverin", "Puckle Gun", "Wrist Bow", "Mini Crossbow", "Pneumatic Crossbow", 
            "Harpoon Gun", "Spear Gun", "Slingshot", "Blowgun", "Dart Rifle", "Paintball Marker", "Airsoft Gun", 
            "Tranquilizer Gun", "Rubber Bullet Gun", "Pepper Spray Gun", "Taser Gun", "Stun Gun"
        };

        // Select a random weapon from the "Other Distance Weapons" list
        string selectedWeapon = otherDistanceWeapons[UnityEngine.Random.Range(0, otherDistanceWeapons.Length)];
        
        GameLogger.Log($"Random firearm type selected: {selectedWeapon}");
        return selectedWeapon;
    }

    public static string GetRandomBiome()
    {
        string[] biomes = {
            "Forest", "Desert", "Mountain", "Arctic", "Jungle", "Swamp", "Coastal", "Urban",
            "Grassland", "Savanna", "Tundra", "Wetlands", "Island", "Riverbank", "Lake", "Cave", "Ocean"
        };
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
