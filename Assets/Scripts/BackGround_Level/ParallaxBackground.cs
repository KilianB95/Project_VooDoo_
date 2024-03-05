using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private Material _mat;
    private float _distance;

    [Range(0f,0.5f)]//Hierin wordt aangegeven wat de minimale snelheid kan zijn en de max snelheid.
    [SerializeField] private float _speed = 0.2f;//Dit is het standaard snelheid, kan aangepast worden in de Inspector.

    private void Start()
    {
        _mat = GetComponent<Renderer>().material;
    }

    //Hier in de update laat die de backgrounds repeaten
    private void Update()
    {
        _distance += Time.deltaTime * _speed;//Repeat de background snelheid
        _mat.SetTextureOffset("_MainTex", Vector2.right * _distance);//Hier maakt die steeds een neiuwe method aan voor de material
    }
}
