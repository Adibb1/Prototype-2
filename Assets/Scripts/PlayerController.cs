using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float speed = 15.0f;
    public GameObject bananaPrefab;
    private float cooldownAttack = 1.0f;
    private bool isCooldown = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        if (transform.position.z < -9 || transform.position.z > 9)
        {
            transform.Translate(Vector3.left * horizontalInput * speed * Time.deltaTime);
        }

        if (!isCooldown && Input.GetKeyDown(KeyCode.Space))
        { 
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        isCooldown = true;
        Instantiate(bananaPrefab, new Vector3(transform.position.x - 1, transform.position.y + 1.5f, transform.position.z), bananaPrefab.transform.rotation);
        yield return new WaitForSeconds(cooldownAttack);
        isCooldown = false;
    }
}
