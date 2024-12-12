using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChestManager : Singleton<ChestManager>
{
    public List<Upgrade> upgrades;
    private List<Upgrade> useable;
    public PlayerStats stats;

    public GameObject upgradeMenu;

    [SerializeField] private TextMeshProUGUI Option1;
    [SerializeField] private TextMeshProUGUI Option2;
    [SerializeField] private TextMeshProUGUI Option3;

    public Upgrade currentOption1;
    public Upgrade currentOption2;
    public Upgrade currentOption3;

    public Upgrade emptyUpgrade;
    // Start is called before the first frame update
    void Start()
    {
        useable = new List<Upgrade>(upgrades);
        foreach (Upgrade upgrade in useable)
        {
            upgrade.OnReset();
        }

        PlayerStats.modifiers.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLoot()
    {
        upgradeMenu.SetActive(true);
        getUpgrades();
        SetOptionText();
        PauseMenu.Instance.pauseGame();
    }

    private void SetOptionText()
    {
        Option1.text = currentOption1.upgradeName +"\n"+ currentOption1.description;
        Option2.text = currentOption2.upgradeName +"\n"+ currentOption2.description;
        Option3.text = currentOption3.upgradeName + "\n" + currentOption3.description;
    }

    public void Option1Pressed()
    {
        currentOption1.DoUpgrade();
        if (currentOption1.tier == currentOption1.maxTier)
        {
            useable.Remove(currentOption1);
        }
    }

    public void Option2Pressed()
    {
        currentOption2.DoUpgrade();
        if (currentOption2.tier == currentOption2.maxTier)
        {
            useable.Remove(currentOption2);
        }
    }

    public void Option3Pressed()
    {
        currentOption3.DoUpgrade();
        if (currentOption3.tier == currentOption3.maxTier)
        {
            useable.Remove(currentOption3);
        }
    }
    private void getUpgrades()
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
                currentOption2 = emptyUpgrade;
                currentOption3 = emptyUpgrade;
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
                currentOption3 = emptyUpgrade;
            }
        }
        else
        {
            currentOption1 = emptyUpgrade;
            currentOption2 = emptyUpgrade;
            currentOption3 = emptyUpgrade;
        }
    }
}
