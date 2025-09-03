using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Vector2 p1Spawn = new Vector2(-2, 0);
    private Vector2 p2Spawn = new Vector2(2, 0);
    private GameObject Player1;
    private GameObject Player2;
    void Awake()
    {
        Player1Spawn();
        Player2Spawn();
    }

    void Player1Spawn()
    {
        Player1 = Instantiate(CharSelectBox.Player1ToSpawn, p1Spawn, Quaternion.identity);
        Player1.tag = "Player1";
        if (Player1.GetComponent<Player>().enabled == false)
        {
            Player1.GetComponent<Player>().enabled = true;
        }
        if(Player1.GetComponent<Player2>().enabled == true)
        {
            Player1.GetComponent<Player2>().enabled = false;
        }
    }
    void Player2Spawn()
    {
        Player2 = Instantiate(CharSelectBox.Player2ToSpawn, p2Spawn, Quaternion.identity);
        Player2.tag = "Player2";
        if(Player2.GetComponent<Player>().enabled == true)
        {
            Player2.GetComponent<Player>().enabled = false;
        }
        if(Player2.GetComponent<Player2>().enabled == false)
        {
            Player2.GetComponent<Player2>().enabled = true;
        }
    }
}
