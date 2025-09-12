using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [Header("Configuración de Niveles")]
    [SerializeField] private int totalLevels = 5; // Cambia esto al número máximo de niveles que quieras (ej: 5)
    private int nextLevelIndex = 2; // El primer nivel después del 1

    void Awake()
    {
        // Patrón Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Cuando sales del refugio
    public void GoToNextLevel()
    {
        if (nextLevelIndex <= totalLevels)
        {
            SceneManager.LoadScene("Nivel" + nextLevelIndex);
        }
        else
        {
            // Aquí puedes poner una escena de victoria final
            SceneManager.LoadScene("EscenaFinal");
        }
    }

    // Cuando ganas un nivel (ej: Nivel2, Nivel3, etc.)
    public void WinLevel()
    {
        // Cada vez que ganas, aumentamos el contador para el próximo nivel
        if (nextLevelIndex <= totalLevels)
        {
            nextLevelIndex++;
        }

        // Siempre regresas al refugio
        ReturnToLevel1();
    }

    public void ReturnToLevel1()
    {
        SceneManager.LoadScene("Nivel1");
    }

    // Reiniciar progreso (opcional)
    public void ResetProgress()
    {
        nextLevelIndex = 2;
    }
}
