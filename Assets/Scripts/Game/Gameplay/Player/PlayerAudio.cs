using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Player
{
  [RequireComponent(typeof(AudioSource))]
  public class PlayerAudio : MonoBehaviour
  {
    [SerializeField, Required] private AudioClip _explosion; 
    
    private AudioSource _audioSource;

    private void Awake()
    {
      _audioSource = GetComponent<AudioSource>();
    }

    public void PlayExplosion()
    {
      _audioSource.clip = _explosion;
      _audioSource.volume = 1;
      _audioSource.loop = false;
      _audioSource.Play();
    }
  }
}