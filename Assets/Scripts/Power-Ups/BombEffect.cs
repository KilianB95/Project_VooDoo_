using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PowerUpHandler))]
[RequireComponent(typeof(Rigidbody))]
public class BombEffect : MonoBehaviour
{
    [SerializeField] private bool _drawRadiusGizmo; //Debug bool
    [SerializeField] private Vector3 _throwForce; //Gebruik Y en Z waardes
    [SerializeField] private float _blastRadius;
    [SerializeField] private float _fuseTime;
    private float _bombFuse;
    private bool _hasBomb;
    [SerializeField] private GameObject _bomb;
    private Rigidbody _bombRB;

   /* private void Awake()
    {
        if (!_bomb)
            _bomb = GameObject.Find("Bomb");

        //_bombRB = _bomb.GetComponent<Rigidbody>();
        Physics.IgnoreCollision(_bomb.GetComponent<SphereCollider>(), this.gameObject.GetComponent<BoxCollider>(), true); //Negeer collision tussen de bom en de speler
        _bomb.SetActive(false);
    } */

    private void Update()
    {
        if (_hasBomb && Input.GetKey(KeyCode.RightControl))
        {
            ThrowBomb();
            _hasBomb = false;
        }

        if (Time.time >= _bombFuse && _bomb.activeInHierarchy)
        {
            ExplodeBomb();
        }

        if (_bomb.activeInHierarchy)
        {
            _bombRB.mass += 0.01f; //Pas dit nummer aan als je wilt dat de bom een kortere boog wilt hebben
        }
    }

    public void SetBomb(bool tempBomb)
    {
        _hasBomb = tempBomb;
    }

    private void ThrowBomb()
    {
        _bomb.transform.position = this.gameObject.transform.position;
        _bomb.SetActive(true);
        _bombRB.AddForce(_throwForce);
        _bombFuse = Time.time + _fuseTime;
    }

    private void ExplodeBomb()
    {
        Collider[] hitColliders = Physics.OverlapSphere(_bomb.transform.position, _blastRadius); //Zet elke collider die geraakt wordt in de blast radius in een array

        foreach (var hitCollider in hitColliders) // Zet alle objecten hierin uit en verplaats ze terug naar de object pool positie
        {
            // TODO:
            // Zet alle objecten hierin uit en verplaats ze terug naar de object pool positie
            // Maak if-statement om bepaalde tags te checken, bijvoorbeeld "player", "background", of "ground". Kan ook een check zijn voor "poolable object" o.i.d
        }

        ResetBomb();
    }

    private void ResetBomb()
    {
        _bombRB.mass = 1;
        // Voeg positie toe
        // _bomb.transform.position = ;
        _bomb.SetActive(false);
    }

    private void OnDrawGizmos()
    {
        if (_drawRadiusGizmo)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_bomb.transform.position, _blastRadius);
        }
    }
}
