using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(200,0));

        Destroy(this,5);
    }

    public void SetData(Vector3 pivot)
    {
        
    }
    public void Init(Vector3 pivot)
    {
        transform.position = pivot;
        rb.AddForce(new Vector2());

        Invoke("SetObjectPool", 5f);
    }

    public void SetObjectPool()
    {
        this.gameObject.SetActive(false);
        ObjectPollingDynamic.instace.SetObject(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Destroy(collision.gameObject);
            GameManager.Instance.AddScore(5);
            UIManager.Instance.UpdateScore();
            SetObjectPool();
            CancelInvoke();
        }
    }
}
