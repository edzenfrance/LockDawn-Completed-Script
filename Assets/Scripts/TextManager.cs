using UnityEngine;

public class TextManager : MonoBehaviour
{
    // Stage 1
    public static string S1_DoorKey_A = "Upper Floor";
    public static string S1_DoorKey_B = "Locker Room";
    public static string S1_DoorKey_C = "File Room";
    public static string S1_DoorKey_D = "Master Bedroom";
    public static string S1_DoorKey_E = "Bathroom";
    public static string S1_DoorKey_F = "Kitchen Room";

    public static string S1_DoorKey_A_Add = "<color=green>Key: " + S1_DoorKey_A;
    public static string S1_DoorKey_B_Add = "<color=green>Key: " + S1_DoorKey_B;
    public static string S1_DoorKey_C_Add = "<color=green>Key: " + S1_DoorKey_C;
    public static string S1_DoorKey_D_Add = "<color=green>Key: " + S1_DoorKey_D;
    public static string S1_DoorKey_E_Add = "<color=green>Key: " + S1_DoorKey_E;
    public static string S1_DoorKey_F_Add = "<color=green>Key: " + S1_DoorKey_F;

    public static string S1_KeyWarn_A = "This door requires <color=green>Key: " + S1_DoorKey_A + "</color> to open.\nThe key must be around here, find it!";
    public static string S1_KeyWarn_B = "This door requires <color=green>Key: " + S1_DoorKey_B + "</color> to open.\nThe key must be around here, find it!";
    public static string S1_KeyWarn_C = "This door requires <color=green>Key: " + S1_DoorKey_C + "</color> to open.\nThe key must be around here, find it!";
    public static string S1_KeyWarn_D = "This door requires <color=green>Key: " + S1_DoorKey_D + "</color> to open.\nThe key must be around here, find it!";
    public static string S1_KeyWarn_E = "This door requires <color=green>Key: " + S1_DoorKey_E + "</color> to open.\nThe key must be around here, find it!";
    public static string S1_KeyWarn_F = "This door requires <color=green>Key: " + S1_DoorKey_F + "</color> to open.\nThe key must be around here, find it!";

    public static string S1_Inventory_A = "<color=green>Key: " + S1_DoorKey_A + "</color> - Can be use to open a locked door.";
    public static string S1_Inventory_B = "<color=green>Key: " + S1_DoorKey_B + "</color> - Can be use to open a locked door.";
    public static string S1_Inventory_C = "<color=green>Key: " + S1_DoorKey_C + "</color> - Can be use to open a locked door.";
    public static string S1_Inventory_D = "<color=green>Key: " + S1_DoorKey_D + "</color> - Can be use to open a locked door.";
    public static string S1_Inventory_E = "<color=green>Key: " + S1_DoorKey_E + "</color> - Can be use to open a locked door.";
    public static string S1_Inventory_F = "<color=green>Key: " + S1_DoorKey_F + "</color> - Can be use to open a locked door.";

    public static string S1_ItemGet_A = "Get the <color=green>Key: " + S1_DoorKey_A;
    public static string S1_ItemGet_B = "Get the <color=green>Key: " + S1_DoorKey_B;
    public static string S1_ItemGet_C = "Get the <color=green>Key: " + S1_DoorKey_C;
    public static string S1_ItemGet_D = "Get the <color=green>Key: " + S1_DoorKey_D;
    public static string S1_ItemGet_E = "Get the <color=green>Key: " + S1_DoorKey_E;
    public static string S1_ItemGet_F = "Get the <color=green>Key: " + S1_DoorKey_F;

    // Stage 2
    public static string S2_DoorKey_A = "Lounge Room";
    public static string S2_DoorKey_B = "Storage Room";
    public static string S2_DoorKey_C = "Kids Room";
    public static string S2_DoorKey_D = "Kitchen Room";
    public static string S2_DoorKey_E = "Billiard Room";
    public static string S2_DoorKey_F = "Main Room";

    public static string S2_DoorKey_A_Add = "<color=green>Key: " + S2_DoorKey_A;
    public static string S2_DoorKey_B_Add = "<color=green>Key: " + S2_DoorKey_B;
    public static string S2_DoorKey_C_Add = "<color=green>Key: " + S2_DoorKey_C;
    public static string S2_DoorKey_D_Add = "<color=green>Key: " + S2_DoorKey_D;
    public static string S2_DoorKey_E_Add = "<color=green>Key: " + S2_DoorKey_E;
    public static string S2_DoorKey_F_Add = "<color=green>Key: " + S2_DoorKey_F;

