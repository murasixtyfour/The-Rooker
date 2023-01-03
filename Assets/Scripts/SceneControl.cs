using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneControl : MonoBehaviour
{
	public PlayerPause pp;
	public Image fadeImage;

	[HideInInspector] public int buildIndex;
	[HideInInspector] public enum FadeDirection { In, Out }

	float fadeSpeed = 1f;

	void Awake()
    {
		buildIndex = SceneManager.GetActiveScene().buildIndex;
	}

    void Start()
	{
		StartCoroutine(Fade(FadeDirection.Out, 0f, 32));
	}

	public IEnumerator Fade(FadeDirection fadeDirection, float red, int index)
	{
		if (pp != null) pp.FreezePlayer(true); 

		float alpha = (fadeDirection == FadeDirection.Out) ? 1f : 0f;
		float _alpha = (fadeDirection == FadeDirection.Out) ? 0f : 1f;
		if (fadeDirection == FadeDirection.Out)
		{
			while (alpha >= _alpha)
			{
				SetAlpha(fadeDirection, red, ref alpha);
				yield return null;
			}
			fadeImage.gameObject.SetActive(false);
		}
		else
		{
			fadeImage.gameObject.SetActive(true);
			while (alpha <= _alpha)
			{
				SetAlpha(fadeDirection, red, ref alpha);
				yield return null;
			}
		}

		if (pp != null) pp.FreezePlayer(false);

		LoadScene(index);
	}

	void SetAlpha(FadeDirection fadeDirection, float red, ref float alpha)
	{
		fadeImage.color = new Color(red, 0f, 0f, alpha);
		alpha += Time.deltaTime * fadeSpeed * ((fadeDirection == FadeDirection.Out) ? -1 : 1);
	}

	public void LoadScene(int index)
	{
		if (index < 32) SceneManager.LoadScene(index);
	}
}
