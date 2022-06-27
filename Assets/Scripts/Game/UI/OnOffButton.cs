using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
  [RequireComponent(typeof(Button))]
  public class OnOffButton : MonoBehaviour
  {
    [SerializeField] private Sprite _on;
    [SerializeField] private Sprite _off; 
    [SerializeField] private bool _isOn;

    public bool IsOn
    {
      get => _isOn;
      set => _isOn = value;
    }

    private void Awake() => 
      GetComponent<Button>().onClick.AddListener((ChangeState));

    private void ChangeState()
    {
      IsOn = !IsOn;
      GetComponent<Image>().sprite = IsOn ? _on : _off;
    }
  }
}