    public static string S2_KeyWarn_A = "This door requires <color=green>Key: " + S2_DoorKey_A + "</color> to open.\nThe key must be around here, find it!";
    public static string S2_KeyWarn_B = "This door requires <color=green>Key: " + S2_DoorKey_B + "</color> to open.\nThe key must be around here, find it!";
    public static string S2_KeyWarn_C = "This door requires <color=green>Key: " + S2_DoorKey_C + "</color> to open.\nThe key must be around here, find it!";
    public static string S2_KeyWarn_D = "This door requires <color=green>Key: " + S2_DoorKey_D + "</color> to open.\nThe key must be around here, find it!";
    public static string S2_KeyWarn_E = "This door requires <color=green>Key: " + S2_DoorKey_E + "</color> to open.\nThe key must be around here, find it!";
    public static string S2_KeyWarn_F = "This door requires <color=green>Key: " + S2_DoorKey_F + "</color> to open.\nThe key must be around here, find it!";

    public static string S2_Inventory_A = "<color=green>Key: " + S2_DoorKey_A + "</color> - This key will open the locked door.";
    public static string S2_Inventory_B = "<color=green>Key: " + S2_DoorKey_B + "</color> - This key will open the locked door.";
    public static string S2_Inventory_C = "<color=green>Key: " + S2_DoorKey_C + "</color> - This key will open the locked door.";
    public static string S2_Inventory_D = "<color=green>Key: " + S2_DoorKey_D + "</color> - This key will open the locked door.";
    public static string S2_Inventory_E = "<color=green>Key: " + S2_DoorKey_E + "</color> - This key will open the locked door.";
    public static string S2_Inventory_F = "<color=green>Key: " + S2_DoorKey_F + "</color> - This key will open the locked door.";

    public static string S2_ItemGet_A = "Get the door <color=green>Key: " + S2_DoorKey_A;
    public static string S2_ItemGet_B = "Get the door <color=green>Key: " + S2_DoorKey_B;
    public static string S2_ItemGet_C = "Get the door <color=green>Key: " + S2_DoorKey_C;
    public static string S2_ItemGet_D = "Get the door <color=green>Key: " + S2_DoorKey_D;
    public static string S2_ItemGet_E = "Get the door <color=green>Key: " + S2_DoorKey_E;
    public static string S2_ItemGet_F = "Get the door <color=green>Key: " + S2_DoorKey_F;

    // Stage 5
    public static string S5_DoorKey_A = "Office A";
    public static string S5_DoorKey_B = "Day Room";
    public static string S5_DoorKey_C = "Office B";
    public static string S5_DoorKey_D = "Bedroom";
    public static string S5_DoorKey_E = "Exam Room";
    public static string S5_DoorKey_F = "Surgery Room";

    public static string S5_DoorKey_A_Add = "<color=green>Key: " + S5_DoorKey_A;
    public static string S5_DoorKey_B_Add = "<color=green>Key: " + S5_DoorKey_B;
    public static string S5_DoorKey_C_Add = "<color=green>Key: " + S5_DoorKey_C;
    public static string S5_DoorKey_D_Add = "<color=green>Key: " + S5_DoorKey_D;
    public static string S5_DoorKey_E_Add = "<color=green>Key: " + S5_DoorKey_E;
    public static string S5_DoorKey_F_Add = "<color=green>Key: " + S5_DoorKey_F;

    public static string S5_KeyWarn_A = "This door requires <color=green>Key: " + S5_DoorKey_A + "</color> to open.\nThe key must be around here, find it!";
    public static string S5_KeyWarn_B = "This door requires <color=green>Key: " + S5_DoorKey_B + "</color> to open.\nThe key must be around here, find it!";
    public static string S5_KeyWarn_C = "This door requires <color=green>Key: " + S5_DoorKey_C + "</color> to open.\nThe key must be around here, find it!";
    public static string S5_KeyWarn_D = "This door requires <color=green>Key: " + S5_DoorKey_D + "</color> to open.\nThe key must be around here, find it!";
    public static string S5_KeyWarn_E = "This door requires <color=green>Key: " + S5_DoorKey_E + "</color> to open.\nThe key must be around here, find it!";
    public static string S5_KeyWarn_F = "This door requires <color=green>Key: " + S5_DoorKey_F + "</color> to open.\nThe key must be around here, find it!";

