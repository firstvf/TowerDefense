using System.Collections;
using UnityEngine;

public class BackGroundMusic : MonoBehaviour
{
    [SerializeField] private AudioClip _backgroundMusicUndertale;
    private AudioSource _audioSource;
    private bool _isAbleToSwitchMusic;
    private bool _isAbleToStartCoroutine = true;


    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void ChangeBackgroundMusic()
    {
        if (_isAbleToStartCoroutine)
        {
            _isAbleToStartCoroutine = false;
            StartCoroutine(TimeBeforeChangeMusic());
        }
    }

    private IEnumerator TimeBeforeChangeMusic()
    {
        _isAbleToSwitchMusic = true;
        _audioSource.Stop();
        yield return new WaitForSeconds(3f);
        if (_isAbleToSwitchMusic)
        {
            _isAbleToSwitchMusic = false;
            _audioSource.clip = _backgroundMusicUndertale;
            _audioSource.Play();
        }
    }

    public void ControlMusic()
    {
        if (!GameData.IsDisableMusic)
            _audioSource.mute = false;
        else _audioSource.mute = true;
    }
}