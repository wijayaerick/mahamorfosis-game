using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoodleBoss : MonoBehaviour {
    public static int status;
    public GameObject noodleBoss2;
    public GameObject noodleBoss3;
    //-1=ga munculin apa2
    //0=munculin musuh 2
    //1=munculin musuh 3
    // Use this for initialization
    void Start () {
        status = -1;
	}
	
	// Update is called once per frame
	void Update () {
		if (status==0)
        {
            status = -1;
            Vector3 bossPosition;
            GameObject bossClone;
            bossPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);
            bossClone = Instantiate(noodleBoss2, bossPosition, transform.rotation);
            
        } else if (status==1)
        {
            status = -1;
            Vector3 bossPosition;
            GameObject bossClone;
            bossPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);
            bossClone = Instantiate(noodleBoss3, bossPosition, transform.rotation);
            
        }
	}
}
