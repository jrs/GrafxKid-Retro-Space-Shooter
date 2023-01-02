using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionFX : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _fxSound;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource.PlayOneShot(_fxSound);
        Destroy(this.gameObject, 1f);
    }
}
