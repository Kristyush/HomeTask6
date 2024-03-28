using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Gun : MonoBehaviour
{
    [SerializeField] public GameObject BulletPrefab;
    [SerializeField] public Transform Spawn;
    [SerializeField] public float BulletSpeed = 10;
    [SerializeField] public float ShotPeriod = 0.2f;
    [SerializeField] public AudioSource ShotSound;
    [SerializeField] public GameObject Flash;
    [SerializeField] private float _timer;
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > ShotPeriod)
        {
            if (Input.GetMouseButton(0))
            {
                _timer = 0;
                GameObject newBullet = Instantiate(BulletPrefab, Spawn.position, Spawn.rotation);
                newBullet.GetComponent<Rigidbody>().velocity = Spawn.forward * BulletSpeed;
                ShotSound.Play();
                Flash.SetActive(true);
                Invoke("HideFlash", 0.12f);
            }
        }
    }

    public void HideFlash()
    {
        Flash.SetActive(false);
    }
}
