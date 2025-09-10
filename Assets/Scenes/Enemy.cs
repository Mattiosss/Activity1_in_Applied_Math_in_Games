using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public Transform target;          
    public float DeathRange = 2f;
    public float DangerRange = 5f;
    public float ShakeIntensity = 1f;
    private Vector3 originalPos;
    private SpriteRenderer sr;

    private void Start()
    {
        originalPos = transform.position;
        sr = GetComponent<SpriteRenderer>(); 
    }

    private void Update()
    {
        float dx = target.position.x - transform.position.x;
        float dy = target.position.y - transform.position.y;
        float distance = Mathf.Sqrt(dx * dx + dy * dy);

        if (distance < DeathRange)
        {
            Debug.Log("Death");
            Invoke("RestartScene", 0.5f); 
        }
        else if (distance < DangerRange)
        {
            Shake();
            sr.color = Color.red; 
        }
        else
        {
            
            transform.position = originalPos; 
            sr.color = Color.white; 
        }
    }

    private void Shake()
    {
        var newVector = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            0
        );

        transform.position += newVector * Time.deltaTime * ShakeIntensity;
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
