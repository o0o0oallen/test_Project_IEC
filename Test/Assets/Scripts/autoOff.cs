using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoOff : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke(nameof(setOff), 2f);
    }
    void setOff()
    {
        this.gameObject.SetActive(false);        
    }
}
