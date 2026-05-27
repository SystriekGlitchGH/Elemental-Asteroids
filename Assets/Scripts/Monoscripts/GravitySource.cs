using System;
using UnityEngine;

public class GravitySource : MonoBehaviour
{
    [SerializeField] PlayerMovement pm;

    public float AtmosphericDrag;
    [SerializeField] int mass;
    public void Update()
    {
        if (pm != null)
        {
            Vector2 direction = (transform.position - pm.transform.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            pm.transform.rotation = targetRotation;
        }
    }
    public void FixedUpdate()
    {
        if (pm != null)
        {
            Vector2 direction = (transform.position - pm.transform.position).normalized;
            float scale = (float)(((pm.rb2d.mass * mass) / Math.Pow(Vector2.Distance(pm.transform.position, transform.position), 2))) * 100;
            pm.rb2d.AddForce(direction * scale);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(TryGetComponent(out PlayerMovement foundPlayer))
        {
            pm = foundPlayer;
            pm.rb2d.linearDamping = AtmosphericDrag;
        }
    }
}
