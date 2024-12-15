using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollisions : MonoBehaviour
{
    public int thisLayer;
    public int ignoreLayer;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(thisLayer, ignoreLayer);
        
    }

    // Update is called once per fr
}
