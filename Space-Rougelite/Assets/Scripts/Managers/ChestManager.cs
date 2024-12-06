using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour
{
    public BaseSingleFire upgrade;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            upgrade.SetUpgrade(collision.gameObject.GetComponentInChildren<Gun>().modifiedFire);
            collision.gameObject.GetComponentInChildren<Gun>().modifiedFire = upgrade;
        }
    }
}
