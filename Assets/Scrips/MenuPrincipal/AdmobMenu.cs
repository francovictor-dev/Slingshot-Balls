using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdmobMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AdmobManager.instance.Time++;
        if (AdmobManager.instance.Time > 1200f)
        {
            AdmobManager.instance.RequestBanner(10f);
            AdmobManager.instance.Time = 0;
        }
    }
}
