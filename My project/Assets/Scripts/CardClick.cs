using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardClick : MonoBehaviour
{

    public TMP_Text cardType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick() {
        Debug.Log(cardType.text);
    }
}
