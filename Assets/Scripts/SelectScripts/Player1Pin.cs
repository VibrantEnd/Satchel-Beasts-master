using UnityEngine;

public class Player1Pin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<CharSelectBox>().P1Selected();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<CharSelectBox>().P1Delected();
    }
}
