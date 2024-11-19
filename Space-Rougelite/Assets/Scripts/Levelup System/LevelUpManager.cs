using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;

public class LevelUpManager : MonoBehaviour
{
    public static int playerLevel = 1;
    public static int exp = 0;
    public static int toNextLevel = 5;
    public static int totalExp;
    
    public static int currentLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(exp == toNextLevel)
        {
            totalExp += exp;
            exp -= toNextLevel;
            playerLevel++;
            toNextLevel = 10;
            Debug.Log("Level up!");
        }
    }

    public void ExpGot(int amount)
    {
        exp += amount;
    }
}
