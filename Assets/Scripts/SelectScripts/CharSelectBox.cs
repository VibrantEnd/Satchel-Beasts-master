using UnityEngine;
using UnityEngine.UI;

public class CharSelectBox : MonoBehaviour
{
    [SerializeField] GameObject SpriteDisplay;
    [SerializeField] GameObject PlayerCharacter;
    public static GameObject Player1ToSpawn;
    public static GameObject Player2ToSpawn;
    private GameObject p1Preview;
    private GameObject p2Preview;
    private Vector2 displayPosition1 = new Vector2(-5.25f, 2.14f);
    private Vector2 displayPosition2 = new Vector2(5.25f, 2.14f);
    void Start()
    {

    }

    public void P1Selected()
    {
        if(SpriteDisplay != null)
        {
            p1Preview = Instantiate(SpriteDisplay, displayPosition1, Quaternion.identity);
            
        }
        Player1ToSpawn = PlayerCharacter;
    }
    public void P1Delected()
    {
        if(p1Preview != null)
        {
            Destroy(p1Preview);
            
        }
    }
    public void P2Selected()
    {
        if (SpriteDisplay != null)
        {
            p2Preview = Instantiate(SpriteDisplay, displayPosition2, Quaternion.identity);
            
        }
        Player2ToSpawn = PlayerCharacter;
    }
    public void P2Delected()
    {
        if(p2Preview != null)
        {
            Destroy(p2Preview);
            
        }
    }
    //public void Select()
    //{
    //    if(SpriteDisplay != null)
    //    {
    //        if (player1Selected)
    //        {
    //            p1Preview = Instantiate(SpriteDisplay, displayPosition1, Quaternion.identity);
    //            player1Selected = true;
    //        }
    //        if (player2Selected)
    //        {
    //            p2Preview = Instantiate (SpriteDisplay, displayPosition2, Quaternion.identity);
    //            player2Selected = true;
    //        }
    //    }
    //}

}
