using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Shadow : MonoBehaviour
{
    public Vector3 Offset = new Vector3(0.01f, -0.01f, -184f);
    public Material Material;
    GameObject _shadow;
    void Start()
    {
        _shadow = new GameObject("Shadow");
        _shadow.transform.parent = transform;
        _shadow.transform.localPosition = Offset;
        _shadow.transform.localRotation = Quaternion.identity;
        _shadow.transform.localScale = (_shadow.transform.localScale * 15);
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        SpriteRenderer sr = _shadow.AddComponent<SpriteRenderer>();
        sr.sprite = renderer.sprite;
        sr.material = Material;
        sr.sortingLayerName = renderer.sortingLayerName;
        sr.sortingOrder = renderer.sortingOrder - 1;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        _shadow.transform.localPosition = Offset;
    }
}
