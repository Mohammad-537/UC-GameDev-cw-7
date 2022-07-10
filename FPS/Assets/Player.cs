using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    float speed = 7.5f;
    public GameObject pistol;
    public GameObject Rifil;
    public GameObject flamethrower;
    public float turn;
    public GameObject CameraObject;
    public ParticleSystem psPlayer;
    int score = 0;
    public TextMeshProUGUI txtscore;
    int health = 100;
    public static Player instance;
    public int WeaponID;
    public Slider sliderUI;

    public void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
    }



    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        rb = GetComponent<Rigidbody>();
        
        //CameraObject = Camera.main.gameObject;
        speed = 7.5f;
        turn = 30f;
        //CameraObject = Camera.main.gameObject;
        //psFlare = 
        //CameraObject = Camera.main.gameObject;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            health -= 1;
            if(health <= 0)
            {
                SceneManager.LoadScene(0);
                Debug.Log("GAME OVER");
                
            }
            Debug.Log("Health: " + health);
        }
    }
    // Update is called once per frame
    void Update()
    {
        sliderUI.value = health;
        //Vector3 temp;
        //temp = ((Vector3.right * Input.GetAxis("Horizontal")) + (Vector3.forward * Input.GetAxis("Vertical"))) * speed;
        //rb.velocity = temp;
        //rb.angularVelocity = Vector3.up * Input.GetAxis("Mouse X") * turn;

        //Quaternion rotation = CameraObject.transform.rotation;
        //rotation.x += turn * Input.GetAxis("Mouse Y");
        //if(rotation.x > 0.3f)
        //{
        //    rotation.x = 0.3f;
        //}
        //else if (rotation.x < -0.6f)
        //{
        //    rotation.x = -0.6f;
        //}
        //rotation.y = 0;
        //rotation.z = 0;

        Vector3 temp;
        temp = (transform.right * Input.GetAxis("Horizontal") +
            transform.forward * Input.GetAxis("Vertical")) * speed;

        rb.velocity = temp;
        rb.angularVelocity = Vector3.up * Input.GetAxis("Mouse X") * turn;

        RaycastHit rHit;
        if (Input.GetButtonDown("Fire1"))
        {
            psPlayer.Play();
            if (Physics.Raycast(transform.position, transform.forward, out rHit))
            {
                
                if (rHit.collider.gameObject.tag == "enemy")
                {
                    
                    Destroy(rHit.collider.gameObject);
                    score += 1;

                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (WeaponID < 2)
            {
                WeaponID++;
            }
            else
            {
                WeaponID = 0;
            }
            if(WeaponID == 0)
            {
                pistol.SetActive(WeaponID == 0);
                Rifil.SetActive(WeaponID == 1);
                flamethrower.SetActive(WeaponID == 2);
            }
        }
        txtscore.text = "Score: " + score;
        
        
        //transform.Rotate(Vector3.right * turn * Input.GetAxis("Mouse Y"));
        //Vector3 vTurn;
        //vTurn = CameraObject.transform.rotation.eulerAngles;
        //vTurn.y += turn * Input.GetAxisRaw("Mouse Y");
        //vTurn.x = Mathf.Clamp(vTurn.x, -80f, 30f);

        //if(vTurn.x > 30)
        //{
        //    vTurn.x = 30;
        //}
        //else if(vTurn.x < -80)
        //{
        //    vTurn.x = -80;
        //}
        
    }
    //public void SetHealth(int health)
    //{
        
    //}
    
}
