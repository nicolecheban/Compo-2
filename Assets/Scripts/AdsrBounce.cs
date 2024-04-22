using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsrBounce : MonoBehaviour
{
    public float currentADSRValue = 0.0f;
    public Vector3 baseScale = new Vector3(1, 1, 1);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newScale = baseScale + baseScale * currentADSRValue;
        transform.localScale = newScale;
    }
    public void UpdateADSR(float adsrValue)
    {
        currentADSRValue = adsrValue;
    }
}
