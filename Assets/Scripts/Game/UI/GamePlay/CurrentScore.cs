using DG.Tweening;
using Game.Application.GameScore;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace Game.UI.Gameplay
{
  public class CurrentScore : MonoBehaviour
  {
    [SerializeField, Required] 
    private TMP_Text _scoreText;

    [SerializeField, Required]
    private TMP_Text _addedTextPrefab;

    public void Reset() => 
      _scoreText.text = 0.ToString();

    public void AddScore(int value)
    {
      _scoreText.text = Score.Instance.Value.ToString();
      ShowAddingScoreInstance(value);
    }

    private void ShowAddingScoreInstance(int value)
    {
      TMP_Text addedScoreText = Instantiate(_addedTextPrefab, _scoreText.transform.parent);
      addedScoreText.text = "+" + value;
      addedScoreText.GetComponent<RectTransform>().DOMoveY(_scoreText.transform.position.y, 1);
      addedScoreText.DOFade(0, 1);
    }
  }
}