    public static string S5_Inventory_A = "<color=green>Key: " + S5_DoorKey_A + "</color> - This key will open the locked door.";
    public static string S5_Inventory_B = "<color=green>Key: " + S5_DoorKey_B + "</color> - This key will open the locked door.";
    public static string S5_Inventory_C = "<color=green>Key: " + S5_DoorKey_C + "</color> - This key will open the locked door.";
    public static string S5_Inventory_D = "<color=green>Key: " + S5_DoorKey_D + "</color> - This key will open the locked door.";
    public static string S5_Inventory_E = "<color=green>Key: " + S5_DoorKey_E + "</color> - This key will open the locked door.";
    public static string S5_Inventory_F = "<color=green>Key: " + S5_DoorKey_F + "</color> - This key will open the locked door.";

    public static string S5_ItemGet_A = "Get the door <color=green>Key: " + S5_DoorKey_A;
    public static string S5_ItemGet_B = "Get the door <color=green>Key: " + S5_DoorKey_B;
    public static string S5_ItemGet_C = "Get the door <color=green>Key: " + S5_DoorKey_C;
    public static string S5_ItemGet_D = "Get the door <color=green>Key: " + S5_DoorKey_D;
    public static string S5_ItemGet_E = "Get the door <color=green>Key: " + S5_DoorKey_E;
    public static string S5_ItemGet_F = "Get the door <color=green>Key: " + S5_DoorKey_F;

    // Misc Get
    public static string ItemGet_Vitamins = "Get the <color=green>vitamins</color>";
    public static string ItemGet_Alcohol = "Get the <color=green>alcohol</color>";
    public static string ItemGet_Facemask = "Get the <color=green>face mask</color>";
    public static string ItemGet_Faceshield = "Get the <color=green>face shield</color>";
    public static string ItemGet_Vaccine = "Get the <color=green>vaccine</color>";
    public static string ItemGet_Coin = "Get the <color=yellow>Coin</color>";
    public static string ItemGet_Syrup = "Get the <color=green>Special Syrup</color>";

    // Main Item
    public static string gotVitamin = "<size=22>You obtained the <color=green>vitamins</color>.\nExit the house to finish the stage!";
    public static string gotAlcohol = "<size=22>You obtained the <color=green>alcohol</color>.\nExit the house to finish the stage!";
    public static string gotFaceMask = "<size=22>You obtained the <color=green>face mask</color>.\nGo to the end of the road to finish the stage!";
    public static string gotFaceShield = "<size=22>You obtained the <color=green>face shield</color>.\nGo to end of the mall to finish the stage!";
    public static string gotVaccine = "<size=22>You obtained the <color=green>vaccine</color>.\nYou are now immune to damage and infection.\nGo to the exit point of the hospital to finish the stage!";

    public static string inventoryVitamin = "<color=green>Vitamins</color> - Main item that adds 5% to your immunity";
    public static string inventoryAlcohol = "<color=green>Alcohol</color> - Main item that adds 10% to your immunity";
    public static string inventoryFaceMask = "<color=green>FaceMask</color> - Main item that adds 15% to your immunity";
    public static string inventoryFaceShield = "<color=green>FaceShield</color> - Main item that adds 20% to your immunity";
    public static string inventoryVaccine = "<color=green>Vaccine</color> - Main item that adds 50% to your immunity";
    public static string inventorySyrup = "<color=green>Special Syrup</color> - This can be use to stop your health from infection.";
    public static string inventoryCoin = "<color=yellow>Coin</color> - This can be use to buy new skin in shop.";

    // Item Detection

    // Others
    public static string unlockingDoor = "Unlocking the door using <color=green>Key: ";
    public static string openingDoor = "Opening the <color=green>Door: ";
    public static string addedToInventory = "added to inventory.";
    public static string coinAdded = "<color=yellow>+10 coins</color> " + addedToInventory;
    public static string stopInfection = "Special syrup stop the infection!";
    public static string notInfected = "You are not infected";

    public static string quarantineArea = "You are in quarantine area!\nWatch some information to learn about COVID-19 and to reduce your quarantine time.";
    public static string doorIsLocked = "The door doesnt budge.";

