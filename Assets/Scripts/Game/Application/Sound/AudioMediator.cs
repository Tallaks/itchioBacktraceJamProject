using System.Collections.Generic;
using Game.Infrastructure.Services;
using UnityEngine;

namespace Game.Application.Sound
{
  public class AudioMediator : MonoBehaviour, IService
  {
    private readonly List<SoundSource> _soundSources = new List<SoundSource>();
    private List<MusicSource> _musicSources = new List<MusicSource>();

    private void Awake() => 
      DontDestroyOnLoad(gameObject);

    public bool MusicOn { get; private set; } = true;
    public bool SoundOn { get; private set; } = true;
    
    public void TurnOnSounds(bool on)
    {
      SoundOn = on;
      foreach (SoundSource soundSource in _soundSources) 
        soundSource.TurnOn(on);
    }

    public void TurnOnMusic(bool on)
    {
      MusicOn = on;
      foreach (MusicSource musicSource in _musicSources) 
        musicSource.TurnOn(on);
    }
    
    public void AddSound(SoundSource soundSource) => 
      _soundSources.Add(soundSource);

    public void AddMusic(MusicSource musicSource) => 
      _musicSources.Add(musicSource);

    public void RemoveSound(SoundSource soundSource) => 
      _soundSources.Remove(soundSource);
    
    public void RemoveMusic(MusicSource musicSource) => 
      _musicSources.Remove(musicSource);
  }
}