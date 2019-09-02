using UnityEngine;

public class followComponent : MonoBehaviour
{
    private GameObject player;
    public Vector3 offset;

    
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("player");
        transform.position = player.transform.position + offset;
    }
}