    public static string[] characterName = new string[]
    {
        "Jack",
        "Jill",
        "Surgeon",
        "Male Doctor",
        "Female Doctor",    
        "Young Doctor"
    };

    public static string[] npcName = new string[]
    {
        "<size=70%><color=green>[Asymptomatic]</color></size>\nThe Crawler",
        "<size=70%><color=green>[Asymptomatic]</color></size>\nThe Child",
        "<size=70%><color=yellow>[Mild]</color></size>\nThe Mutated",
        "<size=70%><color=red>[Symptomatic]</color></size>\nThe Mortician",
        "<size=70%><color=red>[Symptomatic]</color></size>\nThe War Zombie",
    };

    // Survey
    public static string[][] surveyTexts = new string[][] {
      new string[] {
        "3",
        "A",
        "The CDC recommends washing your hands often with soap and water for at least 20 seconds. If soap and water are not available, the CDC recommends using an alcohol-based hand sanitizer that contains at least 60 percent alcohol.",
        "What is the most essential way to make your family safe from COVID-19 while inside your house?",
        "A. Use disinfectant regularly",
        "B. Wash hands using water only",
        "C. Use gloves inside the house everytime",
      },
      new string[] {
        "2",
        "B",
        "Physical distancing helps limit the spread of COVID-19 – this means we keep a distance of at least 1m from each other and avoid spending time in crowded places or in groups.",
        "While playing the game for the first time, what have you learned about the game that you can do in real life to avoid getting infected or spread the virus?",
        "A. Hide from infected",
        "B. Physical distancing",
       },
       new string[] {
        "3",
        "B",
        "Face masks combined with other preventive measures, such as getting vaccinated, frequent hand-washing and physical distancing, can help slow the spread of the virus.",
        "When do you need to wear your face mask?",
        "A. When sleeping",
        "B. When outside",
        "C. When an authority is looking",
       },
       new string[] {
        "3",
        "C",
        "The benefits of using face shield or face mask or both may offer better protection than the other on specific scenarios or depending on the size of particulate matter the protective equipment is blocking.",
        "How do you wear your face shield properly?",
        "A. Over the head",
        "B. On the back of your head",
        "C. Aligned to your face",
      },
      new string[] {
        "2",
        "A",
        "A vaccine is a type of medicine that trains the body’s immune system so that it can fight a disease it has not come into contact with before. Vaccines are designed to prevent disease, rather than treat a disease once you have caught it.",
        "_______ is a biological preparation that provides active acquired immunity to a particular infectious disease.",
        "A. Vaccine",
        "B. Vitamin",
      },
      new string[] {
        "2",
        "A",
        "Physical distancing helps limit the spread of COVID-19 – this means we keep a distance of at least 1m from each other and avoid spending time in crowded places or in groups.",
        "You are now on the final stage of the game, does the game help you to understand how safety protocols work in a pandemic situation?",
        "A. Yes",
        "B. No",
      }
    };

    public static string surveyCorrect = "Your answer it correctly! You learn something!";
    public static string surveyWrong = "Your wrong! ";

    // Riddle
    public static string[][] riddleTexts = new string[][] {
      new string[] {
        "I strive to combat diseases and make the world a healthier place. I create and share safety protocols for COVID-19 too.",
        "A. Frontliners or Doctors",
        "B. Teachers",
        "C. Taxi Driver",
        "D. None of the above",
        "A"},
      new string[] {
        "What has two loops, fits perfectly on your ears, makes you look real cool, and saves your life?",
        "A. Alcohol",
        "B. Earrings",
        "C. Hula HoopP",
        "D. Mask",
        "D"},
      new string[] {
        "I can be a drink, I can be lethal, but sure can kill 99.9 % of bacteria what am I.",
        "A. Body Liquid Soap",
        "B. Alcohol",
        "C. Sanitizer",
        "D. All of the above",
        "B"},
      new string[] {
        "It can be acrilic or a plastic, it can add more protection from the virus.",
        "A. Sun Glasses",
        "B. Jar",
        "C. Face Shield",
        "D. None of the above",
        "C"},
      new string[] {
        "It can be done through nose or mouth to identify if your safe or not from the virus.",
        "A. Swab Test",
        "B. Pregnancy Test",
        "C. Physical Test",
        "D. HIV/AIDS Test",
        "A"}
    };

