using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BidManager : MonoBehaviour
{
    public List<int> bid;
    public GameObject p1bid;
    public GameObject p2bid;
    public GameObject p3bid;
    public GameObject p4bid;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Close1()
    {
        p1bid.SetActive(false);
        p2bid.SetActive(true);
    }
    public void Close2()
    {
        p2bid.SetActive(false);
        p3bid.SetActive(true);
    }
    public void Close3()
    {
        p3bid.SetActive(false);
        p4bid.SetActive(true);        
    }
    public void Close4()
    {
        p4bid.SetActive(false);  
    }

    public void ResetBid()
    {
        for(int i = 0; i<bid.Count; i++)
        {
            bid[i] = 0;
        }
    }


}
