using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damage;
    public float reload;
    public Transform weaponSlot;
    [SerializeField] protected bool isChild;
    // Start is called before the first frame update

    protected void Start()
    {
        isChild = false;
    }
    // Update is called once per frame
    protected void Update()
    {
        if (transform.IsChildOf(weaponSlot))
        {
            isChild = true;
        }
    }
}
