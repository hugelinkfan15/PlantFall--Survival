using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// NOT WORKING!!!!!!
/// </summary>
public class PickUpWeapon : MonoBehaviour
{
    public Transform gunPlace;
    public GameObject currentWeapon;
    private Collider2D pickupZone;
    // Start is called before the first frame update
    void Start()
    {
        pickupZone = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (collision.gameObject.CompareTag("Weapon"))
            {
                Drop(currentWeapon);
                Pickup(collision.gameObject);
            }
        }
    }

    private void Pickup(GameObject weapon)
    {
        weapon.GetComponent<Collider2D>().enabled = false;
        weapon.transform.SetParent(gunPlace, false);
        weapon.transform.Translate(gunPlace.transform.position);
        weapon = currentWeapon;
    }

    private void Drop(GameObject weapon)
    {
       currentWeapon.GetComponent<Collider2D>().enabled=true;
        currentWeapon.transform.parent = null;
    }
}
