
using UnityEngine;

public class collision : MonoBehaviour
{
    public AudioSource audio;
    public void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "obstacle")
        {
            audio.Play(0);
            GetComponent<playerMovement>().enabled = false;
            FindObjectOfType<GameManager>().EndGame();

        }
    }
}
