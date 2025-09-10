using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishZone : MonoBehaviour
{
    public Transform player;
    public float FinishRange = 2f;
    public GameObject winUI;

    void Start()
    {
        if (winUI != null) winUI.SetActive(false);
    }

    void Update()
    {
        float dx = player.position.x - transform.position.x;
        float dy = player.position.y - transform.position.y;
        float distance = Mathf.Sqrt(Mathf.Pow(dx, 2) + Mathf.Pow(dy, 2));

        if (distance < FinishRange)
        {
            if (winUI != null) winUI.SetActive(true);

            
            Invoke("RestartScene", 2f);
        }
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
