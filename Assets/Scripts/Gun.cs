using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _shotPeriod = 0.2f;
    [SerializeField] private AudioSource _shotSound;
    [SerializeField] private GameObject _flash;
    [SerializeField] private Transform _spawn;
    [SerializeField] private float _timer;
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _shotPeriod)
        {
            if (Input.GetMouseButton(0))
            {
                _timer = 0;
                Bullet newBullet = Instantiate(_bulletPrefab, _spawn.position, _spawn.rotation);
                _shotSound.Play();
                _flash.SetActive(true);
                Invoke(nameof(HideFlash), 0.12f);
            }
        }
    }

    public void HideFlash()
    {
        _flash.SetActive(false);
    }
}
