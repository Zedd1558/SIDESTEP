using UnityEngine.UI;
using UnityEngine;

public class score : MonoBehaviour
{
    public static string scoresaver;
    public GameObject player;
    public GameManager gm;
    public Text scoreText;
    void Update()
    {
        bool ghe = gm.gameHasEnded;
        if (ghe == false) 
         scoresaver = player.transform.position.z.ToString("0");
        scoreText.text = scoresaver;
        PlayerPrefs.SetString("scoreData", scoresaver);

        
    }
}
