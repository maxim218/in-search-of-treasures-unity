using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour {
    [SerializeField] private AudioClip clipMy;
    private AudioSource _audioSource = null;
    
    private void Start() {
        _audioSource = gameObject.GetComponent<AudioSource>();
        _audioSource.clip = clipMy;
        _audioSource.loop = true;
        _audioSource.Play();
    }
}
