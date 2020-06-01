using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RongController : MonoBehaviour
{

    private Rigidbody2D rb;
    private PolygonCollider2D polygonCollider;
    [SerializeField]
    private LayerMask Player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        polygonCollider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (polygonCollider.IsTouchingLayers(Player))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }

    }
}
