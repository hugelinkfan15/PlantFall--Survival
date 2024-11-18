using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetTextToThis : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.gameOverText = gameObject.GetComponent<TextMeshProUGUI>();   
    }
}
