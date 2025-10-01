using UnityEngine;

public class ReactiveAI : MonoBehaviour
{
    public Transform player;
    public float speed = 4f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

    // Update is called once per frame
    void Update()
    {
    transform.position = Vector3.MoveTowards(transform.position,new Vector3(player.position.x, player.position.y, player.position.z),speed*Time.deltaTime);    
    }
}
