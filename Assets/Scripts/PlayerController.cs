using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using YG;

public class PlayerController : MonoBehaviour
{
    public UnityEvent Landed;
    public UnityEvent Dead;

    [SerializeField] private float _jampForse;
    [SerializeField] private ContactFilter2D _platform;
    private Rigidbody2D _rigidbody;
    [SerializeField] AudioSource AudioJump;
    private bool _delayedEvaluation = false;
    [SerializeField] GameObject _FinishPanel;
    [SerializeField] GameObject _BeforeFinishPanel;

    static public bool _PlatformCheck;

    private bool _isOnPlatform => _rigidbody.IsTouching(_platform);

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        Invoke("DelayedEvaluation", 240f);
    }

    public void Jump()
    {
        if (_isOnPlatform == true)
        {
            _rigidbody.AddForce(Vector2.up * _jampForse, ForceMode2D.Impulse);
            AudioJump.Play();
        }
        
    }
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && !_FinishPanel.activeInHierarchy)
        {
            Jump();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionObject = collision.gameObject;

        if (collisionObject.transform.parent != null)
        {
            if (collisionObject.transform.parent.TryGetComponent(out Platform platform))
            {
                platform.StopMovement();
            }
        }

        if (collisionObject.CompareTag("WallPlatform"))
        {
            Dead?.Invoke();
            if (_delayedEvaluation == true)
            {
                YandexGame.ReviewShow(true);
            }
            _PlatformCheck = false;
            Invoke("Ads", 0.5f);
            Invoke("DisplayAds", 1.5f);
        }
        else if(collisionObject.CompareTag("Platform"))
        {
            collisionObject.tag = "Untagged";
            Landed?.Invoke();
        }
    }
    public void DelayedEvaluation()
    {
        _delayedEvaluation = true;
    }
    public void DisplayAds()
    {
        _FinishPanel.SetActive(true);
        _BeforeFinishPanel.SetActive(false);
    }
    public void Ads()
    {
        YandexGame.FullscreenShow();
    }
}
