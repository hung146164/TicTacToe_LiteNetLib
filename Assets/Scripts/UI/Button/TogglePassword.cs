
using TMPro;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Button),typeof(Image))]
public class TogglePassword : MonoBehaviour
{
    Button _togglePasswordBtnObj;
    Image _image;

    [SerializeField] TMP_InputField _passwordInput;

    [SerializeField] Sprite HideSprite;
    [SerializeField] Sprite ShowSprite;

    bool _isPasswordVisible = false;

    private void Awake()
    {
        _image = GetComponent<Image>();

        _togglePasswordBtnObj = GetComponent<Button>();
        _togglePasswordBtnObj.onClick.AddListener(TogglePasswordVisibility);


    }
    private void TogglePasswordVisibility()
    {
        _isPasswordVisible = !_isPasswordVisible;
        _passwordInput.contentType = _isPasswordVisible ? TMP_InputField.ContentType.Standard : TMP_InputField.ContentType.Password;
        _passwordInput.ForceLabelUpdate();
        ChangeToggleIcon();
    }
    private void ChangeToggleIcon()
    {
         _image.sprite = _isPasswordVisible?ShowSprite:HideSprite;
    }
}
