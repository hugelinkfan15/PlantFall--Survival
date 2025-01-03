using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MUST SET PROJECTILE DAMAGE IN PREFAB ITSELF
/// </summary>
public class RangedEnemy : Enemy
{
    [SerializeField] protected float attackCD;
    [SerializeField] protected float projectileSpeed;
    [SerializeField] protected GameObject projectile;
    //MUST SET PROJECTILE DAMAGE IN PREFAB ITSELF

    private bool isVisible;
    private float rCooldown;
    private bool isAttacking;
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        isVisible = false;
        isAttacking = false;
        rCooldown = attackCD;
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        if (!PauseMenu.isPaused)
        {
            if (!isAttacking)
            {
                rCooldown += Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }

            if (isVisible && attackCD < rCooldown)
            {
                StartCoroutine(Fire());
                rCooldown = 0.0f;
            }
        }
    }

    /// <summary>
    /// Shoots in direction of player
    /// </summary>

    protected new void OnBecameInvisible()
    {
        base.OnBecameInvisible();
        isVisible = false;
    }

    protected new void OnBecameVisible()
    {
        base.OnBecameVisible();
        isVisible = true;
    }

    IEnumerator Fire()
    {
        isAttacking = true;
        yield return new WaitForSeconds(1.0f);
        float angle = -Mathf.Atan2(player.position.x, player.position.y) * Mathf.Rad2Deg;

        Vector2 direction = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y).normalized;
        Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, angle)).gameObject.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
        yield return new WaitForSeconds(0.5f);
        isAttacking = false;
    }




}
