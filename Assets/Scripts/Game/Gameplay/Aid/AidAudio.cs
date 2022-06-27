using UnityEngine;

namespace Game.Gameplay.Aid
{
  [RequireComponent(typeof(AudioSource))]
  public class AidAudio : MonoBehaviour
  {
    [SerializeField] private AudioClip _fallingSound;
    [SerializeField] private AudioClip _breakAudio;
    [SerializeField] private AudioClip _consumedSound;
    
    private AudioSource _audioPlayer;

    private void Awake()
    {
      _audioPlayer = GetComponent<AudioSource>();
      _audioPlayer.clip = _fallingSound;
      _audioPlayer.Play();
    }

    public void PlayConsumed()
    {
      _audioPlayer.clip = _consumedSound;
      _audioPlayer.loop = false;
      _audioPlayer.Play();
    }
    
    public void PlayBreaking()
    {
      _audioPlayer.clip = _breakAudio;
      _audioPlayer.loop = false;
      _audioPlayer.Play();
    }
  }
}