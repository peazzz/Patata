using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flutter : MonoBehaviour
{
    public Transform movePos;
    public GameObject Player;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //if (PlayerControl.Moving)
        //{
        //    transform.position = new Vector2(Player.transform.position.x + 8, Player.transform.position.y + 5.2f);
        //    movePos.position = new Vector2(Player.transform.position.x + 8, Player.transform.position.y + 5.2f);
        //}
        //else
        //{
            transform.position = Vector3.Lerp(transform.position, movePos.position, 0.06f);

            if (Vector2.Distance(transform.position, movePos.position) < 0.3f)
            {
                movePos.position = randomPos();
            }

            Vector2 randomPos()
            {
                Vector2 rndPos = new Vector2(Random.Range(Player.transform.position.x + 7, Player.transform.position.x + 9f),
                Random.Range(Player.transform.position.y + 5f, Player.transform.position.y + 5.5f));
                return rndPos;
            }
        //}
    }
}
