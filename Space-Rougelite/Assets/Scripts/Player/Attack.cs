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

    public int numProjectiles;
    public int pierce;

    public bool auto;
    // Start is called before the first frame update
    void Start()
    {
        cooldown = attackSpeed;
        auto = false;
        PlayerStats.damage = damage;
        PlayerStats.bulletSpeed = bulletSpeed;
        PlayerStats.range = range;
        PlayerStats.attackSpeed = attackSpeed;
        PlayerStats.projectileNumber = numProjectiles;
        PlayerStats.pierce = pierce;
    }

    // Update is called once per frame
    void Update()
    {
        damage = PlayerStats.damage * PlayerStats.damageMult;
        bulletSpeed = PlayerStats.bulletSpeed * PlayerStats.bulletSpeedMult; 
        attackSpeed = PlayerStats.attackSpeed * PlayerStats.attackSpeedMult;
        range = PlayerStats.range * PlayerStats.rangeMult;
        numProjectiles = PlayerStats.projectileNumber;
        cooldown += Time.deltaTime;
        pierce = PlayerStats.pierce;

        if(attackSpeed < cooldown)
        {
            if (auto)
            {
                StartCoroutine(DoAttack());
                cooldown = 0.0f;
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                StartCoroutine(DoAttack());
                cooldown = 0.0f;
            }
        }
    }

    /// <summary>
    /// Calls Fire function from equipped weapon
    /// </summary>
    IEnumerator DoAttack()
    {
        int shots = 0;
        while (shots < numProjectiles)
        {
            yield return new WaitForSeconds(0.2f);
            weapon.GetComponent<Gun>().Fire(damage, range, bulletSpeed);
            Debug.Log("attack");
            shots++;
        }
    }
}
