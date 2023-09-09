using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float sekunden;
    public int MAXSEKUNDEN;
    public Image kreis;
    public Image kreisHintergrund;
    public AudioSource audioSource;
    public SpriteRenderer bell;
    float oldTime;
    bool over = false;
    // Start is called before the first frame update
    void Start()
    {
        oldTime = Time.time;
        StopAllCoroutines();
        StartCoroutine(Shake());
        audioSource.time = 135.9f;
        audioSource.Play();
        kreis.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        var newTime = Time.time;
        if(newTime > oldTime + 1)
        {
            print(newTime);
            oldTime = newTime;
            sekunden++;
            if(sekunden > MAXSEKUNDEN)
            {
                if (!over)
                {
                    Destroy(bell);
                    audioSource.time = 128.1f;
                    audioSource.Play();

                }
                over = true;
                if(sekunden - MAXSEKUNDEN> 6)
                {
                    audioSource.Stop();
                    Destroy(this);
                }
               
            }
            kreis.fillAmount = sekunden / MAXSEKUNDEN;
        }
        
    }

    [Header("Info")]
    private Vector3 _startPos;
    private float _timer;
    private Vector3 _randomPos;

    [Header("Settings")]
    [Range(0f, 2f)]
    public float _time = 0.2f;
    [Range(0f, 2f)]
    public float _distance = 0.1f;
    [Range(0f, 2f)]
    public float _delayBetweenShakes = 0f;

    private void Awake()
    {
        _startPos = kreis.transform.position;
    }

    private void OnValidate()
    {
        if (_delayBetweenShakes > _time)
            _delayBetweenShakes = _time;
    }
    private IEnumerator Shake()
    {
        _timer = 0f;

        while (_timer < _time)
        {
            _timer += Time.deltaTime;

            _randomPos = _startPos + (Random.insideUnitSphere * _distance);

            kreis.transform.position = _randomPos;
            kreisHintergrund.transform.position = _randomPos;

            if (_delayBetweenShakes > 0f)
            {
                yield return new WaitForSeconds(_delayBetweenShakes);
            }
            else
            {
                yield return null;
            }
        }

        kreis.transform.position = _startPos;
        kreisHintergrund.transform.position = _startPos;
    }
}
