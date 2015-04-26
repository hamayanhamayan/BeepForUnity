using UnityEngine;
using System.Collections;

public class BeepScript : MonoBehaviour {
    public int samplerate = 44100;
    public int frequency = 440;
    public int position = 0;

    AudioSource audio;

	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Play(int freq, double duration)
    {
        audio.Stop();

        AudioClip clip = AudioClip.Create("Beep", (int)(samplerate * duration), 1, samplerate, true, OnAudioRead);
        frequency = freq;

        audio.clip = clip;

        audio.Play();
    }

    void OnAudioRead(float[] buf)
    {
        int i = 0;
        while(i < buf.Length)
        {
            buf[i] = 0.1f * Mathf.Sign(Mathf.Sin(2 * Mathf.PI * frequency * position / samplerate));
            position++;
            i++;
        }
    }

    void OnAudioSetPosition(int newPosition)
    {
        position = newPosition;
    }
}
