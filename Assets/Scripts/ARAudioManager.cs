using System.Collections;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(AudioSource))]
public class ARAudioManager : MonoBehaviour
{
    [Header("Audio")]
    [Tooltip("El clip de audio que se reproducirá (arrastra tu archivo .mp3 o .wav aquí)")]
    public AudioClip audioClip;

    [Tooltip("Volumen del audio (0 a 1)")]
    [Range(0f, 1f)]
    public float volume = 1f;

    [Header("UI - Botón de Audio")]
    [Tooltip("GameObject del botón de audio (el círculo verde con el ícono de speaker)")]
    public GameObject audioButtonObject;

    [Tooltip("Imagen del ícono dentro del botón")]
    public Image audioIcon;

    [Tooltip("Sprite cuando el audio está reproduciéndose (speaker con ondas)")]
    public Sprite iconPlaying;

    [Tooltip("Sprite cuando el audio está pausado (speaker sin ondas o con X)")]
    public Sprite iconPaused;

    
    private AudioSource _audioSource;
    private bool _isPaused = false;

   
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.playOnAwake = false;
        _audioSource.loop = false;
        _audioSource.volume = volume;

        if (audioClip != null)
            _audioSource.clip = audioClip;

        SetAudioButtonVisible(false);
    }

   
    public void OnScanComplete()
    {
        SetAudioButtonVisible(true);
        PlayAudio();
    }

    public void OnImageLost()
    {
        StopAudio();
        SetAudioButtonVisible(false);
    }

  
    public void OnAudioButtonClicked()
    {
        if (_audioSource.isPlaying)
        {
            PauseAudio();
        }
        else
        {
            ResumeOrPlayAudio();
        }
    }

    private void PlayAudio()
    {
        _isPaused = false;
        _audioSource.Stop();
        _audioSource.Play();
        UpdateIcon(playing: true);
    }

    private void PauseAudio()
    {
        _isPaused = true;
        _audioSource.Pause();
        UpdateIcon(playing: false);
    }

    private void ResumeOrPlayAudio()
    {
        _isPaused = false;
        if (_isPaused)
            _audioSource.UnPause();
        else
            _audioSource.Play();
        UpdateIcon(playing: true);
    }

    private void StopAudio()
    {
        _isPaused = false;
        _audioSource.Stop();
        UpdateIcon(playing: false);
    }

    private void UpdateIcon(bool playing)
    {
        if (audioIcon == null) return;

        if (playing && iconPlaying != null)
            audioIcon.sprite = iconPlaying;
        else if (!playing && iconPaused != null)
            audioIcon.sprite = iconPaused;
    }

    private void SetAudioButtonVisible(bool visible)
    {
        if (audioButtonObject != null)
            audioButtonObject.SetActive(visible);
    }

    void Update()
    {
      
        if (!_audioSource.isPlaying && !_isPaused && audioButtonObject != null && audioButtonObject.activeSelf)
        {
            UpdateIcon(playing: false);
        }
    }
}