    public static string riddleCorrect = "Your riddle answer is correct! Congrats, you gained collectors item! You can view the item in collectors hall!";
    public static string riddleWrong = "Your riddle answer is wrong! Better luck next time!";

    // Quarantine Quiz
    public static string[][] quizTexts = new string[][] {
      new string[] {
        "3",
        "C",
        "The first known infections from SARS-CoV-2 were discovered in Wuhan, China. The original source of viral transmission to humans remains unclear, as does whether the virus became pathogenic before or after the spillover event. -CDC (2020)",
        "Where was COVID-19 first identified?",
        "A. Africa",
        "B. Metro Manila",
        "C. Wuhan, China",
      },
      new string[] {
        "3",
        "A",
        "This means we keep a distance of at least 1m from each other and avoid spending time in crowded places or in groups. -CDC (2020)",
        "What is the minimum distance to be kept from each other to avoid COVID-19?",
        "A. Atleast 1 meter",
        "B. Atleast 1 milLimeter",
        "C. 5 meters",
      },
      new string[] {
        "3",
        "A",
        "If soap and water are not available, CDC recommends consumers use an alcohol-based hand sanitizer that contains at least 60% alcohol. -CDC (2020)",
        "Is hand sanitizer effective against COVID-19?",
        "A. Yes",
        "B. No",
        "C. Maybe"
      },
      new string[] {
        "2",
        "B",
        "Antibiotics do not work against viruses; they only work on bacterial infections. Antibiotics do not prevent or treat COVID-19, because COVID-19 is caused by a virus, not bacteria. -FDA (2021)",
        "Are antibiotics effective in preventing or treating COVID-19?",
        "A. Yes, very effective",
        "B. No",
      },
      new string[] {
        "2",
        "B",
        "While there are approved uses for ivermectin in people and animals, it is not approved for the prevention or treatment of COVID-19. -FDA (2021)",
        "Should you take ivermectin to prevent or treat COVID-19?",
        "A. Yes",
        "B. No",
      },
      new string[] {
        "3",
        "B",
        "To prevent the spread of COVID-19, Wear a mask and face shield in public, especially indoors or when physical distancing is not possible. -WHO",
        "How can you protect yourself from COVID-19?",
        "A. Sanitize your face mask",
        "B. Wear face mask and face shield",
        "C. Practice physical distancing when alone"
      },
      new string[] {
        "3",
        "A",
        "The official names COVID-19 and SARS-CoV-2 were issued by the WHO on 11 February 2020. -Wikipedia",
        "Who issued the official name of COVID-19?",
        "A. World Health Organization (WHO)",
        "B. Chinese People",
        "C. President"
      },
      new string[] {
        "2",
        "B",
        "There is currently no evidence that people can catch COVID-19 from food. The virus that causes COVID-19 can be killed at temperatures similar to that of other known viruses and bacteria found in food. -WHO (2020)",
        "Can COVID-19 be transmitted through food?",
        "A. Yes",
        "B. No",
      },
      new string[] {
        "3",
        "B",
        "The coronavirus disease (COVID-19) is caused by a virus, NOT by bacteria or germs.",
        "COVID-19 is caused by a ______?",
        "A. Bacteria",
        "B. Virus",
        "C. Germs",
      },
      new string[] {
        "2",
        "A",
        "Yes, infected people can transmit the virus both when they have symptoms and when they don't have symptoms. This is why it is important that all people who are infected are identified by testing, isolated, and, depending on the severity of their disease, receive medical care. -WHO (2020)",
        "Can asymptomatic people transmit COVID-19?",
        "A. Yes",
        "B. No",
      },
      new string[] {
        "2",
        "A",
        "Yes, infected people can transmit the virus both when they have symptoms and when they don't have symptoms. This is why it is important that all people who are infected are identified by testing, isolated, and, depending on the severity of their disease, receive medical care. -WHO (2020)",
        "How long can the virus that causes COVID-19 survive on surfaces after being expelled from the body?",
        "A. Hours to days",
        "B. 2 Months",
        "B. 1 Year",
      }
    };

    public static string quizCorrect = "Correct!";
    public static string quizWrong = "Your answer is wrong! You will be quarantine again for 5 minutes!\nAnswer correctly later and you will get your item!";

}
