using UnityEngine;
using System.Collections;
namespace nabspace{
public class GM_GameOver : MonoBehaviour
{
    private GameManager_Master _gameManager;
    public GameObject panelGameOver;
    void OnEnable()
    {
        SetInitialReferences();
        _gameManager.GameOverEvent += turnOnGameOverPanel;

    }

    void OnDisable()
    {
        _gameManager.GameOverEvent -= turnOnGameOverPanel;
    }
    void SetInitialReferences()
    {
        _gameManager = GetComponent<GameManager_Master>();
    }

        void turnOnGameOverPanel()
        {
            if (panelGameOver != null)
            {
                panelGameOver.SetActive(true);
            }
        }

    }
}
