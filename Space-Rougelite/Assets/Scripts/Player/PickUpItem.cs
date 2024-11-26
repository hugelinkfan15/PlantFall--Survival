using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// NOT WORKING!!!!!!
/// </summary>
public class PickUpItem : MonoBehaviour
{
    [SerializeField]private Transform pickupObject;
    [SerializeField] private float pickUpSpeed;
    private CircleCollider2D zone;

    // Start is called before the first frame update
    void Start()
    {
        PlayerStats.pickupRange = zone.radius;
    }

    // Update is called once per frame
    void Update()
    {
        zone.radius = PlayerStats.pickupRange;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Exp"))
        {
            collision.gameObject.GetComponent<ExpMover>().GoTo(pickupObject);
        }
    }
}
