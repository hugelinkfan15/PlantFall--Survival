using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class LevelUpManager : MonoBehaviour
{
    //All varibales set to public static for easy global access
    public static int playerLevel = 1;
    public static int exp = 0;
    public static int toNextLevel = 5;
    public static int totalExp;

    [Header("Option Text Boxes")]
    [SerializeField] private TextMeshProUGUI Option1;
    [SerializeField] private TextMeshProUGUI Option2;
    [SerializeField] private TextMeshProUGUI Option3;

    public LevelUpOption currentOption1;
    public LevelUpOption currentOption2;
    public LevelUpOption currentOption3;

    [Header("UI Elements")]
    [SerializeField] private GameObject LevelupMenu;
    public DisplayBar expBar;
    //[SerializeField] private TextMeshProUGUI Option4;

    [Header("List for Upgrade Choices")]
    public List<LevelUpOption> options;
    private List<LevelUpOption> useable;

    [Header("Menu Selection for no Item")]
    [SerializeField] private LevelUpOption emptyLevelUp;


    public static int currentLevel;
    // Start is called before the first frame update
    void Start()
    {
        useable = new List<LevelUpOption>(options);
        foreach (LevelUpOption option in useable)
        {
            option.OnReset();
        }
        playerLevel = 1;
        toNextLevel = 5;
        exp = 0;
        totalExp = 0;
        getOptions();
        ExpBarNext();
    }

    // Update is called once per frame
    void Update()
    {
        expBar.SetValue(exp);

        if (!PauseMenu.isPaused && exp >= toNextLevel)
        {
            LevelUp();
        }
    }

    /// <summary>
    /// Activates the levelup menu, resets collected exp, increments total exp, and rasies exp needed for next level
    /// </summary>
    public void LevelUp()
    {
        getOptions();
        LevelupMenu.SetActive(true);
        totalExp += exp;
        exp-=toNextLevel;
        playerLevel++;
        toNextLevel += 5;
        SetOptionText();
        PauseMenu.Instance.pauseGame();
        Debug.Log("Level up!");
    }

    //For Buttons to use

    public void Option1Pressed()
    {
        currentOption1.GiveBonus();
        if(currentOption1.level == currentOption1.maxLevel)
        {
            useable.Remove(currentOption1);
        }
        ExpBarNext();
    }

    public void Option2Pressed()
    {
        currentOption2.GiveBonus();
        if (currentOption2.level == currentOption2.maxLevel)
        {
            useable.Remove(currentOption2);
        }
        ExpBarNext();
    }

    public void Option3Pressed()
    {
        currentOption3.GiveBonus();
        if (currentOption3.level == currentOption3.maxLevel)
        {
            useable.Remove(currentOption3);
        }
        ExpBarNext();
    }

    public void ExpBarNext()
    {
        expBar.SetValue(exp);
        expBar.SetMaxValueOnly(toNextLevel);
    }

    /// <summary>
    /// Gets three unique randomly selcted upgrades from a list of valid upgrades. Will place a defuat options if not enough options are avaible
    /// </summary>
    private void getOptions()
    {
        int[] usedInts = { -1, -1, -1 };
        if (useable.Count > 0)
        {
            while (usedInts[0] == -1)
            {
                int q = Random.Range(0, useable.Count);
                currentOption1 = useable[q];
                usedInts[0] = q;
            }

            if (useable.Count > 1)
            {
                while (usedInts[1] == -1)
                {
                    int q = Random.Range(0, useable.Count);
                    if (q != usedInts[0])
                    {
                        currentOption2 = useable[q]; ;
                        usedInts[1] = q;
                    }
                }
            }
            else
            {
                currentOption2 = emptyLevelUp;
                currentOption3 = emptyLevelUp;
            }

            if (useable.Count > 2)
            {

                while (usedInts[2] == -1)
                {
                    int q = Random.Range(0, useable.Count);
                    if ((q != usedInts[0]) && (q != usedInts[1]))
                    {
                        currentOption3 = useable[q];
                        usedInts[2] = q;
                    }
                }
            }
            else
            {
                currentOption3 = emptyLevelUp;
            }
        }
        else 
        {
            currentOption1 = emptyLevelUp;
            currentOption2 = emptyLevelUp;
            currentOption3 = emptyLevelUp;
        }
    }

    /// <summary>
    /// Sets the text on all three options to that of the choosen levelups
    /// </summary>
    private void SetOptionText()
    {
        Option1.text = currentOption1.description;
        Option2.text = currentOption2.description;
        Option3.text = currentOption3.description;
    }
}
