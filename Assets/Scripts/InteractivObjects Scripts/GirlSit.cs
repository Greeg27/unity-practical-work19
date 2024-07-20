using UnityEngine;

public class GirlSit : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject sprite;
    //[SerializeField] GameObject panel;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.SetActive(false);
        sprite.SetActive(true);
        //panel.SetActive(true);
    }
}
