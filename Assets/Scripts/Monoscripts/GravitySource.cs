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
            float rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            pm.transform.rotation = Quaternion.Lerp(pm.transform.position)
            //pm.transform.rotation = Quaternion.Euler(0,0,rotation + 90);
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
