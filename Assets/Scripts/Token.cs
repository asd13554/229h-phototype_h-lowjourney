using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Token : MonoBehaviour
{

    private void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "Token")
        {
            Col.gameObject.SetActive(false);
            ScoreManager.instance.AddPoint();
        }
    }

}
