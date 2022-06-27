using UnityEngine;

namespace Game.Application.Sound
{
  [RequireComponent(typeof(AudioSource))]
  public class MusicSource : MonoBehaviour
  {
    private AudioMediator _audioMediator;

    private void Awake()
    {
      _audioMediator = FindObjectOfType<AudioMediator>();
      _audioMediator.AddMusic(this);
      TurnOn(_audioMediator.MusicOn);
    }

    private void OnDestroy() => 
      _audioMediator.RemoveMusic(this);
    
    public void TurnOn(bool on) =>
      GetComponent<AudioSource>().mute = !on;

    public void Restart() => 
      GetComponent<AudioSource>().Play();
  }
}