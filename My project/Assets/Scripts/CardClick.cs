using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardClick : MonoBehaviour
{

    public TMP_Text CardType;
    public TMP_Text CardDescr;

    public GameObject playerOne;
    public GameObject playerTwo;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick() {

        if (transform.parent.tag == "playerOne")
        {
            player = playerOne;
            Debug.Log("it's player one");
        }
        else if(transform.parent.tag == "playerTwo")
        {
            player = playerTwo;
            Debug.Log("it's player two");
        }

        switch (CardType.text)
        {
            case "Carte Distance":
                Debug.Log("carte distance");
                Debug.Log(player.transform.position = new Vector2(player.transform.position.x + 10, player.transform.position.y));
                break;
            case "Carte Speed":
                Debug.Log("carte speed");
                break;
            case "Carte Shield":
                Debug.Log("carte shield");
                break;
            case "Carte Energy":
                Debug.Log("carte energy");
                break;
        }
    }
}
