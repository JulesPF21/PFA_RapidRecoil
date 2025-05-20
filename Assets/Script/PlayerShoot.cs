using System;
using RayFire;
using UnityEngine;
using UnityEngine.VFX;
using Random = UnityEngine.Random;


public class PlayerShoot : MonoBehaviour
{
    public VisualEffect gunEffect;
    RayfireBomb barril;
    [SerializeField] RayfireGun rayfireGun;
    public PlayerWeapon weapon;
    [SerializeField] Camera cam;
    [SerializeField] LayerMask mask;
    public AudioSource gun;
    public Transform gunTransform; // à assigner dans l’inspecteur
    public Vector3 recoilOffset = new Vector3(0, 0, -0.1f); // petit recul vers l’arrière
    public float recoilSpeed = 10f;
    public float returnSpeed = 5f;

    private Vector3 originalGunPos;
    private Vector3 currentRecoil;
    private void Start()
    {
        gunEffect.Stop();
        originalGunPos = gunTransform.localPosition;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shot();
            currentRecoil = recoilOffset;
        }
        currentRecoil = Vector3.Lerp(currentRecoil, Vector3.zero, returnSpeed * Time.deltaTime);
        gunTransform.localPosition = Vector3.Lerp(gunTransform.localPosition, originalGunPos + currentRecoil, recoilSpeed * Time.deltaTime);
    }

    private void shot()
    {
        gunEffect.Play();
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        rayfireGun.Shoot();
        gun.Play();
        if (Physics.Raycast(ray, out RaycastHit hit, weapon.range, mask))
        {
            Debug.Log("Objet touché : " + hit.collider.name);
            if (hit.collider.name == "GO_barril")
            {
                RayfireBomb barrel = hit.collider.GetComponent<RayfireBomb>();
                barrel.Explode(0);
            }
        }
    }
   
}
