using UnityEngine;

public class Player2Pin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<CharSelectBox>().P2Selected();
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<CharSelectBox>().P2Delected();
    }
}
