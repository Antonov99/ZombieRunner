using UnityEngine;

namespace Audio
{
    public class AudioManager:MonoBehaviour
    {
        private static AudioManager _instance;
        
        [SerializeField]
        private AudioClip mainTheme;
        
        [SerializeField]
        private AudioClip startMenu;

        [SerializeField]
        private AudioClip gameOverSound;
        
        [SerializeField]
        private AudioClip pauseMenu;

        [SerializeField]
        private AudioClip collectSound;

        [SerializeField]
        private AudioSource audioSource;
        
        public static AudioManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    Debug.LogError("AudioManager is NULL!");
                }
                return _instance;
            }
        }
        
        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }
            _instance = this;
            DontDestroyOnLoad(gameObject); 
        }

        private void Start()
        {
            PlayStartMenu();
        }

        public void PlayMainTheme()
        {
            audioSource.Stop();
            audioSource.clip = mainTheme;
            audioSource.loop = true;
            audioSource.Play();
        }
        
        public void PlayStartMenu()
        {
            audioSource.Stop();
            audioSource.clip = startMenu;
            audioSource.loop = true;
            audioSource.Play();
        }

        public void PlayGameOver()
        {
            audioSource.Stop();
            audioSource.clip = gameOverSound;
            audioSource.loop = false;
            audioSource.Play();
        }
        
        public void PlayPauseMenu()
        {
            audioSource.Stop();
            audioSource.clip = pauseMenu;
            audioSource.loop = true;
            audioSource.Play();
        }

        public void PlayCollectSound()
        {
            audioSource.PlayOneShot(collectSound);
        }

        private void OnDestroy()
        {
            if (_instance != this) return;
            _instance = null;
        }
    }
}