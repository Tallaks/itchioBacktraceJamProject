using Game.Application;
using Game.Application.GameScore;
using Game.Gameplay.States;
using Game.Infrastructure.Services;
using Game.Infrastructure.Services.StateMachine;
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
    
    private StateMachine _stateMachine;
    private CoroutineRunner _coroutineRunner;

    private void Awake()
    {
      _restartButton.onClick.AddListener(RestartGame);
      _backToMenuButton.onClick.AddListener(RetutnToMainMenu);

      _stateMachine = AllServices.Instance.Resolve<StateMachine>();
      _coroutineRunner = AllServices.Instance.Resolve<CoroutineRunner>();
    }

    private void Start() => 
      UpdateInfo();

    public void SetActivePanel(bool state)
    {
      UpdateInfo();
      gameObject.SetActive(state);
    }

    public void RetutnToMainMenu() => 
      _stateMachine.NextState(new MainMenuState(_coroutineRunner));

    public void RestartGame() => 
      _stateMachine.NextState(new RestartGameState(_stateMachine, _coroutineRunner));

    private bool IsNewRecord() => 
      false;

    private void UpdateInfo()
    {
      int score = Score.Instance.Value;
      _scoreText.text = score.ToString();
      _recordText.SetActive(IsNewRecord());
    }
  }
}