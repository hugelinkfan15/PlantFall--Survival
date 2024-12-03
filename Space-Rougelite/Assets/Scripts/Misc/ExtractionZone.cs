using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtractionZone : MonoBehaviour
{
    //attach the parent object of the arrow attached to the player, not the arrow itself
    public GameObject playerArrow;

    //NEED TO SET THE MIN AND MAX FOR EACH AXIS
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    [SerializeField] private float countdown = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    /// <summary>
    /// Activate player to point towards point and moves point to a random location in bounds)
    /// </summary>
    private void Awake()
    {
        transform.position = new Vector3(Random.Range(minX,maxX),Random.Range(minY,maxY),0);
        playerArrow.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
    }

    /// <summary>
    /// Starts countdown for extraction and deactivates arrow on player
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(StartCountDown());
            playerArrow.SetActive(false);
        }
    }

    /// <summary>
    /// Stops countdown and actives arrow on player
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StopAllCoroutines();
            playerArrow.SetActive(true);
        }
    }


    IEnumerator StartCountDown()
    {
        while(true)
        {
            yield return new WaitForSeconds(countdown);

            GameManager.Instance.gameOver = true;
        }
    }

}
