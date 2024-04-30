using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPoint : MonoBehaviour
{
    public GameObject target;
    public Transform shootPoint;
    public Rigidbody2D bullet;

    // Update
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 20, Color.yellow, 5);

            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider != null)
            {
                target.transform.position = new Vector2(hit.point.x, hit.point.y);
                Debug.Log(" Hit point : " + hit.point);

                Vector2 projectileV = CulculateProjectile(shootPoint.position, hit.point, 0.5f);
                
                Rigidbody2D spawnBullet = Instantiate(bullet, shootPoint.position, Quaternion.identity);
                
                spawnBullet.velocity = projectileV;
            }
        }

    }// Update
    
    Vector2 CulculateProjectile(Vector2 origin, Vector2 targetPoint, float time)
    {
        Vector2 distance = targetPoint - origin;
            
        float velocotyX = distance.x / time;
        float velocotyY = distance.x / time +  0.5f * Mathf.Abs(Physics2D.gravity.y) * time;

        Vector2 projecttileVelocity = new Vector2(velocotyX, velocotyY);

        return projecttileVelocity;
    }
    
}
