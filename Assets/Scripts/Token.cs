using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{
    [SerializeField] private GameObject sword;
    private void OnTriggerEnter2D(Collider2D Col)
    {
        //Get Score from Token
        if (Col.gameObject.tag == "Token")
        {
            Col.gameObject.SetActive(false);
            ScoreManager.instance.AddPoint();
        }
        
        //Destroy Sword
        if (Col.gameObject.tag == "Map")
        {
            sword.gameObject.SetActive(false);
        }
        
    }
}
