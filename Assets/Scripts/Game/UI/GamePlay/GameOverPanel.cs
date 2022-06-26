using Game.Gameplay.Player;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Gameplay
{
  public class GameOverPanel : MonoBehaviour
  {
    [SerializeField, Required] private GameObject _recordText;
    [SerializeField, Required] private TMP_Text _scoreText;
    [SerializeField, Required] private Button _restartButton;
    [SerializeField, Required] private Button _backToMenuButton;

    private void Awake()
    {
      _restartButton.onClick.AddListener(RestartGame);
      _backToMenuButton.onClick.AddListener(RetutnToMainMenu);
    }

    private void Start()
    {
      int score = FindObjectOfType<PlayerEntity>().Score.Value;
      _scoreText.text = score.ToString();
      _recordText.SetActive(IsNewRecord());
    }

    public void SetActivePanel(bool state) => 
      gameObject.SetActive(state);

    public void RetutnToMainMenu()
    {
      
    }

    public void RestartGame()
    {
      
    }

    private bool IsNewRecord() => 
      false;
  }
}