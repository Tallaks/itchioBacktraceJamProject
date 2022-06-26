using UnityEngine;

namespace Game.Gameplay.Aid
{
  [RequireComponent(typeof(AudioSource))]
  public class AidAudio : MonoBehaviour
  {
    [SerializeField] private AudioClip _fallingSound;
    [SerializeField] private AudioClip _breakAudio;
    
    private AudioSource _audioPlayer;

    private void Awake()
    {
      _audioPlayer = GetComponent<AudioSource>();
      _audioPlayer.clip = _fallingSound;
      _audioPlayer.Play();
    }

    public void PlayBreaking()
    {
      _audioPlayer.clip = _breakAudio;
      _audioPlayer.loop = false;
      _audioPlayer.PlayScheduled(1);
    }
  }
}