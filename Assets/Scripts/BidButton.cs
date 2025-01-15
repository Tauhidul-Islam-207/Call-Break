using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BidButton : MonoBehaviour
{
    public int bidVal;
    public int bidIndex;
    public BidManager bidManager;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaceBid()
    {
        bidManager.bid[bidIndex] = bidVal;
    }
}
