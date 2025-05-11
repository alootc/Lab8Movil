using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 5f;
    public float life_time = 4f;

    private void Start()
    {
        Destroy(this.gameObject, life_time);
    }

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
