using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Torch : MonoBehaviour
{
    public float health = 100;
    public Slider healthSlider;
    public bool dead = false;
    public Image deathImg;
    bool playedAnim = false;
    public AudioSource SFX;
    public AudioClip deathClip;
    public AudioClip oilClip;
    public GameObject Win;
    public GameObject Lose;
    public ParticleSystem torch;
    public Light torchLight;
    public GameObject popup;
    bool won = false;
    

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    IEnumerator pop()
    {
        popup.SetActive(true);
        yield return new WaitForSeconds(5f);
        popup.SetActive(false);
    }

    IEnumerator deathAnim()
    {
        SFX.clip = deathClip;
        SFX.Play();
        playedAnim = true;
        deathImg.enabled = true;
        yield return new WaitForSeconds(.1f);
        deathImg.enabled = false;
        yield return new WaitForSeconds(.05f);
        deathImg.enabled = true;
        yield return new WaitForSeconds(.1f);
        deathImg.enabled = false;
        yield return new WaitForSeconds(.1f);
        deathImg.enabled = true;
        Lose.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!won)
        {
            health -= Time.deltaTime * 2;
        }
        healthSlider.value = health;
        
        if (health < 10)
        {
            torch.Stop();
            torchLight.enabled = false;
        }
        if (health <= 0)
        {
            dead = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        if (dead && !playedAnim)
        {
            StartCoroutine(deathAnim());
        }

    }
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Oil")
        {
            SFX.clip = oilClip;
            SFX.Play();
            health = 100;
            torch.Play();
            torchLight.enabled = true;
            StartCoroutine(pop());
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "end")
        {
            won = true;
            Win.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
