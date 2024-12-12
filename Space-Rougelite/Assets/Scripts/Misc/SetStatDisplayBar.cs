using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetStatDisplayBar : MonoBehaviour
{
    public PlayerStats stats;
    // Start is called before the first frame update
    void Start()
    {
        stats.statsBox = GetComponent<TextMeshProUGUI>();
    }

    
}
