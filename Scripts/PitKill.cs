using UnityEngine;

public class PitKill : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            LevelManager levelManager = Object.FindFirstObjectByType<LevelManager>();
            if (levelManager != null) 
            {
                levelManager.RestartLevel();
            }
        }
    }
}
