using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FireUpgrade", menuName = "SO/Upgrades/BulletModis/FireUpgrade", order = 0)]
public class FireBullets : BulletModifier
{
    public float fireDamage;
    public float effectLength;
    public override IEnumerator GiveEffect(Enemy enemy)
    {
        float seconds = 0;
        while(enemy.gameObject.activeSelf && seconds<effectLength)
        {
            yield return new WaitForSeconds(0.1f);
            enemy.TakeDamage((fireDamage*tier) / 10);
            seconds += 0.1f;
        }
    }
}
