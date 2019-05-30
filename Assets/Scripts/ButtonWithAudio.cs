using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonWithAudio : MonoBehaviour,IPointerClickHandler
{
    public AudioClip clickClip;
    protected AudioSource m_AudioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = this.transform.parent.gameObject.AddComponent<AudioSource>();
        m_AudioSource.playOnAwake = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        this.PlayAudio(this.clickClip);
    }

    private void PlayAudio(AudioClip ac)
    {
        if (ac == null)
        {
            Debug.LogError(this.name + ":audioClip is Null!");
        }
        this.m_AudioSource.PlayOneShot(ac);
    }
}
