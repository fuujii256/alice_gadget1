using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class VoiceVoxRun : MonoBehaviour
{
    [SerializeField]
    
    public GameObject alice_Text;

    private string viewText;
    public AudioSource _audioSource;
    

    void Start()
    {
        viewText = "先生、こんにちは！、アリスは今日も元気です！";
        StartCoroutine(SpeakTest(viewText));
        //テキストを表示
        alice_Text.GetComponent<Text>().text = viewText;
    }

    IEnumerator SpeakTest (string text)
    {
        // VOICEVOXのREST-APIクライアント
        VoiceVoxApiClient client = new VoiceVoxApiClient();

        // テキストからAudioClipを生成（話者は「8:春日部つむぎ」）
        yield return client.TextToAudioClip(58, text);

        if (client.AudioClip != null)
        {
            // AudioClipを取得し、AudioSourceにアタッチ
            _audioSource.clip = client.AudioClip;
            // AudioSourceで再生
            _audioSource.Play();
        }
    }
}
