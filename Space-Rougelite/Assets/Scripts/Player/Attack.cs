using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.UI;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float damage;
    public float attackSpeed;
    public float attackArea;

    private float cooldown;

    public bool auto;
    // Start is called before the first frame update
    void Start()
    {
        cooldown = attackSpeed;
        auto = false;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown += Time.deltaTime;

        if(attackSpeed < cooldown)
        {
            if (auto)
            {
                doAttack();
                cooldown = 0.0f;
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                doAttack();
                cooldown = 0.0f;
            }
        }
    }

    private void doAttack()
    {
        Debug.Log("attack");
    }
}
