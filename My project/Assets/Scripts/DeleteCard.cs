using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;

public class DeleteCard : MonoBehaviour
{
    public GameObject gm;
    public GameObject gameObjectCard;
    public void onClick()
    {
        gm.GetComponent<GameRound>().GenerateCard();
        if (transform.parent.parent.tag == "playerOne")
        {
            Debug.Log(transform.parent.tag);
            GameObject gameObjectHand = Instantiate(gameObjectCard, new Vector3(transform.parent.position.x, 0, 0), Quaternion.identity);
            gameObjectHand.transform.SetParent (GameObject.FindGameObjectWithTag("playerOne").transform, false);
        } else if (transform.parent.parent.tag == "playerTwo")
        {
            
            
            
            
            
        }
        Destroy(transform.parent.gameObject);
    }   
}
