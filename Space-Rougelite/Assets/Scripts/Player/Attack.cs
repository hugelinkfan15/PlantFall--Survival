using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float damage;
    public float attackSpeed;

    private float cooldown;

    public GameObject weapon;

    public float bulletSpeed;
    public float range;

    public bool auto;
    // Start is called before the first frame update
    void Start()
    {
        cooldown = attackSpeed;
        auto = false;
        PlayerStats.bulletSpeed = bulletSpeed;
        PlayerStats.range = range;
        PlayerStats.attackSpeed = attackSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown += Time.deltaTime;

        if(attackSpeed < cooldown)
        {
            if (auto)
            {
                DoAttack();
                cooldown = 0.0f;
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                DoAttack();
                cooldown = 0.0f;
            }
        }
    }

    private void DoAttack()
    {
        weapon.GetComponent<Gun>().Fire(damage, PlayerStats.range, PlayerStats.bulletSpeed);
        Debug.Log("attack");
    }
}
