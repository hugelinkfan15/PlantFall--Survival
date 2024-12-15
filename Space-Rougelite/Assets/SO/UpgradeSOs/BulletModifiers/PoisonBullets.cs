using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PoisonUpgrade", menuName = "SO/Upgrades/BulletModis/PoisonUpgrade", order = 1)]
public class PoisonBullets : BulletModifier
{
    public float poisonDamage;
    public float effectLength;
    public override IEnumerator GiveEffect(Enemy enemy)
    {
        float seconds = 0;
        float regSpeed = enemy.speed;
        enemy.speed /= 2;
        while (enemy.gameObject.activeSelf && seconds < effectLength)
        {
            yield return new WaitForSeconds(1f);
            enemy.TakeDamage((poisonDamage*tier));
            seconds += 0.1f;
        }

        enemy.speed = regSpeed;
    }
}
