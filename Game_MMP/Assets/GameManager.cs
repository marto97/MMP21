using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject player;
    bool gameover = false;

    void GameOver ()
    {
        Debug.Log("GameOver");
    }

    public void Update()
    {
        if(player.transform.position.y < -10f)
        {
            if(gameover == false)
            {
                gameover = true;
                GameOver();
            }
        }
    }
}
