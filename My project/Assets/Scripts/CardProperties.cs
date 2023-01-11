using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CardProperties : MonoBehaviour
{
    public TMP_Text textDescr;
    
    public GameObject GameManager;
    // Start is called before the first frame update
    void Start()
    {
        textDescr.text = "test card descr";
        GameManager.GetComponent("GameRound");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
