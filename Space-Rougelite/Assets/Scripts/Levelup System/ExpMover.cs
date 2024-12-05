using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpMover : MonoBehaviour
{
    public int value;
    [SerializeField] private float collectionSpeed;
    private Transform target;
    private bool touched = false;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (touched)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, collectionSpeed * Time.deltaTime);
        }
    }

    public void GoTo(Transform other)
    {
        target = other;
        touched = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform == target)
        {
            LevelUpManager.exp += value;
            Destroy(gameObject);
        }

    }

}
