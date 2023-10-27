using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacingDirections : MonoBehaviour
{


    [SerializeField] GameObject Player;
    [SerializeField] GameObject AI; 

    [SerializeField] SpriteRenderer PlayerSprite;
    [SerializeField] SpriteRenderer AISprite; 



    // Player.transform.position,AI.transform.position
    // sprite.flipX = true;
    void Update()
    {
        if(Player.transform.position.x<AI.transform.position.x){
            PlayerSprite.flipX = false;
            AISprite.flipX = false;
        }

        if(Player.transform.position.x>AI.transform.position.x){
            PlayerSprite.flipX = true;
            AISprite.flipX = true;
        }
    }
}
